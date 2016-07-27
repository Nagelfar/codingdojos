using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Sender
    {
        private readonly IPEndPoint endpoint;
        private readonly UdpClient client;
        public Sender(string ip = "192.168.1.1", int port = 8000)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            endpoint = new IPEndPoint(ipAddress, port);

            client = new UdpClient(port)
            {
                MulticastLoopback = true
            };

            // client.JoinMulticastGroup(ipAddress);
        }

        public async Task send(string message)
        {
            Byte[] sendBytes = Encoding.ASCII.GetBytes(message);
            await client.SendAsync(sendBytes, sendBytes.Length, endpoint);
            Console.WriteLine(message);
        }


    }

    public class Program
    {
        public static async Task send_multicast(string message)
        {
            UdpClient c = new UdpClient(10102);
            Byte[] sendBytes = Encoding.ASCII.GetBytes(message);
            IPAddress m_GrpAddr = IPAddress.Parse("224.0.0.1");
            IPEndPoint ep = new IPEndPoint(m_GrpAddr, 10101);
            c.MulticastLoopback = true;
            c.JoinMulticastGroup(m_GrpAddr);
            await c.SendAsync(sendBytes, sendBytes.Length, ep);
            Console.WriteLine(message);
        }

        public static async Task<string> recv_multicast()
        {
            Console.WriteLine("was here");
            String strData = "";
            //String Ret = "";
            ASCIIEncoding ASCII = new ASCIIEncoding();
            UdpClient c = new UdpClient(10101);
            c.MulticastLoopback = true;

            // Establish the communication endpoint.
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 10101);
            IPAddress m_GrpAddr = IPAddress.Parse("224.0.0.1");

            c.JoinMulticastGroup(m_GrpAddr);
            var result = await c.ReceiveAsync();
            Byte[] data = result.Buffer;
            strData = ASCII.GetString(data);
            //Ret += strData + "\n";

            return strData;
        }

        public static IObservable<string> Results()
        {
            Console.WriteLine("was here");

            //String Ret = "";
            ASCIIEncoding ASCII = new ASCIIEncoding();
            UdpClient c = new UdpClient(8001);
            c.MulticastLoopback = true;

            // Establish the communication endpoint.
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 8000);
            IPAddress m_GrpAddr = IPAddress.Parse("224.0.0.1");

            // c.JoinMulticastGroup(endpoint.Address);

            var udpResult = Observable.FromAsync<UdpReceiveResult>(c.ReceiveAsync)
                .Repeat();//.DoWhile(() => true);
            return udpResult.Select(result =>
            {
                Byte[] data = result.Buffer;
                var strData = ASCII.GetString(data);
                return strData;
            });
        }

        public static void Main(string[] args)
        {
            var socket = new System.Net.Sockets.UdpClient(8001);
            
            socket.EnableBroadcast = true;
            socket.MulticastLoopback = true;


// Console.WriteLine()

            // socket.JoinMulticastGroup(IPAddress.Parse("192.168.1.1"));

//              IPAddress m_GrpAddr = IPAddress.Parse("192.168.1.1");
//             IPEndPoint ep = new IPEndPoint(m_GrpAddr, 8000);


//  Byte[] sendBytes = Encoding.ASCII.GetBytes("JOIN;Christian");
// socket.SendAsync(sendBytes,sendBytes.Length, ep).Wait();
            // Console.WriteLine(socket.Available);

            // var results = Results();
            // var multicastResult = recv_multicast();
            var sender = new Sender();
            var s = sender.send("JOIN;Christian");
            // var s = send_multicast("fooo ");

            // results.Subscribe(r => Console.WriteLine("result: " + r));
            Task.WaitAll(s);

            socket.ReceiveAsync().Wait();

            // sender.send("bar").Wait();
            // send_multicast("bar").Wait();
            // Console.Write(multicastResult.Result);

            int[] values = { 1, 2, 3, 4 };
            values.ToObservable()
                .Where(x => x > 2)
                .Subscribe(x => Console.WriteLine(x));

            Console.WriteLine("Hello World!");
            var line = Console.ReadLine();
            // sender.send(line).Wait();

            Console.ReadLine();
        }
    }
}
