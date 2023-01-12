using System;
using System.Net;
using System.Net.Sockets;

namespace SLServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ıPAddress = IPAddress.Parse("127.0.0.1");
            TcpListener serverSocket = new TcpListener(ıPAddress, 600);
            TcpClient clientSocket = default(TcpClient);
            serverSocket.Start();
            Console.WriteLine(" *****SERVER HAZIR******");
            Console.WriteLine("Client Bekleniyor...");
            clientSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("Client ile bağlantı sağlandı....");

            while (true)
            {
                try
                {
                    NetworkStream networkStream = clientSocket.GetStream();
                    byte[] bytesFrom = new byte[1024];
                    if (networkStream.DataAvailable)
                    {
                        networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                        string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                        dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf('\0'));
                        Console.WriteLine("Gelen kutusu :" + dataFromClient);
                        Console.WriteLine(DateTime.Now);
                        networkStream.Flush();

                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
