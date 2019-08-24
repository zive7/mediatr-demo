using Company.Contracts;
using Company.Services;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire;
using Company.Entities.Storage;
using Company.Storage;
using Mediatr.Demo.Api.App_Start.Mediator;
using MediatR;
using Company.Entities.DomainEvents;
using Company.Services.DomainEventHandlers;
using Company.Entities.UnitOfWork;
using Company.Storage.Database.Context;
using Company.Storage.UnitOfWork;

namespace Mediatr.Demo.Api.Helpers
{
    public static class ApiConfig
    {
        internal static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>().InRequestAndBackgroundScope();
            kernel.Bind<ICompanyRepository>().To<CompanyRepository>().InRequestAndBackgroundScope();
            kernel.Bind<ICompanyService>().To<CompanyService>().InRequestAndBackgroundScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestAndBackgroundScope();
            kernel.Bind<IDbContext>().ToConstructor<DbContext>(x => new DbContext("MediatrDemoDb")).InRequestAndBackgroundScope();

            kernel.RegisterMediatorModule();

            kernel.RegisterDomainNotificationHandlers();

            // Web API
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Ninject.Web.WebApi.NinjectDependencyResolver(kernel);

        }

        /// <summary>
        /// Binds domain notification handlers
        /// </summary>
        /// <param name="kernel"></param>
        private static void RegisterDomainNotificationHandlers(this Ninject.Syntax.IBindingRoot kernel)
        {
            kernel.Bind(typeof(INotificationHandler<CompanyCreatedDomainEvent>)).To(typeof(CompanyCreatedDomainEventhandler)).WhenNotificationMatchesType<CompanyCreatedDomainEvent>();
        }

        public static Ninject.Syntax.IBindingNamedWithOrOnSyntax<T> InRequestAndBackgroundScope<T>(this Ninject.Syntax.IBindingWhenInNamedWithOrOnSyntax<T> syntax)
        {
            return syntax.InNamedOrBackgroundJobScope(context => GetScopeFromContext(context));
        }

        public static Ninject.Syntax.IBindingNamedWithOrOnSyntax<T> InRequestAndBackgroundOrThreadScope<T>(this Ninject.Syntax.IBindingWhenInNamedWithOrOnSyntax<T> syntax)
        {
            return syntax.InNamedOrBackgroundJobScope(context =>
            {
                var requestScope = GetScopeFromContext(context);
                if (requestScope == null)
                {
                    if (JobActivatorScope.Current == null)
                    {
                        return System.Threading.Thread.CurrentThread;
                    }
                    else
                    {
                        return JobActivatorScope.Current;
                    }
                }
                else
                {
                    return requestScope;
                }
            });
        }

        private static object GetScopeFromContext(Ninject.Activation.IContext context)
        {
            return context.Kernel.Components.GetAll<INinjectHttpApplicationPlugin>()
                                            .Select(c => c.GetRequestScope(context))
                                            .FirstOrDefault(s => s != null);
        }
    }
}