using DailyApp.WPF.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DailyApp.WPF.ViewModels
{
    internal class HomeUCViewModel: BindableBase
    {
		private List<StatPanelInfo> _StatPanelList;

		/// <summary>
		/// 统计面板数据
		/// </summary>
		public List<StatPanelInfo> StatPnelList
		{
			get { return _StatPanelList; }
			set {
				_StatPanelList = value;
				RaisePropertyChanged();
			}
		}




	}
}
