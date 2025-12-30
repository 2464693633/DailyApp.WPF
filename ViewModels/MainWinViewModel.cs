using DailyApp.WPF.Models;
using Prism.Mvvm;
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

		public List<LeftMenuInfo> LeftMenuList
        {
			get { return _LeftMenuList; }
			set {
                _LeftMenuList = value;
               RaisePropertyChanged();
            }
		}
        #endregion
        public MainWinViewModel()
        {
            LeftMenuList = new List<LeftMenuInfo>();

            //添加左侧菜单信息
            CreateMenu();

        }
        /// <summary>
        /// 创建菜单数据
        /// </summary>
        private void CreateMenu()
        {
            LeftMenuList.Add(new LeftMenuInfo(){ Icon = "Home",MenuName = "首页", ViewName = "IndexView" });
            LeftMenuList.Add(new LeftMenuInfo() { Icon = "NotebookOutLine", MenuName = "待办事项", ViewName = "WaitView" });
            LeftMenuList.Add(new LeftMenuInfo() { Icon = "NotebookPius", MenuName = "备忘录", ViewName = "MemoView" });
            LeftMenuList.Add(new LeftMenuInfo() { Icon = "Cog", MenuName = "设置", ViewName = "SettingsView" });
        }
    }
}
