﻿using MassTransit;

namespace AdsManagement.Modules.Report.Infrastructure.Configuration.EventBus;

internal static class EventBusStartUp
{
    public static  IBusRegistrationConfigurator AddConsumers(this  IBusRegistrationConfigurator bus)
    {
        // // Add Consumer here
        // bus.AddConsumer(typeof(ConsumerType));

        return bus;
    }
}