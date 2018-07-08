using System.Web.Http;
using Unity;
using Unity.WebApi;
using SMSInterface;
using SMSRepository;

namespace SMSApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAdminRepository, AdminRepository>();
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IClassRepository, ClassRepository>();
            container.RegisterType<ICourseRepository, CourseRepository>();
           

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}