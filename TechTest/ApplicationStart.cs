using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Web.Mvc;
using TechTest.Services;
using TechTest.Services.Interfaces;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace MentorDigital
{
    public class ApplicationStart : IApplicationEventHandler
    {

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var builder = new ContainerBuilder();

            //register all controllers found in your assembly
            builder.RegisterControllers(typeof(ApplicationStart).Assembly);

            //register umbraco MVC + webapi controllers used by the admin site
            builder.RegisterControllers(typeof(UmbracoApplication).Assembly);
            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);

            //add custom class to the container as Transient instance                                    
            builder.RegisterInstance(applicationContext.Services.ContentService).As<IContentService>();

            builder.RegisterType<ContactService>().As<IContactService>();
            builder.RegisterType<ConfigService>().As<IConfigService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }

        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }
    }
}