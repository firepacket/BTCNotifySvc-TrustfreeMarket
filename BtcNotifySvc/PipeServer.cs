using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Security.Principal;
using System.Security.AccessControl;

namespace BtcNotifySvc
{
    public class PipeServer
    {
        private int numThreads = 4;
        public event EventHandler ServerLogEvent;
        public event EventHandler DataReceivedEvent;

        private const string pipename = "BTCNOTIFY";
        private const string banner = "BTCNOTIFY";

        public static bool running = false;
        public static void SendData(string message)
        {
            NamedPipeClientStream pipeClient =
                       new NamedPipeClientStream(".", pipename,
                           PipeDirection.InOut, PipeOptions.None,
                           TokenImpersonationLevel.Impersonation);

            //Console.WriteLine("Connecting to server...\n");
            pipeClient.Connect();

            StreamString ss = new StreamString(pipeClient);
            // Validate the server's signature string 
            if (ss.ReadString() == banner)
            {
                // The client security token is sent with the first write. 
                // Send the name of the file whose contents are returned 
                // by the server.
                ss.WriteString(message);

                // Print the file to the screen.
                //Console.Write(ss.ReadString());
            }
            else
            {
                //Console.WriteLine("Server could not be verified.");
            }
            pipeClient.Close();
        }
        
        public PipeServer()
        {
            
           
        }

        public void Start()
        {
            int i;
            Thread[] servers = new Thread[numThreads];
            running = true;
            if (ServerLogEvent != null)
            {
                ServerLogEvent("Opened pipe name: " + pipename + "\n", null);
                ServerLogEvent("Waiting for client connect...\n", null);
            }

            for (i = 0; i < numThreads; i++)
            {
                servers[i] = new Thread(ServerThread);
                servers[i].IsBackground = true;
                servers[i].Start();
            }
            Thread.Sleep(250);
            while (i > 0)
            {
                for (int j = 0; j < numThreads; j++)
                {
                    if (servers[j] != null)
                    {
                        if (servers[j].Join(250))
                        {
                            if (ServerLogEvent != null)
                                ServerLogEvent(string.Format("Server thread[{0}] finished.", servers[j].ManagedThreadId), null);

                            servers[j] = new Thread(ServerThread);
                            servers[j].IsBackground = true;
                            servers[j].Start();
                            //servers[j] = null;
                            //i--;    // decrement the thread watch count
                        }
                    }
                }
            }

            if (ServerLogEvent != null)
                ServerLogEvent("\nServer threads exhausted, exiting.", null);
        }

        private void ServerThread(object data)
        {
            PipeSecurity ps = new PipeSecurity();
            ps.AddAccessRule(new PipeAccessRule("Users", PipeAccessRights.ReadWrite, AccessControlType.Allow));
            ps.AddAccessRule(new PipeAccessRule(WindowsIdentity.GetCurrent().Owner, PipeAccessRights.FullControl, AccessControlType.Allow));

            NamedPipeServerStream pipeServer =
                new NamedPipeServerStream(pipename, PipeDirection.InOut, numThreads, PipeTransmissionMode.Message, PipeOptions.WriteThrough, 1024, 1024, ps );



            int threadId = Thread.CurrentThread.ManagedThreadId;

            // Wait for a client to connect
            pipeServer.WaitForConnection();

            

            try
            {
                new Thread(() => { ServerLogEvent?.Invoke(string.Format("Client connected on thread[{0}].", threadId), null); }).Start();
                // Read the request from the client. Once the client has 
                // written to the pipe its security token will be available.

                StreamString ss = new StreamString(pipeServer);

                // Verify our identity to the connected client using a 
                // string that the client anticipates.

                ss.WriteString(banner);

                string message = ss.ReadString();
                if (DataReceivedEvent != null)
                    DataReceivedEvent(message, null);


                //// Read in the contents of the file while impersonating the client.
                //ReadFileToStream fileReader = new ReadFileToStream(ss, filename);

                //// Display the name of the user we are impersonating.
                //Console.WriteLine("Reading file: {0} on thread[{1}] as user: {2}.",
                //    filename, threadId, pipeServer.GetImpersonationUserName());


                //pipeServer.RunAsClient(fileReader.Start);
            }
            // Catch the IOException that is raised if the pipe is broken 
            // or disconnected. 
            catch (IOException e)
            {
                if (ServerLogEvent != null)
                    ServerLogEvent(string.Format("ERROR: {0}", e.Message), null);
               
            }
            pipeServer.Close();
        }
    }

    // Defines the data protocol for reading and writing strings on our stream 
    public class StreamString
    {
        private Stream ioStream;
        private UnicodeEncoding streamEncoding;

        public StreamString(Stream ioStream)
        {
            this.ioStream = ioStream;
            streamEncoding = new UnicodeEncoding();
        }

        public string ReadString()
        {
            int len = 0;

            len = ioStream.ReadByte() * 256;
            len += ioStream.ReadByte();
            byte[] inBuffer = new byte[len];
            ioStream.Read(inBuffer, 0, len);

            return streamEncoding.GetString(inBuffer);
        }

        public int WriteString(string outString)
        {
            byte[] outBuffer = streamEncoding.GetBytes(outString);
            int len = outBuffer.Length;
            if (len > UInt16.MaxValue)
            {
                len = (int)UInt16.MaxValue;
            }
            ioStream.WriteByte((byte)(len / 256));
            ioStream.WriteByte((byte)(len & 255));
            ioStream.Write(outBuffer, 0, len);
            ioStream.Flush();

            return outBuffer.Length + 2;
        }
    }

    // Contains the method executed in the context of the impersonated user 
    public class ReadFileToStream
    {
        private string fn;
        private StreamString ss;

        public ReadFileToStream(StreamString str, string filename)
        {
            fn = filename;
            ss = str;
        }

        public void Start()
        {
            string contents = File.ReadAllText(fn);
            ss.WriteString(contents);
        }
    }
}