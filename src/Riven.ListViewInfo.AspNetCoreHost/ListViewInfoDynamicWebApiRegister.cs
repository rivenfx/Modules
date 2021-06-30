using Panda.DynamicWebApi;

using System;
using System.Collections.Generic;
using System.Text;

namespace Riven
{
    public static class ListViewInfoDynamicWebApiRegister
    {
        /// <summary>
        /// 启用 RivenListViewInfo Web API 模块
        /// </summary>
        /// <param name="options"></param>
        /// <param name="apiPrefix">api前缀，默认listview</param>
        /// <returns></returns>
        public static DynamicWebApiOptions UseRivenListViewInfo(this DynamicWebApiOptions options, string apiPrefix = "listview")
        {
            options.AddAssemblyOptions(typeof(RivenListViewInfoApplicationModule).Assembly, apiPrefix ?? "listview", "POST");
            return options;
        }
    }
}
