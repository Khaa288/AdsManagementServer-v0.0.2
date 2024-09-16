using AdsManagement.BuildingBlocks.Application.Events;
using AdsManagement.BuildingBlocks.Infrastructure;
using AdsManagement.Modules.Auth.Application.Configuration.Commands;
using Autofac;
using MediatR;

namespace AdsManagement.Modules.Auth.Infrastructure.Configuration.Processing;

internal class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assemblies.Application)
                .AsClosedTypesOf(typeof(IDomainEventNotification<>))
                .InstancePerDependency()
                .FindConstructorsWith(new AllConstructorFinder());
            
            // Validation without result
            builder.RegisterGenericDecorator(
                typeof(ValidationCommandHandlerDecorator<>),
                typeof(ICommandHandler<>));
            
            // Validation with result
            builder.RegisterGenericDecorator(
                typeof(ValidationCommandHandlerWithResultDecorator<,>),
                typeof(ICommandHandler<,>));
            
            builder.RegisterGenericDecorator(
                typeof(UnitOfWorkCommandHandlerDecorator<>),
                typeof(ICommandHandler<>));

            builder.RegisterGenericDecorator(
                typeof(UnitOfWorkCommandHandlerWithResultDecorator<,>),
                typeof(ICommandHandler<,>));
        }
    }