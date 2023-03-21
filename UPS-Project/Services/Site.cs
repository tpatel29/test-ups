namespace UPS_Project.Services;

public class Site
{
    public string LOE { get; set; } = "";
    public string Host { get; set; } = "";
    public string active_started { get; set; } = "";
    public string created { get; set; } = "";
    public IEnumerable<MailBox> Mailboxes { get; set; }
}
