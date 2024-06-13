namespace Lumos.Infrastructure
{
    public class InputReader
    {
        public string ReadInputFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public string ReadInputFromConsole()
        {
            Console.WriteLine("Enter the text:");
            return Console.ReadLine();
        }
    }
}
