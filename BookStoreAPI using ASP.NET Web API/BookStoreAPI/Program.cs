
using BookStoreApi.Models;
using BookStoreApi.Services;


namespace BookStoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<BookStoreDatabaseSettings>(
                builder.Configuration.GetSection("BookStoreDatabase"));

            builder.Services.AddSingleton<BooksService>();

            builder.Services.AddControllers()
            .AddJsonOptions(
            options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            var app = builder.Build();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
