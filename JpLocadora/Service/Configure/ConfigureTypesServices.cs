using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Service
{
    public static class ConfigureTypesServices
    {
        public static void RegisterAllTypesBusiness(this IServiceCollection services)
        {
            var listaInfaces = Assembly.GetExecutingAssembly().GetTypes().Where(item => item.IsInterface);

            foreach (var item in listaInfaces.ToList())
            {
                var classes = item.GetTypeInfo().Assembly.GetTypes().Where(t => item.IsAssignableFrom(t) && !t.IsInterface).ToList();

                foreach (var i in classes)
                {
                    services.AddScoped(item, i);
                }
            }
        }
    }
}
