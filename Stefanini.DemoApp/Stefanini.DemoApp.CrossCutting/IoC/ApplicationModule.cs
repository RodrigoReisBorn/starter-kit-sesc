using Autofac;
using Autofac.Extras.DynamicProxy;
using FluentValidation;
using NHibernate;
using Stefanini.DemoApp.Domain.Entities;
using Stefanini.DemoApp.Domain.Repositories;
using Stefanini.DemoApp.Domain.Validations;
using Stefanini.Common;
using Stefanini.DemoApp.Infrastructure.Data.Repositories;
using Stefanini.Log.Interceptors;
using Stefanini.DemoApp.Domain.Business;
using Stefanini.DemoApp.Domain.Business.Interfaces;
using Stefanini.DemoApp.Application.Services;
using Stefanini.DemoApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Stefanini.DemoApp.Infrastructure.Data;
using Stefanini.Repository.EntityFramework.Interceptors;
using AutoMapper;
using Stefanini.DemoApp.Application;

namespace Stefanini.DemoApp.CrossCutting.IoC
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LogInterceptor>();
            builder.RegisterType<TransactionContextInterceptor>();

            builder.Register(c =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
                optionsBuilder.UseSqlServer($"Data Source={c.Resolve<EnviromentConfiguration>().GetValue("Database:Host")};Initial Catalog={c.Resolve<EnviromentConfiguration>().GetValue("Database:Database")};User ID={c.Resolve<EnviromentConfiguration>().GetValue("Database:User")};Password={c.Resolve<EnviromentConfiguration>().GetValue("Database:Password")}", providerOptions => providerOptions.CommandTimeout(60))
                              .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                return optionsBuilder.Options;
            });

            builder.RegisterType<ApplicationContext>().As<ApplicationContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<EnviromentConfiguration>().SingleInstance();
            builder.RegisterType<Notification>().As<INotification>().InstancePerLifetimeScope();

            // Configuro o auto mapper
            builder.Register(c =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new DomainToViewModelMappingProfile());
                    cfg.AddProfile(new ViewModelToDomainMappingProfile());
                });
                return config.CreateMapper();
            });


            builder.Register(c =>
            {
                ISessionFactory factory = c.Resolve<ISessionFactory>();
                return factory.OpenSession();
            }).SingleInstance();

            builder.RegisterType<AlunoService>().As<IAlunoService>().EnableInterfaceInterceptors().InterceptedBy(typeof(LogInterceptor), typeof(TransactionContextInterceptor));

            builder.RegisterType<AlunoBusiness>().As<IAlunoBusiness>().EnableInterfaceInterceptors().InterceptedBy(typeof(LogInterceptor));

            builder.RegisterType<AlunoValidation>().As<IValidator<Aluno>>();

            builder.RegisterType<AlunoRepository>().As<IAlunoRepository>().EnableInterfaceInterceptors().InterceptedBy(typeof(LogInterceptor));
        }
    }
}
