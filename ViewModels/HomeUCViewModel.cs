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
    internal class HomeUCViewModel : BindableBase
    {
        #region 统计面板数据
        private List<StatPanelInfo> _StatPanelList;

        /// <summary>
        /// 统计面板数据
        /// </summary>
        public List<StatPanelInfo> StatPnelList
        {
            get { return _StatPanelList; }
            set
            {
                _StatPanelList = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public HomeUCViewModel()
        {
            CreateStatPanelList();
        }
        private void CreateStatPanelList()
        {
            StatPnelList = new List<StatPanelInfo>();

            StatPnelList.Add(new StatPanelInfo()
            {
                ItemName = "汇总",
                Result = "9",
                Icon = "Icons/clipboard-text-clock-outline.svg",
                BackColor = "#FFB74D",
                ViewName = "WaitUC"

            });
            StatPnelList.Add(new StatPanelInfo()
            {
                ItemName = "已完成",
                Result = "9",
                Icon = "Icons/check-circle-outline.svg",
                BackColor = "#4DB6AC",
                ViewName = "WaitUC"
            });
            StatPnelList.Add(new StatPanelInfo()
            {
                ItemName = "完成比例",
                Result = "90",
                Icon = "Icons/format-list-bulleted-type.svg",
                BackColor = "#64B5F6",
                ViewName = ""
            });
            StatPnelList.Add(new StatPanelInfo()
            {
                ItemName = "备忘录",
                Result = "20",
                Icon = "Icons/folder-outline.svg",
                BackColor = "#BA68C8",
                ViewName = "MemoUC"
            });

        }



    }
}
