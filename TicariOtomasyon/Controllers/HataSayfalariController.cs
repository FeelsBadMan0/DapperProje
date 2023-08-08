using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class HataSayfalariController : Controller
    {
        // GET: HataSayfalari
        public ActionResult Hata()
        {
            Response.StatusCode = 404;
            return View();
        }

        public ActionResult Hata500()
        {
            Response.StatusCode = 500;
            return View();
        }

        public ActionResult Hata401()
        {
            Response.StatusCode = 401;
            return View();
        }
    }
}