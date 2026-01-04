using DailyApp.WPF.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DailyApp.WPF.ViewModels
{
    internal class MainWinViewModel : BindableBase
    {

        #region 左侧菜单信息
        private List<LeftMenuInfo> _LeftMenuList;

        /// <summary>
        /// 左侧菜单信息集合
        /// </summary>
		public List<LeftMenuInfo> LeftMenuList
        {
			get { return _LeftMenuList; }
			set {
                _LeftMenuList = value;
               RaisePropertyChanged();
            }
		}
        #endregion
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_RegionManager"></param>
        public MainWinViewModel(IRegionManager _RegionManager)
        {
            LeftMenuList = new List<LeftMenuInfo>();

            //添加左侧菜单信息
            CreateMenu();
            //区域导航管理器
            RegionManager = _RegionManager;
            //导航命令
            NavigateCmm = new DelegateCommand<LeftMenuInfo>(Navigate);

            //前进命令
            GoForWardCmm = new DelegateCommand(GoForWard);
            //后退命令
            GoBackCmm = new DelegateCommand(GoBack);
        }
        /// <summary>
        /// 创建菜单数据
        /// </summary>
        private void CreateMenu()
        {
            LeftMenuList.Add(new LeftMenuInfo(){ Icon = "Home",MenuName = "首页", ViewName = "HomeUC" });
            LeftMenuList.Add(new LeftMenuInfo() { Icon = "NotebookOutLine", MenuName = "待办事项", ViewName = "WaitUC" });
            LeftMenuList.Add(new LeftMenuInfo() { Icon = "NotebookPius", MenuName = "备忘录", ViewName = "MemoUC" });
            LeftMenuList.Add(new LeftMenuInfo() { Icon = "Cog", MenuName = "设置", ViewName = "SettingsUC" });
        }

        #region 区域 导航实现导航功能
        private readonly IRegionManager RegionManager;

        public DelegateCommand<LeftMenuInfo> NavigateCmm { get; set; }//导航命令

        /// <summary>
        /// 导航方法
        /// </summary>
        /// <param name="menu">菜单信息</param>
        private void Navigate(LeftMenuInfo menu)
        {
            if(menu == null || string.IsNullOrEmpty(menu.ViewName))
            {
                return;
            }
            RegionManager.Regions["MainViewRegion"].RequestNavigate(menu.ViewName, callback =>
            {
                Journal = callback.Context.NavigationService.Journal;//获取导航记录
            });
        }

        #endregion

        #region 请进后退
        private IRegionNavigationJournal Journal;//导航记录

        public DelegateCommand GoForWardCmm { get;private set; }//前进命令
        public DelegateCommand GoBackCmm { get; private set; }//后退命令

        private void GoForWard()
        {
            if (Journal != null && Journal.CanGoForward)
            {
                Journal.GoForward();
            }
        }

        private void GoBack()
        {
            if (Journal != null && Journal.CanGoBack)
            {
                Journal.GoBack();
            }
        }
        #endregion


    }
}
