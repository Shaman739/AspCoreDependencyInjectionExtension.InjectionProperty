using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspCoreDependencyInjectionExtension.InjectionProperty
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InjectionPropertyFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var properties = context.Controller.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
                    x.GetCustomAttributes(typeof(InjectionServiceAttribute), true).Any());

            var propertiesWithOnlyNullValue = properties.Where(x => x.GetValue(context.Controller) == null);

            foreach (var propertyForInject in propertiesWithOnlyNullValue)
            {
                var service = context.HttpContext.RequestServices.GetService(propertyForInject.PropertyType);
                propertyForInject.SetValue(context.Controller, service);
            }

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
