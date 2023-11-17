using DNNrocketAPI.Components;
using RocketBlogAPI.Components;
using Simplisity;
using System;
using System.Collections.Generic;
using System.Text;
using RocketDirectoryAPI;
using RocketDirectoryAPI.Components;
using DNNrocketAPI.Interfaces;

namespace RocketBlogAPI.API
{
    public partial class StartConnect : IProcessCommand
    {
        public Dictionary<string, object> ProcessCommand(string paramCmd, SimplisityInfo systemInfo, SimplisityInfo interfaceInfo, SimplisityInfo postInfo, SimplisityInfo paramInfo, string langRequired = "")
        {
            paramCmd = paramCmd.Replace("rocketblogapi_", "rocketdirectoryapi_");
            systemInfo.SetXmlProperty("genxml/systemkey", "rocketblogapi");
            var catalogStartConnect = new RocketDirectoryAPI.API.StartConnect();
            return catalogStartConnect.ProcessCommand(paramCmd, systemInfo, interfaceInfo, postInfo, paramInfo, langRequired);
        }
    }

}
