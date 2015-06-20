using System.Reflection;
using System.Web.Mvc;
using TCBase.Saker.Core;
using TCBase.Saker.Core.IOC.Autofac.Mvc;

namespace WXSchool.Site.Mobile
{
    public class IocConfig
    {
        public static void RegisterIocContainer()
        {
            //var currentAssembly = Assembly.GetExecutingAssembly();
            //ClassFactory.RegisterAssemblies(Assembly.GetExecutingAssembly());
            ClassFactory.RegisterAssemblies(Assembly.Load("WXSchool.Dal"),
                Assembly.Load("WXSchool.Bll"), 
                Assembly.GetExecutingAssembly());
            DependencyResolver.SetResolver(new AutofacDependencyResolver(ClassFactory.GetContainer()));
        }
    }
}