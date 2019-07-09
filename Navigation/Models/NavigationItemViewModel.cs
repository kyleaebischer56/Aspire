namespace Aspire.Navigation.Models
{
    public class NavigationItemViewModel
    {
        public NavigationItemViewModel(string name, string targetUrl)
        {
            Name = name;
            TargetUrl = targetUrl;
        }

        public string Name { get; private set; }
        public string TargetUrl { get; private set; }
    }
}
