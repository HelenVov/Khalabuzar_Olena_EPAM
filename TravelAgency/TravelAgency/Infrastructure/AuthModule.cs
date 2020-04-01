using System;
using System.Web;
using System.Web.Mvc;
using TravelAgency.Authentication.Interfaces;

namespace TravelAgency.Infrastructure
{
    public class AuthModule : IHttpModule
        {
            public void Init(HttpApplication context)
            {
                context.AuthenticateRequest += Auth;
            }

            private void Auth(object sender, EventArgs e)
            {
                var app = sender as HttpApplication;
                var context = app.Context;

                var auth = DependencyResolver.Current.GetService<IAuthentication>();

                auth.Context = context;
                context.User = auth.CurrentUser;
            }

            public void Dispose()
            {
            }
        }
    }
