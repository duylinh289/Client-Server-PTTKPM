using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress IP = IPAddress.Parse("127.0.0.28");
            TcpListener listener = new TcpListener(IP, 5000);

            listener.Start();
            Console.WriteLine("Server started on " + listener.LocalEndpoint);
            Console.WriteLine("Waiting for a connection...");
            Socket socket = listener.AcceptSocket();
            Console.WriteLine("Connection received from " + socket.RemoteEndPoint);

            byte[] data = new byte[1024];
            socket.Receive(data);
            ASCIIEncoding encoding = new ASCIIEncoding();
            string str = encoding.GetString(data);

            socket.Send(encoding.GetBytes("Received: " + str));

            socket.Close();
            listener.Stop();
            Console.Read();
        }
    }
}
