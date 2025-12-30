using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyApp.WPF.HttpClients
{
    /// <summary>
    /// 调用Api 工具类
    /// </summary>
    public class HttpRestClient
    {
        //客户端
        private readonly RestClient Client;

        /// 基础地址(公共部分)
        private readonly string baseUrl = "http://localhost:5460/api/";

        public HttpRestClient()
        {
            Client = new RestClient();
        }

        /// <summary>
        /// 请求
        /// </summary>
        /// <param name="request">请求数据</param>
        /// <returns>接收的数据</returns>
        public ApiRespense Execute(ApiRequest apiRequest)
        {
            RestRequest request = new RestRequest(apiRequest.Method);//请求方式
            request.AddHeader("Content-Type", apiRequest.ContentType);//内容类型

            if (apiRequest.Parameters != null)
            {
                //SerializeObject 序列化对象为 Json 字符串
                request.AddParameter("param", JsonConvert.SerializeObject(apiRequest.Parameters),ParameterType.RequestBody);//添加请求参数
            }

            Client.BaseUrl = new Uri(baseUrl + apiRequest.Route);//设置请求地址
            var res = Client.Execute(request);//执行请求

            if (res.StatusCode == System.Net.HttpStatusCode.OK)//请求成功
            {
                //DeserializeObject 反序列化 Json 字符串为 对象
                return JsonConvert.DeserializeObject<ApiRespense>(res.Content);//反序列化返回数据
            }
            else
            {
                return new ApiRespense
                {
                    ResultCode = -99,
                    Msg = "客户端忙！"
                  
                };
            }
        }

    }
}
