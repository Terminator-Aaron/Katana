using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace _OwinHost
{
    public class AppCookieAuthProvider : CookieAuthenticationProvider
    {
        public override void ApplyRedirect(CookieApplyRedirectContext context)
        {
            base.ApplyRedirect(context);
        }

        public override void Exception(CookieExceptionContext context)
        {
            base.Exception(context);
        }
        public override void ResponseSignedIn(CookieResponseSignedInContext context)
        {
            base.ResponseSignedIn(context);
        }

        public override void ResponseSignIn(CookieResponseSignInContext context)
        {
            base.ResponseSignIn(context);
        }

        public override void ResponseSignOut(CookieResponseSignOutContext context)
        {
            base.ResponseSignOut(context);
        }
        public override Task ValidateIdentity(CookieValidateIdentityContext context)
        {
            return base.ValidateIdentity(context);
        }
    }
}