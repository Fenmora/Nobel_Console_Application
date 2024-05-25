using System.Net.Http;
using System.Text.Json;

namespace Nobel_Console_Application.Services
{
	public class TopicsServices
	{

        public async Task<HashSet<string>> GetUniqueTopicsAsync(string url)
        {
            using HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            return ExtractUniqueTopics(response);
        }

        public HashSet<string> ExtractUniqueTopics(string jsonResponse)
        {
            var uniqueTopics = new HashSet<string>();

            var jsonDocument = JsonDocument.Parse(jsonResponse);
            if (jsonDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                foreach (var element in jsonDocument.RootElement.EnumerateArray())
                {
                    var topics = element.GetProperty("topics").EnumerateArray();
                    foreach (var topic in topics)
                    {
                        uniqueTopics.Add(topic.GetString());
                    }
                }
            }
            return uniqueTopics;
        }

        public void PrintUniqueTopics(HashSet<string> uniqueTopics)
        {
            Console.WriteLine("Unique Topics:");
            foreach (var topic in uniqueTopics)
            {
                Console.WriteLine(topic);
            }
        }
    }
}

