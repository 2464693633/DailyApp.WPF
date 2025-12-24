using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyApp.WPF.ViewModels
{
    public class LoginUCViewModel : IDialogAware
    {
        public string Title { get; set; } = "我的日常";

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand LogCmm {  get; set; }

        public LoginUCViewModel()
        {
            LogCmm = new DelegateCommand(login);
        }
        /// <summary>
        /// 登录方法
        /// </summary>
        private void login()
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
    }
}
