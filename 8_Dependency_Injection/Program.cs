using ASP.Net.Services;

// using Autofac.Extensions.DependencyInjection;
using ServicesContracts;

var builder = WebApplication.CreateBuilder(args);
// here we are telling the builder to use Autofac as the service provider factory.
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()); this line is important but somehow not working at this time, so we will use the below line instead of this line.

builder.Services.AddControllersWithViews();

// This is IOC (inversion of Control) it's a design pattern. which serve the principal, (don't call me, I will call you) 
// So this means IOC/DI container create and return the service 

builder.Services.Add(new ServiceDescriptor(
    // hare we are telling the Services (IOC) to give citiesSevcie object to every one who is asking for ICitiesServices. 

    typeof(ICitiesService),
    typeof(CitiesService),
    ServiceLifetime.Transient

    // A service lifetime is a way to define how long a service instance should be kept alive in the dependency injection container. There are three main types of service lifetimes in ASP.NET Core: Singleton, Scoped, and Transient.
    // Transient: A new instance of the service is created each time it is requested. This is useful for lightweight, stateless services that do not maintain any state between requests.

    // Scoped: A new instance of the service is created once per request. This is useful for services that need to maintain state within a single request, such as database contexts.

    //ServiceLifetime.Scoped

    // at one time only one instance of the service is created and shared across all requests. This is useful for services that need to maintain state across multiple requests, such as caching services.

    //ServiceLifetime.Singleton
    // Singleton: A single instance of the service is created and shared across all requests. This is useful for services that need to maintain state across multiple requests, such as caching services.


    ));
// we can do the same thing in a more simple way like this
//builder.Services.AddTransient<ICitiesService, CitiesService>();


// Autofac is an open-source dependency injection (DI) container for .NET applications. It provides a way to manage the creation and lifetime of objects and their dependencies, making it easier to build loosely coupled and maintainable applications. Autofac allows developers to register components, specify their dependencies, and resolve them at runtime, promoting the principles of inversion of control (IoC) and dependency injection (DI).

// configuring Autofac as the service provider factory
//builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
//{
//    containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency(); // method for per instance per dependency (transient)
//    containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope(); // method for every instance per lifetime scope (scoped)
//    containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().SingleInstance(); // method for single instance (singleton)

//});




var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
