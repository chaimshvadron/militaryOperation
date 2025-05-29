namespace MilitaryControlSystem
{
    public class Http
    {
        public class Part
        {
            public string text { get; set; }
        }

        public class Content
        {
            public List<Part> parts { get; set; }
        }

        public class GeminiRequest
        {
            public List<Content> contents { get; set; }
        }

        static public HttpClient BaseHttp()
        {
            HttpClient Client = new();
            Client.BaseAddress = new Uri("https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent/");
            return Client;
        }

        // public async Task<string> Connection()
        // {

        //     HttpClient Client = BaseHttp();
        //     HttpRequestMessage RequestMessage = await Client.PostAsync("", Message);

        //     return RequestMessage.ToString;
        // }
        
    }
    
}