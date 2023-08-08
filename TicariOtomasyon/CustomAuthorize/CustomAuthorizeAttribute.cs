using DataAccessLayer.GenericRepository;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicariOtomasyon.CustomAuthorize
{
    public class CustomAuthorizeAttribute:AuthorizeAttribute
    {
        private readonly DapperGenericRepository _repository;

        
        private readonly string[] _roller;


        public CustomAuthorizeAttribute(params string[] roller)
        {
            _roller = roller;
            _repository = new DapperGenericRepository();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            if (httpContext.Session["ID"] != null)
            {

                int sid = (int)httpContext.Session["ID"];
                short saktif = (short)httpContext.Session["AKTIF"];


                
                foreach(var rol in _roller)
                {
                    string sql = "Select * from Kullanicilar where ID=@ID and ROL=@ROL and AKTIF=@AKTIF";

                    object parametreler = new
                    {
                        @ID = sid,
                        @ROL = rol,
                        @AKTIF = saktif

                    };
                    Kullanicilar user = _repository.QueryFirstOrDefault<Kullanicilar>(sql,parametreler);
                    if(user != null)
                    {
                    authorize = true;
                    }

                }
            }
            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}