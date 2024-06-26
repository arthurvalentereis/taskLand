using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TaskLand.API.Extensions
{
    public static class SwaggerDocExtension
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Thundercat roll",
                    Description = @"Let's build a little test to create task",
                    Version = "v1",
                });
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); 

                options.EnableAnnotations();
                options.OperationFilter<CustomOperationFilter>();
            });


            return services;
        }


        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskLand");
            });
            return app;
        }

        public class CustomOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                if (operation.Description == null)
                    return;

                operation.Extensions.Add("x-description", new OpenApiString(operation.Description));
            }
        }

    }
}
