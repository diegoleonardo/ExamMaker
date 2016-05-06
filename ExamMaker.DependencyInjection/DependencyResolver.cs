using ExamMaker.Business.Services;
using ExamMaker.Core.Interfaces.Repositories;
using ExamMaker.Core.Interfaces.Services;
using ExamMaker.Data.Context;
using ExamMaker.Data.Repository;
using Microsoft.Practices.Unity;

namespace ExamMaker.DependencyInjection {
    public static class DependencyResolver {
        public static void Resolve(UnityContainer container) {
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IAppraiserRepository, AppraiserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAppraiserService, AppraiserService>(new HierarchicalLifetimeManager());
        }
    }
}
