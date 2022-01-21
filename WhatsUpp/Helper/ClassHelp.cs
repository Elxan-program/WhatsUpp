using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WhatsUpp.Model;
using WhatsUpp.View;

namespace WhatsUpp.Helper
{
	public class ClassHelp
	{
        public static TcpClient Client { get; set; }
        public static double[] CurrentLocation { get; set; } = new double[2];
        public static ChatUC chatusercontrol { get; set; }
        public static MainWindow mainWindow { get; set; }
        public static User User { get; set; }

        public static ObservableCollection<TcpClient> Clients { get; set; }
        public static Dictionary<TcpClient, User> clientDict;
        public ClassHelp()
        {
            User = new User();
        }
    }
}
