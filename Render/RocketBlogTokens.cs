using DNNrocketAPI.Components;
using RazorEngine.Text;
using RocketDirectoryAPI.Components;
using Simplisity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RocketBlogAPI.Components
{
    public class RocketBlogAPITokens<T> : RocketDirectoryAPI.Components.RocketDirectoryAPITokens<T>
    {

        public DateTime monthStartDate;
        public DateTime monthEndDate;
        public DateTime calMonthStartDate;
        public DateTime articleEventStartDate;
        public DateTime articleEventEndDate;
        public string[] listUrlParams;
        public new string AssignDataModel(SimplisityRazor sModel)
        {
            base.AssignDataModel(sModel);


            return "";
        }

    }
}
