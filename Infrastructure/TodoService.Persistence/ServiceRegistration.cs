using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoService.Application.Repositories;
using TodoService.Persistence.Contexts;
using TodoService.Persistence.Repositories;

namespace TodoService.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoServiceContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("Default"),
                    b => b.MigrationsAssembly(typeof(TodoServiceContext).Assembly.FullName)));

            services.AddScoped<ITodoItemReadRepository, TodoItemReadRepository>();
            services.AddScoped<ITodoItemWriteRepository, TodoItemWriteRepository>();
        }
    }
}