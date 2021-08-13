using Autofac;
using Business.Abstract;
using Business.Concrete;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConverterManager>().As<IConverterService>();
        }
    }
}
