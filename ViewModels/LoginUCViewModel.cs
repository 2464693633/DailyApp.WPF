using DailyApp.WPF.DTOs;
using DailyApp.WPF.HttpClients;
using DailyApp.WPF.MsgEvents;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DailyApp.WPF.ViewModels
{
    public class LoginUCViewModel : BindableBase, IDialogAware
    {
        public string Title { get; set; } = "我的日常";

        public event Action<IDialogResult> RequestClose;

        private readonly HttpRestClient HttpClient;

        private readonly IEventAggregator Aggregator;

        /// <summary>
        /// 登录命令
        /// </summary>
        public DelegateCommand LoginCmm {  get; set; }

        public LoginUCViewModel(HttpRestClient _HttpClient, IEventAggregator _Aggregator)
        {
            //登录命令
            LoginCmm = new DelegateCommand(Login);

            //显示注册信息命令
            ShowRegInfoCmm = new DelegateCommand(ShowRegInfo);
            //显示登录信息命令
            ShowLoginInfoCmm = new DelegateCommand(ShowLoginInfo);

            RegCmm = new DelegateCommand(Reg);

            //实例化注册信息
            AccountInfoDTO = new AccountInfoDTO();

            //请求client 
            HttpClient = _HttpClient;
           //请求事件聚合器
            Aggregator = _Aggregator;
        }

       



        /// <summary>
        /// 登录方法
        /// </summary>
        private void Login()
        {
            //验证登录信息
            if (string.IsNullOrEmpty(Account) || string.IsNullOrEmpty(Pwd))
            {
                //发布信息
                Aggregator.GetEvent<MsgEvent>().Publish("登录信息不全");
                return;
            }

            //调用API
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Method = RestSharp.Method.GET;

            Pwd =MD5Helper.GetMD5(Pwd);
            apiRequest.Route = $"Account/Login?account={Account}&pwd={Pwd}";
            ApiRespense respense = HttpClient.Execute(apiRequest);//调用API登录接口

            if (respense.ResultCode == 1)//登录成功
            {
                if(RequestClose != null)
                {
                    RequestClose(new DialogResult(ButtonResult.OK));
                }
            }
            else
            {
                Aggregator.GetEvent<MsgEvent>().Publish($"登录失败：{respense.Msg}");
            }
        }

        #region 注册
        public DelegateCommand RegCmm { get; set; }

        private void Reg()
        {
            //验证注册信息
            if (string.IsNullOrEmpty(AccountInfoDTO.Name) || 
                string.IsNullOrEmpty(AccountInfoDTO.Account) || 
                string.IsNullOrEmpty(AccountInfoDTO.Pwd) ||
                string.IsNullOrEmpty(AccountInfoDTO.ConfirmPwd))
            {
                //发布信息
                Aggregator.GetEvent<MsgEvent>().Publish("注册信息不全");
                return;
            }
            if(AccountInfoDTO.Pwd != AccountInfoDTO.ConfirmPwd)
            {
                
                Aggregator.GetEvent<MsgEvent>().Publish("两次输入密码不一致");
                return;
            }

            //调用API注册接口

            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Route = "Account/Reg";
            apiRequest.Method = RestSharp.Method.POST;

            //对密码加密
            AccountInfoDTO.Pwd = MD5Helper.GetMD5(AccountInfoDTO.Pwd); 
            AccountInfoDTO.ConfirmPwd = MD5Helper.GetMD5(AccountInfoDTO.ConfirmPwd);

            apiRequest.Parameters = AccountInfoDTO;
            ApiRespense respense = HttpClient.Execute(apiRequest);//调用API注册接口

            if (respense.ResultCode == 1)
            {
                
                Aggregator.GetEvent<MsgEvent>().Publish("注册成功，请登录");
                //切换到登录界面
                SelecedIndex = 0;
            }
            else
            {
                
                Aggregator.GetEvent<MsgEvent>().Publish($"注册失败：{respense.Msg}");
            }
        }

        /// <summary>
        /// 注册信息
        /// </summary>
        private AccountInfoDTO _AccountInfoDTO;

        public AccountInfoDTO AccountInfoDTO
        {
            get { return _AccountInfoDTO; }
            set { 
                _AccountInfoDTO = value;
                RaisePropertyChanged();
            }
        }
        #endregion



        /// <summary>
        /// 是否可以关闭对话框
        /// </summary>
        /// <returns></returns>
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }


        #region
        /// <summary>
        /// 显示内容索引
        /// </summary>
        private int _SelecedIndex;

        public int SelecedIndex
        {
            get { return _SelecedIndex; }
            set { 
                _SelecedIndex = value; 
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 显示注册信息命令
        /// </summary>
        public DelegateCommand ShowRegInfoCmm { get; set; }
        /// <summary>
        /// 显示登录信息命令
        /// </summary>
        public DelegateCommand ShowLoginInfoCmm { get; set; }
        /// <summary>
        /// 显示注册信息
        /// </summary>
        private void ShowRegInfo()
        {
            SelecedIndex = 1;
        }
        /// <summary>
        /// 显示登录信息
        /// <summary>
        private void ShowLoginInfo()
        {
            SelecedIndex = 0;
        }
        #endregion

        #region 登录信息
        
        // 账号
        private string _Account;
        public string Account
        {
            get { return _Account; }
            set { 
                _Account = value;
                RaisePropertyChanged();
            }
        }

        // 密码
        private string _Pwd;
        public string Pwd
        {
            get { return _Pwd; }
            set {
                _Pwd = value;
                RaisePropertyChanged();
            }
        }
        #endregion


    }
}
