using BookServiceGRPC;
using LibraryGRPC.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibraryGRPC.Provider
{
    public  static class GRPCConfig
    {
        public static IHostApplicationBuilder AddBookManagerService(this IHostApplicationBuilder builder)
        {
    
            //var  options=new BookManagerOption() { Url = url };
            //services.AddScoped<BookManagerOption>(x=>options);
            builder.Services.Configure<BookManagerOption>(
            builder.Configuration.GetSection("BookManagerOption"));  
            builder.Services.AddScoped<IBookManagerProvider, BookManagerProvider>();
            return builder;
        }


        public static IHostApplicationBuilder AddBookManagerService2(this IHostApplicationBuilder builder)
        {
           
            var options = builder.Configuration.GetSection("BookManagerOption").Get<BookManagerOption>();

            builder.Services.AddGrpcClient<Greeter.GreeterClient>(client =>
            {

                client.Address = new Uri(options.Url);
            });
            //var  options=new BookManagerOption() { Url = url };
            //services.AddScoped<BookManagerOption>(x=>options);
     
            builder.Services.AddScoped<IBookManagerProvider, BookManagerProvider2>();
            return builder;
        }

        //public static IHostApplicationBuilder UseGrpcBook(this IHostApplicationBuilder webApplication)
        //{
        //    webApplication.MapGrpcService<>
        //    return webApplication;
        //}
    }
}
