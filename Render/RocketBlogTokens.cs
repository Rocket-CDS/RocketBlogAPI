using Simplisity;
using System;

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
