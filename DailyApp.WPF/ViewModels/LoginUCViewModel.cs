using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DailyApp.WPF.ViewModels
{
    public class LoginUCViewModel : BindableBase, IDialogAware
    {
        public string Title { get; set; } = "我的日常";

        public event Action<IDialogResult> RequestClose;

        /// <summary>
        /// 登录命令
        /// </summary>
        public DelegateCommand LoginCmm {  get; set; }

        public LoginUCViewModel()
        {
            //登录命令
            LoginCmm = new DelegateCommand(Login);

            //显示注册信息命令
            ShowRegInfoCmm = new DelegateCommand(ShowRegInfo);
            //显示登录信息命令
            ShowLoginInfoCmm = new DelegateCommand(ShowLoginInfo);
        }

     

        /// <summary>
        /// 登录方法
        /// </summary>
        private void Login()
        {
            //登录成功
            if (RequestClose != null)
            {
                RequestClose(new DialogResult(ButtonResult.OK));
            }
        }


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
    }
}
