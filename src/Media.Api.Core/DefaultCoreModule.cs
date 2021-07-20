using Autofac;
using Media.Api.Core.Interfaces;
using Media.Api.Core.Services;

namespace Media.Api.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ToDoItemSearchService>()
                .As<IToDoItemSearchService>().InstancePerLifetimeScope();
        }
    }
}
