using DailyApp.WPF.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DailyApp.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// 设置启动窗体
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            
           return Container.Resolve<MainWin>();
        }
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
        }
        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            var dialog = Container.Resolve<IDialogService>();
            dialog.ShowDialog("LoginUC", callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    //登录成功
                    base.OnInitialized();
                }
                else
                {
                    //登录失败 关闭程序
                   Environment.Exit(0);
                    return;
                }
            });
            
        }
       
    }

}
