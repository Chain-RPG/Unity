using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace SimpleSocket{
    public class SimpleSocketClass{

        public Socket socket = null;
        public IPEndPoint ipe = null;
        
        StreamReader reader;
        StreamWriter writer;

        public void send(string input) { 
            writer.WriteLine(input);
            writer.Flush();
        }

        public string read() { 
            return reader.ReadLine();
        }

        public SimpleSocketClass(string ip, int port){
            setIpe(ip, port);
            setSocket(ipe);
        }

        static void sendStr(IAsyncResult ar) {
        }

        public void setSocket(IPEndPoint ipe) {
            socket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            connnect(ipe);
        }

        public void connnect(IPEndPoint ipe) {
            socket.Connect(ipe);
            NetworkStream stream = new NetworkStream(socket);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
        }
        public Socket getSocket() {
            return socket;
        }
        public void setIpe(string ip, int port) {
            IPAddress address = IPAddress.Parse(ip);
            ipe = new IPEndPoint(address, port);
        }
        public IPEndPoint getIpe() {
            return ipe;
        }        
        public void close(string ip, int port) {
            socket.Close();
        }        
    }
}