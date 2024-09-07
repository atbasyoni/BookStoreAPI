using Autofac;
using AutoMapper;
using BookStore.Core.Features.Books.Commands;
using BookStore.Core.Features.Books.Validators;
using BookStore.Infrastructure.Context;
using BookStore.Infrastructure.Repositories;
using FluentValidation;
using MediatR;

namespace BookStore.API
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<ApplicationDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<Mapper>().As<IMapper>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(AddBookCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(AddBookCommandValidator).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();
        }
    }
}
