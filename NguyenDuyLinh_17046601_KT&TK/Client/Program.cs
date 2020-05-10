using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.28", 5000);
            Stream stream = client.GetStream();
            Console.WriteLine("Connected!");
            Console.WriteLine("Enter what you want to send:");
            string str = Console.ReadLine();

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(str);
            stream.Write(data, 0, data.Length);

            data = new byte[1024];
            stream.Read(data, 0, 1024);
            Console.WriteLine(encoding.GetString(data));

            stream.Close();
            client.Close();
            Console.Read();
        }
    }
}
