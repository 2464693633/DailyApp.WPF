using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyApp.WPF.HttpClients
{
    /// <summary>
    /// 请求模型
    /// </summary>
    public class ApiRequest
    {
        //请求地址/Api路由地址
        public string Route { get; set; }

        //请求方式(get/post/put/delete)
        public Method Method { get; set; }

        //请求参数
        public object Parameters { get; set; }

        //发送的数据类型
        public string ContentType { get; set; } = "application/json";
    }
}
