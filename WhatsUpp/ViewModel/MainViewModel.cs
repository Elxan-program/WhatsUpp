using ConServer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using WhatsUpp.Command;
using WhatsUpp.Helper;
using WhatsUpp.View;

namespace WhatsUpp.ViewModel
{
	public class MainViewModel : BaseViewModel
	{
        public RelayCommand ConnectCommand { get; set; }
        public RelayCommand SearchClick { get; set; }
        public DispatcherTimer dispatcherTimer { get; set; } = new DispatcherTimer();
        public MainWindow MainWindow { get; set; }
        public string Path { get; set; }
        public MainViewModel(MainWindow mainWindow)
        {


            MainWindow = mainWindow;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100);
            ClassHelp.mainWindow = mainWindow;

            SearchClick = new RelayCommand((sender) =>
            {

                UserListUserControl userListUserControl = new UserListUserControl();
                mainWindow.MainGrid.Children.Add(userListUserControl);

            });
            ConnectCommand = new RelayCommand((sender) =>
            {
                ChatUC chatUserControl = new ChatUC();
                mainWindow.MainGrid.Children.Add(chatUserControl);
                mainWindow.MainGrid.Children.RemoveAt(0);
                TcpClient client = new TcpClient();
                client.Connect(Connect.IpAdress, Connect.Port);
                ClassHelp.Client = client;
            });
        }
        private void ReceiveData(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                var msg = Encoding.ASCII.GetString(receivedBytes, 0, byte_count);
            }
        }
    }
}
