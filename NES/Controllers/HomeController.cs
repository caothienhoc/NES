using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modals.DAO;

namespace NES.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //var modal = dao.ListAll();
            //var daoGiaTri = new DM_GiaTri_Dao();
            //ar _ListGiaTri = daoGiaTri.ListAll();
            //ViewBag.ListGiaTri = _ListGiaTri;
            return View();
        }
    }
}