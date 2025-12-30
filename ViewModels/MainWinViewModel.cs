using DailyApp.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DailyApp.WPF.ViewModels
{
    internal class MainWinViewModel : BindingBase
    {

        #region 左侧菜单信息
        private List<LeftMenuInfo> _LeftMenuInfo;

		public List<LeftMenuInfo> LeftMenuInfo
        {
			get { return _LeftMenuInfo; }
			set { _LeftMenuInfo = value; }
		}
        #endregion
        public MainWinViewModel()
        {
            LeftMenuInfo = new List<LeftMenuInfo>();

            //添加左侧菜单信息
            CreateMenu();

        }

        private void CreateMenu()
        {
            LeftMenuInfo.Add(new )
        }
    }
}
