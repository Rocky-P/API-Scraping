using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LakewoodScoop;
using _3._9apiScraping.Models;

namespace _3._9apiScraping.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Data d = new Data();
            GetInfo info = new GetInfo();
            IEnumerable<Data> data= info.GetStories();
            ViewModel vm = new ViewModel();
            vm.allData = data;
            return View(vm);
        }

    }
}
