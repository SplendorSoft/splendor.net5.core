using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using splendor.net5.core.implementers;
using splendor.net5.core.contracts;

namespace splendor.net5.core.tools.ioc
{
    public class AssemblyPath{
        public string AssemblyName { get; set; }
        public List<string> NameSpaces { get; set; }
    }
    public static class ServiceCollectionExtensions
    {

        public static void ScanAssemblies(this IServiceCollection services, List<AssemblyPath> assemblyPaths)
        {
            assemblyPaths.ForEach(ap => {
                Assembly assembly = Assembly.Load(ap.AssemblyName.Trim());
                ap.NameSpaces.ForEach(ns => {
                    IEnumerable<Type> types = assembly.GetTypes().Where(t => t.Namespace != null && t.Namespace.Equals(ns));
                    List<Type> repositoryTypes  = types.Where(t => 
                        t.GetInterfaces().Length > 0 &&
                        t.GetInterfaces().Any(i => i.Name.ToLower().StartsWith("irepository"))
                    ).ToList();

                    List<Type> serviceTypes  = types.Where(t => 
                        (
                            t.BaseType is not null &&
                            t.BaseType.BaseType is not null &&
                            t.BaseType.BaseType.Name.ToLower().Contains("service")
                        ) ||
                        (
                            t.BaseType is not null &&
                            t.BaseType.BaseType is null && 
                            t.BaseType.Name.ToLower().Contains("service")
                        )
                    ).ToList();

                    services.AddRepositories(repositoryTypes);
                    services.AddServices(serviceTypes);
                });
            });
        }

        public static void AddRepositories(this IServiceCollection services, List<Type> repositoryTypes)
        {
            repositoryTypes.ForEach(t =>
            {
                Type[] interfaces = t.GetInterfaces();
                foreach (Type interfaceType in interfaces)
                {
                    if(interfaceType.Name.ToLower().Contains("repository")
                    || interfaceType.Name.ToLower().Contains("irepository"))
                    {
                        services.AddTransient(interfaceType, t);
                    }
                }
            });
        }

        public static void AddServices(this IServiceCollection services, List<Type> serviceTypes)
        {
            serviceTypes.ForEach(t =>
            {
                services.AddTransient(t);
            });
        }

        public static void AddDefaultTracer(this IServiceCollection services)
        {
            services.AddSingleton<ITracer, DefaultTracer>();
        }

        public static void AddTransactionScope(this IServiceCollection services)
        {
            services.AddTransient<ITransaction, TSTransaction>();
        }
    }
}