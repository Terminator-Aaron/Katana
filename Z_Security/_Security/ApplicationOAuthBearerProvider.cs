﻿using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace _Security
{
    public class ApplicationOAuthBearerProvider : OAuthBearerAuthenticationProvider
    {
        public override System.Threading.Tasks.Task RequestToken(OAuthRequestTokenContext context)
        {
            return base.RequestToken(context);
        }

        public override System.Threading.Tasks.Task ValidateIdentity(OAuthValidateIdentityContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (context.Ticket.Identity.Claims.Any(c => c.Issuer != ClaimsIdentity.DefaultIssuer))
            {
                context.Rejected();
            }
            return Task.FromResult<object>(null);
        }
    }
}