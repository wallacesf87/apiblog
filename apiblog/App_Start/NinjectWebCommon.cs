[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(apiblog.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(apiblog.App_Start.NinjectWebCommon), "Stop")]

namespace apiblog.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject.Web.Common;
    using Ninject;
    using System;
    using System.Web;

    using apiblog.Factories;
    using apiblog.Interfaces;    

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {           
            kernel.Bind<IContext>().To<ContextEntityFactory>();
            kernel.Bind<IPessoaService>().To<PessoaServiceFactory>();
            kernel.Bind<ILembreteService>().To<LembreteServiceFactory>();
            
            kernel.Bind(typeof(IGenericService<>)).To(typeof(GenericServiceFactory<>));
            //.WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString)
            //.WithConstructorArgument("timeout", 10000); ;            
        }
    }
}
