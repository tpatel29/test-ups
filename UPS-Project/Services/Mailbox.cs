using System.Xml.Linq;

namespace UPS_Project.Services;

public class MailBox
{
    public string TYPE { get; set; } = "";
    public string NAME { get; set; } = "";
    public string CREATED { get; set; } = "";
    public int MSGHELD { get; set; } = -1;
    public int MSGSENT { get; set; } = -1;
    public int MSGRECD { get; set; } = -1;
    public string CONNECTED { get; set; } = "";
    public int MSGDISKHELD { get; set; } = -1;
    public int RMTMSGHELD { get; set; } = -1;

    public MailBox()
    {

    }
}