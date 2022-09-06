using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Server_Business_For_You
{

    class Program
    {
          
        static string FindAnswer(string pac)
        {
            List<string> arr = new List<string>();
            string str = pac.Substring(2), result = "";
            Func_Server f1 = new Func_Server();
            result = f1.FuncSwich(pac[0], str);
            return result;
        }

        static void SaveLog(string ip, string mydate)
        {
            FileStream f = new FileStream("log.txt", FileMode.Append);//create file
            StreamWriter s = new StreamWriter(f);

            s.WriteLine(ip + " " + mydate);

            s.Close();
            f.Close();
        }
        static void Main(string[] args)
        {
            try
            {
                byte[] bytes = new byte[4046];
                int i;
                string data_input, data_output;
                List<string> arr = new List<string>();
                int port = 13000;// number port
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                Encoding hebrewEncoding = Encoding.GetEncoding("Windows-1255");
                TcpListener server = new TcpListener(localAddr, port);
                server.Start();

                while (true)
                {
                    Console.WriteLine("Waiting ... ");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected ... ");
                    Console.WriteLine(client.Client.RemoteEndPoint.ToString()); // ip client
                    Console.WriteLine(DateTime.Now.ToString());
                    SaveLog(client.Client.RemoteEndPoint.ToString(), DateTime.Now.ToString());

                    // resev from client
                    data_input = null;
                    NetworkStream stream = client.GetStream();// input data
                    i = stream.Read(bytes, 0, bytes.Length);  //number bytes
                   data_input = hebrewEncoding.GetString(bytes, 0, i); // convert data to string
                   
                    Console.WriteLine(data_input);
                    // send data


                    data_output = FindAnswer(data_input);
                 
                    byte[] msg = hebrewEncoding.GetBytes(data_output);
                    stream.Write(msg, 0, msg.Length); // send to client

                    client.Close();
                }
            }

            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            Console.ReadKey();
        }
    }
}
