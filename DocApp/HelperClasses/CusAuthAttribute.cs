using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocApp.Models;
using System.Configuration;



namespace DocApp.HelperClasses
{
    public class CusAuthAttribute : AuthorizeAttribute
    {
        DoctorSearchEntities db = new DoctorSearchEntities();

        string role;

        List<string> Allroles = new List<string> { "User", "Doctor" };

        public new string Roles
        {
            get
            {
                return this.role;
            }
            set
            {
                this.role = value;
            }
        }




        //dynamic username = HttpContext.Current.Session["name"];


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }



            if (HttpContext.Current.Session["name"] != null)
            {
                //string dname = HttpContext.Current.Session["name"].ToString();


                if (Allroles.Contains(Roles))
                {

                    return true;

                }
                else {

                    return false;
                
                
                }
                



            }


            HttpContext.Current.Session["showerror"] = "NONE";

            return false;


        }




        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (OutputCacheAttribute.IsChildActionCacheActive(filterContext))
            {
                // If a child action cache block is active, we need to fail immediately, even if authorization
                // would have succeeded. The reason is that there's no way to hook a callback to rerun
                // authorization before the fragment is served from the cache, so we can't guarantee that this
                // filter will be re-run on subsequent requests.
                throw new InvalidOperationException();
            }

            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true)
                                     || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true);

            if (skipAuthorization)
            {
                return;
            }


            if (AuthorizeCore(filterContext.HttpContext) == false)
            {

                HandleUnauthorizedRequest(filterContext);

            }


        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

                filterContext.Result = new RedirectResult(ConfigurationManager.AppSettings["PermissionUrl"]);
            

        }
    }
}