namespace JukeBox.Config
{
    public class ApiConfiguration
    {
        public string ApiBaseUrl { get; set; } = "localhost:5003";
        public string LoginPath { get; set; } = "/Auth/Login";
    }
}
