using System;
using System.Collections.Generic;
using System.Text;
using DNNrocketAPI;
using DNNrocketAPI.Components;
using RocketDirectoryAPI.Components;
using Simplisity;

namespace RocketBlogAPI.Components
{
    public class Scheduler : SchedulerInterface
    {
        /// <summary>
        /// This is called by DNNrocketAPI.Components.RocketScheduler
        /// </summary>
        /// <param name="systemData"></param>
        /// <param name="rocketInterface"></param>
        public override void DoWork()
        {
            var portalList = PortalUtils.GetPortals();
            foreach (var portalId in portalList)
            {
                var portalCatalog = new PortalCatalogLimpet(portalId, DNNrocketUtils.GetCurrentCulture(), "rocketblogapi");
                if (portalCatalog.Active && (portalCatalog.SchedulerRunHours == 0 || (portalCatalog.LastSchedulerTime < CacheUtils.DateTimeNow().AddHours(portalCatalog.SchedulerRunHours * -1))))
                {
                    LogUtils.LogSystem("START RocketBlogAPI Scheduler, LastSchedulerTime: " + portalCatalog.LastSchedulerTime.ToString("O"));

                    var objCtrl = new DNNrocketController();

                    // Publish hidden articles on publishdate.
                    var catalogSettings = new CatalogSettingsLimpet(portalId, DNNrocketUtils.GetCurrentCulture(), "rocketblogapi");
                    if (catalogSettings.Info.GetXmlPropertyBool("genxml/checkbox/hidefuturedates"))
                    {
                        var l = objCtrl.GetList(portalId, -1, "rocketblogapiART", "and [XMLData].value('(genxml/checkbox/hidden)[1]','bit') = 1 and [XMLData].value('(genxml/checkbox/autopublish)[1]','bit') = 1", "", "", 0, 0, 0, 0, "RocketDirectoryAPI");
                        foreach (var sInfo in l)
                        {
                            var articleData = new ArticleLimpet(portalId, sInfo.ItemID, DNNrocketUtils.GetCurrentCulture(), "rocketblogapi");
                            if (articleData.Exists)
                            {
                                if (articleData.Info.GetXmlPropertyDate("genxml/textbox/publisheddate").Date <= CacheUtils.DateTimeNow().Date)
                                {
                                    articleData.Info.SetXmlProperty("genxml/checkbox/hidden", "false");
                                    articleData.Update();
                                    LogUtils.LogSystem("RocketBlogAPI Scheduler: Publish Article: " + articleData.ArticleId);
                                }
                            }
                        }
                    }
                    portalCatalog.LastSchedulerTime = CacheUtils.DateTimeNow();
                    portalCatalog.Update();
                    LogUtils.LogSystem("END RocketBlogAPI Scheduler, LastSchedulerTime: " + portalCatalog.LastSchedulerTime.ToString("O"));
                }
            }
        }
    }
}