using System.Text;
using System.Text.Json;

namespace MyNamespace
{
    record Person(string Name, string Occupation);

    class Program
    {
        public static void MyHttpCaller(object obj)
        {
            var person = new Person("John Doe", "gardener");

            var json = JsonSerializer.Serialize(person);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();


            var url = "https://httpbin.org/post";

            var response = client.PostAsync(url, data);

            var result = response.Result.Content.ReadAsStringAsync();
            var statusCode = response.Result.StatusCode;
            result.Status
            Console.WriteLine(statusCode);

        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(MyHttpCaller));
            }
            Console.Read();
        }



    }
}
