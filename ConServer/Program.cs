using ConServer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConServer
{
    class Program
    {
        static void Main(string[] args)
        {

            int count = 1;


            TcpListener ServerSocket = new TcpListener(IPAddress.Parse(Connect.IpAdress), Connect.Port);
            ServerSocket.Start();

            while (true)
            {
                TcpClient client = ServerSocket.AcceptTcpClient();
                Connect.list_clients.Add(count, client);

                Console.WriteLine("Someone connected!!");
                count++;
                Box box = new Box(client, Connect.list_clients);

                Thread thread = new Thread(HandleClients);
                thread.Start(box);
            }

        }

        public static void HandleClients(object o)
        {
            Box box = (Box)o;
            Dictionary<int, TcpClient> list_connections = box.Dlist;

            while (true)
            {
                NetworkStream stream = box.Tc1.GetStream();
                byte[] buffer = new byte[1024];
                int byte_count = stream.Read(buffer, 0, buffer.Length);
                byte[] formated = new Byte[byte_count];

                Array.Copy(buffer, formated, byte_count);
                string data = Encoding.ASCII.GetString(formated);
                BroadCast(list_connections, data);

            }
        }

        public static void BroadCast(Dictionary<int, TcpClient> conexoes, string data)
        {
            Connect.list_clients = conexoes;

            foreach (TcpClient Tc in conexoes.Values)
            {
                NetworkStream Nstream = Tc.GetStream();
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                Nstream.Write(buffer, 0, buffer.Length);
            }
        }
    }
    class Box
    {
        public TcpClient Tc1;
        public Dictionary<int, TcpClient> Dlist;

        public Box(TcpClient c, Dictionary<int, TcpClient> list)
        {
            Tc1 = c;
            Dlist = list;
        }
    }
}
