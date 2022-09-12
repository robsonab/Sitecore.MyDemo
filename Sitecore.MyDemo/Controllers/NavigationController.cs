using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.MyDemo.Extensions;
using Sitecore.MyDemo.ViewModel.PageHeader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.MyDemo.Controllers
{
    public class NavigationController : Controller
    {
        private const string Generic_Page = "Generic Page";

        // GET: Navigation
        public ActionResult Index()
        {
            var homeItem = Context.Site.HomeItem();
            var navigations = new List<Navigation> { BuildNavigation(homeItem) };

            var children = homeItem.Children
                                    .Where(item => item.TemplateName == Generic_Page)
                                    .Select(item => BuildNavigation(item));
            navigations.AddRange(children);
            navigations = navigations
                            .Where(c => c.HideInNavigation == false)
                            .ToList();

            return View(new NavigationViewModel { Navigations = navigations });
        }

        private Navigation BuildNavigation(Item item) =>
                 new Navigation
                 {
                     NavigationTitle = item.Fields["Navigation_Title"]?.Value,
                     NavigationLink = item.Url(),
                     HideInNavigation = item.Fields["Hide_in_Navigation"] == null ? false : ((CheckboxField)item.Fields["Hide_in_Navigation"]).Checked,
                     ActiveClass = PageContext.Current.Item.ID == item.ID ? "active" : string.Empty
                 };

    }
}