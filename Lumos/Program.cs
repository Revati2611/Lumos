using Lumos.Infrastructure;
using Lumos.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var detector = host.Services.GetRequiredService<IPhoneNumberDetector>();
        var reader = new InputReader();

        string input = reader.ReadInputFromConsole();
        string phoneNumbers = detector.DetectPhoneNumbers(input);

        Console.WriteLine("Detected Phone Numbers:");
        //foreach (var phoneNumber in phoneNumbers)
        //{
            Console.WriteLine($"{phoneNumbers}");
        //}
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                services.AddTransient<IPhoneNumberDetector, PhoneNumberDetector>());
}