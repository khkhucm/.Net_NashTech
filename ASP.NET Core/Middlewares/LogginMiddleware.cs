using System.Diagnostics;
namespace ASP.NET_Core.Middlewares
{
    public class LogginMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public LogginMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            var respone = context.Response;

            string requestInfo = "Schema: " + request.Scheme +
            "\r\nHost: " + request.Host +
            "\r\nPath: " + request.Path +
            "\r\nQueryString: " + request.QueryString +
            "\r\nBody: " + request.Body;
            Debug.Write(requestInfo);
            WriteToFileByStream("./", "result.txt", requestInfo);
            //File.WriteAllText("./result.txt", requestInfo);
            
            await _requestDelegate(context);
        }

        public static void WriteToFileByStream(string directoryPath, string fileName, string text)
        {
            using (var fileStream = new FileStream(Path.Combine(directoryPath, fileName), FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(text);
                }
            }
        }
    }
}