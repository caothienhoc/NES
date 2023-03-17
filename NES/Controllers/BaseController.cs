using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NES.Common;
using System.Web.Routing;
using System.Globalization;
using System.Threading;

namespace NES.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session[CommonConstants.CurrentCulture] != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Session[CommonConstants.CurrentCulture].ToString());
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session[CommonConstants.CurrentCulture].ToString());
            }
            else
            {
                Session[CommonConstants.CurrentCulture] = "vi";
                Thread.CurrentThread.CurrentCulture = new CultureInfo("vi");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi");
            }
        }

        public BaseController()
        {
            List<int> _listYear = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                _listYear.Add(DateTime.Now.Year - i);
            }
            ViewBag.ListYear = _listYear;
            int Nam = DateTime.Now.Year;
            if (CommonConstants.YearOfWork.ToString() != "")
            {
                Nam = CommonConstants.YearOfWork;
            }
            ViewBag.SelectYear = Nam;
        }
        public JsonResult getYear(int Nam)
        {
            string _error = "";
            try
            {
                CommonConstants.YearOfWork = Nam;
                return Json(new
                {
                    status = true,
                    error = "Succses"
                });
            }
            catch (Exception ex)
            {
                _error = ex.ToString();
                return Json(new
                {
                    status = false,
                    error = _error
                });
            }
        }
        // changing culture
        public ActionResult ChangeCulture(string ddlCulture, string returnUrl)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ddlCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlCulture);

            Session[CommonConstants.CurrentCulture] = ddlCulture;
            return Redirect(returnUrl);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}