using DataAccessLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicariOtomasyon.Loglama
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private readonly DapperGenericRepository _repository;

        public LogFilterAttribute()
        {
            _repository = new DapperGenericRepository();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controllerAdi = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionAdi = filterContext.ActionDescriptor.ActionName;
            var ipAdres = filterContext.HttpContext.Request.UserHostAddress;
            var tarih = filterContext.HttpContext.Timestamp;

            string guid = Guid.NewGuid().ToString();

            string sql = "Insert into Loglar (KAYITKODU,CONTROLLERADI,ACTIONADI,IPADRES,TARIH) values(@KAYITKODU,@CONTROLLERADI,@ACTIONADI,@IPADRES,@TARIH)";
            object parametreler = new
            {
                @KAYITKODU = guid,
                @CONTROLLERADI = controllerAdi,
                @ACTIONADI = actionAdi,
                @IPADRES= ipAdres,
                @TARIH=tarih
            };
            _repository.Execute(sql,parametreler);
            base.OnActionExecuted(filterContext);

        }
    }
}