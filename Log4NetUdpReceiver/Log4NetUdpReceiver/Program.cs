using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Log4NetUdpReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient;
            byte[] buffer;
            string loggingEvent;

            try
            {
                udpClient = new UdpClient(8080);

                while (true)
                {
                    buffer = udpClient.Receive(ref remoteEndPoint);
                    loggingEvent = System.Text.Encoding.ASCII.GetString(buffer);
                    Console.WriteLine(loggingEvent);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}
