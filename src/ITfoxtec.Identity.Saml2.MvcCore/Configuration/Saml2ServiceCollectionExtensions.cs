using ITfoxtec.Identity.Saml2.Schemas;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ITfoxtec.Identity.Saml2.MvcCore.Configuration
{
    public static class Saml2ServiceCollectionExtensions
    {
        /// <summary>
        /// Add SAML 2.0 configuration.
        /// </summary>
        public static IServiceCollection AddSaml2(this IServiceCollection services, Saml2Configuration configuration)
        {
            return AddSaml2(services, configuration, options =>
            {
                options.LoginPath = "/Auth/Login";
                options.LogoutPath = "/Auth/Login";
            });
        }

        public static IServiceCollection AddSaml2(this IServiceCollection services, Saml2Configuration configuration, Action<CookieAuthenticationOptions> configureOptions)
        {
            services.AddSingleton(configuration);

            Saml2Constants.AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            services.AddAuthentication(Saml2Constants.AuthenticationScheme).AddCookie(configureOptions);

            return services;
        }
    }
}
