using System;
using _Net_Core_IdentityServer4.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace _Net_Core_IdentityServer4.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, int userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(HomeController.ResetPassword),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }
    }
}
