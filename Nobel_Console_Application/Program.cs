using System;
using System.Threading.Tasks;
using Nobel_Console_Application.Services;

namespace Nobel_Console_Application
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                TopicsServices topics = new TopicsServices();
                var url = "https://api.sampleapis.com/codingresources/codingResources";
                var uniqueTopics = await topics.GetUniqueTopicsAsync(url);
                topics.PrintUniqueTopics(uniqueTopics);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
