using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace SistemaCuentas.Api.Extentions
{
    public class TrimStringsFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var argument in context.ActionArguments.Values)
            {
                if (argument == null) continue;

                var stringProperties = argument.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.PropertyType == typeof(string) && p.CanWrite);

                foreach (var prop in stringProperties)
                {
                    var currentValue = (string?)prop.GetValue(argument);
                    if (!string.IsNullOrWhiteSpace(currentValue))
                    {
                        prop.SetValue(argument, currentValue.Trim());
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
