namespace Aspire.Configuration
{
    public class ApplicationConfiguration
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string IocDbReadOnly { get; set; }
        public string IocDbReadWrite { get; set; }
    }
}
