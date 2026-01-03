namespace WebApplication.Net.Helpers
{
    public interface IActionLinkGenerator
    {
        string ActionLink(string action, string controller, object values);
    }
}