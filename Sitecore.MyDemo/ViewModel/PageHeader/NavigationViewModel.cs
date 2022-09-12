﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.MyDemo.ViewModel.PageHeader
{
    public class NavigationViewModel
    {
        public List<Navigation> Navigations { get; set; }
    }

    public class Navigation
    {
        public string NavigationTitle { get; set; }
        public string NavigationLink { get; set; }
        public string ActiveClass { get; set; }
        public bool HideInNavigation { get; set; }
    }
}