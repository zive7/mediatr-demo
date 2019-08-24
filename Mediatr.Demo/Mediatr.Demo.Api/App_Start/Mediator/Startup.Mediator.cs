using MediatR.Ninject;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mediatr.Demo.Api.App_Start.Mediator
{
    public static class StartupMediator
    {
        /// <summary>
        /// Binds the required MediaR services to the Ninject kernel
        /// </summary>
        /// <param name="kernel"></param>
        internal static void RegisterMediatorModule(this IKernel kernel)
        {
            kernel.BindMediatR();
        }
    }
}