using MediatR;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mediatr.Demo.Api.App_Start.Mediator
{
    public static class MediatorBindingExtensions
    {
        public static IBindingInNamedWithOrOnSyntax<object> WhenNotificationMatchesType<TNotification>(this IBindingWhenSyntax<object> syntax) where TNotification : INotification
        {
            return syntax.When(request => typeof(TNotification).IsAssignableFrom(request.Service.GenericTypeArguments.Single()));
        }
    }
}