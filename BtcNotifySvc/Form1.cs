using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

using WebSocket4Net;
using Newtonsoft.Json;
using BitCoinSharp.Store;
using BitCoinSharp;
using System.Diagnostics;
using System.Web;

namespace BtcNotifySvc
{
    public partial class Form1 : Form
    {
        const int logbufferlength = 100000;
        const string savefilename = "notifies.txt";
        const string defaulturl = "http://localhost:29684/notify/";
        string nodeip = "127.0.0.1";
        int nodeport = 8333;

        //WebSocket socket { get; set; }
        SortableBindingList<NotifyEntry> Notifies;
        PipeServer pipeserver = null;
        BackgroundWorker bgw = new BackgroundWorker();
        Dictionary<string, NotifyEntry> notifyLookup { get; set; }
        TextWriter _writer = null;
        Peer BitcoinClient = null;
        DateTime? ConnectTime = null;
        int txs = 0;
        decimal btcsent = 0;
        List<int> txCntList = new List<int>();
        List<decimal> btcSentCntList = new List<decimal>();
        int timerCnt = 0;
        bool stopReq = false;
        bool autoConnect = false;
        DateTime? lastTxTime = null;

        public Form1(bool autoconnect)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            autoConnect = autoconnect;
            InitializeComponent();
            statusStrip1.Padding = new Padding(statusStrip1.Padding.Left,
    statusStrip1.Padding.Top, statusStrip1.Padding.Left, statusStrip1.Padding.Bottom);

            Notifies = new SortableBindingList<NotifyEntry>();
            notifyLookup = new Dictionary<string, NotifyEntry>();
            
            if (File.Exists(savefilename))
            {
                foreach (string line in File.ReadAllLines(savefilename))
                {
                    if (line.Contains(","))
                    {
                        string[] split = line.Split(new char[] { ',' });
                        NotifyEntry ne = new NotifyEntry() { Id = split[0], Addr = split[1]};
                        if (split.Length >= 3)
                            ne.Url = split[2];
                        if (split.Length == 4)
                            ne.Added = DateTime.Parse(split[3]);
                        else
                            ne.Added = DateTime.Now;
                        Notifies.Add(ne);
                        notifyLookup.Add(split[1], ne);
                    }
                }
            }
            dataGridView1.DataSource = Notifies;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            bgw.DoWork += bgw_DoWork;

            notifyIcon1.Text = "Not started.";
        }

        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            pipeserver = new PipeServer();
            pipeserver.ServerLogEvent += pipeserver_ServerLogEvent;
            pipeserver.DataReceivedEvent += pipeserver_DataReceivedEvent;
            pipeserver.Start();
        }

        void ParseData(string data)
        {
            if (data.Contains(','))
            {
                string[] split = data.Split(new char[] { ',' });
                if (split.Length >= 2 && split[1].Length > 0 && split[1][0] == '1')
                {
                    if (split.Length == 2)
                    {
                        AddNotify(split[1], null, split[0]);
                    }
                    else if (split.Length == 3)
                        if (!split[2].StartsWith("http"))
                            LogText("ERROR: Invalid notify URL: " + split[2]);
                        else
                            AddNotify(split[1], split[2], split[0]);
                }
                else
                    LogText("ERROR: Invalid Bitcoin Address: " + data);
            }
            else
                LogText("ERROR: Parsing data " + data);
        }

        void pipeserver_DataReceivedEvent(object sender, EventArgs e)
        {
            string data = sender as string;
            LogText("PIPE DATA RECEIVED: " + data);
            ParseData(data);
        }

        void pipeserver_ServerLogEvent(object sender, EventArgs e)
        {
            LogText("PIPE SERVER: " + sender as string);
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            stopReq = false;
            if (!bgw.IsBusy)
                bgw.RunWorkerAsync();
            DoConnect();
        }
        private void starting()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(delegate () { starting(); }));
            else
            {
                notifyIcon1.Text = "Starting...";
                startBtn.Enabled = false;
                stopBtn.Enabled = true;
                string[] node = nodeTXT.Text.Split(new char[] { ':' }, StringSplitOptions.None);
                if (node.Length != 2)
                    throw new Exception("Node must be in format IP:Port");
                else
                {
                    nodeip = node[0];
                    nodeport = int.Parse(node[1]);
                }
            }
        }
        private void stopping()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(delegate () { stopping(); }));
            else
            {
                notifyIcon1.Text = "Disconnected.";
                txPB.Value = 0;
                btcPB.Value = 0;
                startBtn.Enabled = true;
                stopBtn.Enabled = false;
                transLogTxt.Clear();
                LogTrans("Disconnected.");
                ConnectTime = null;
                
            }
        }

        private void DoConnect()
        {
            

            new Thread(new ThreadStart(() =>
            {
                try
                {
                    try
                    {
                        if (BitcoinClient != null)
                            BitcoinClient.Disconnect();
                    }
                    catch { }

                    var @params = NetworkParameters.ProdNet();

                    using (var blockStore = new MemoryBlockStore(@params))
                    {
                        try
                        {
                            starting();
                            var chain = new BlockChain(@params, blockStore);
                            var host = new PeerAddress(IPAddress.Parse(nodeip), nodeport);

                            BitcoinClient = new Peer(@params, host, chain);

                            LogText("Connecting to node " + host);


                            BitcoinClient.Connect();

                            LogText("Connected!");
                            BitcoinClient.OnTransactionEvent += WatchTrans;
                            BitcoinClient.OnUnknownMessageEvent += WatchUnknown;
                            BitcoinClient.OnDisconnect += Disc;
                            ConnectTime = DateTime.Now;


                            BitcoinClient.Run();
                        }
                        catch (Exception err)
                        {
                            if (!stopReq)
                            {
                                try
                                {
                                    LogText("BTC CLIENT ERROR: " + err.Message + Environment.NewLine + Environment.NewLine + err.StackTrace);
                                }
                                catch { }
                                RestartApp("DoConnect Error");
                            }

                        }

                    }

                }
                catch (Exception err)
                {
                    LogText("START ERROR: " + err.Message + Environment.NewLine + Environment.NewLine + err.StackTrace);
                }

                
            }))
            {
                IsBackground = true
            }.Start();
        }

        private void Disc(Peer peer)
        {
            LogText("Disconnected from peer");
            peer.OnTransactionEvent -= WatchTrans;
            peer.OnUnknownMessageEvent -= WatchUnknown;
            peer.OnDisconnect -= Disc;
            stopping();

            if (!stopReq)
                RestartApp("Bad Disconnect");

        }

        private void faketxBTN_Click(object sender, EventArgs e)
        {
     
            t = BitCoinSharp.Collections.Generic.Tuple.New<string, ulong>(faketxAddr.Text, (ulong)Convert.ToUInt64(faketxNUD.Value * 100000000));
            
        }
        BitCoinSharp.Collections.Generic.Tuple<string, ulong> t = null;
        private void WatchTrans(Transaction tx)
        {
            try
            {
                if (string.IsNullOrEmpty(tx.HashAsString) || tx.Outputs.Count == 0)
                    return;
                var balances = tx.GetOutputBalances().ToList();
                if (balances.Count() == 0)
                    return;
                if (t != null)
                    balances.Add(t);
                txs++;

                LogTrans("________________________________________________________________");
                LogTrans(tx.HashAsString);
                LogTrans("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
                
                foreach (var tuple in balances)
                {
                    LogTrans("+ " + tuple.First + "    " + tuple.Second.SatoshiToBtc());

                    btcsent += tuple.Second.SatoshiToBtc();

                    if (!string.IsNullOrEmpty(tuple.First) && notifyLookup.ContainsKey(tuple.First))
                    {
                        NotifyEntry ne = notifyLookup[tuple.First];
                        string url = HttpUtility.HtmlDecode(ne.Url).Replace("{btc}", tuple.Second.SatoshiToBtc().ToString().Replace("{txid}",tx.HashAsString));
                        LogText("CALLING NOTIFY: " + ne.Addr + " with " + tuple.Second.SatoshiToBtc() +" BTC:  " + url);

                        WebClient wc = new WebClient();

                        string resp = wc.DownloadString(url);
                        LogText("Callback response: " + resp);
                        if (resp.StartsWith("PAID"))
                            RemoveNotify(tuple.First);
                    }

                }
                t = null;
                LogTrans("", true);
                //foreach (string faddr in tx.GetInputAddresses())
                //{
                //    LogTrans("- " + faddr);
                //}

            }
            catch (Exception err)
            {
                LogText("TRANSACTION ERROR: " + err.Message + Environment.NewLine + Environment.NewLine + err.StackTrace);
            }
        }

        private void WatchUnknown(BitCoinSharp.Message msg)
        {
            LogTrans("Got unknown message!");
            LogTrans(msg.ToString());
        }


        //void socket_MessageReceived(object sender, MessageReceivedEventArgs e)
        //{
        //    BlockChainMessage tx = JsonConvert.DeserializeObject<BlockChainMessage>(e.Message);
        //    foreach (BtcTxOut txout in tx.x.@out)
        //    {
        //        LogText(txout.addr + " - " + txout.value.SatoshiToBtc());
        //        if (notifyLookup.ContainsKey(txout.addr))
        //        {
        //            NotifyEntry ne = notifyLookup[txout.addr];
        //            WebClient wc = new WebClient();
        //            string resp = wc.DownloadString(ne.Url + ne.Id + "?addr=" + txout.addr + "&amount=" + txout.value.SatoshiToBtc());
        //            LogText("Callback response: " + resp);
        //            RemoveNotify(txout.addr);
        //        }
        //    }

        //    //LogText(tx.x.@out.Select(s => s.addr).ToArray().Delimit(",") + " - " + tx.x.@out.Sum(s => s.value.SatoshiToBtc()).ToString());
        //}

        void RemoveNotify(string addr)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(delegate() { RemoveNotify(addr); }));
            else
            {
                Notifies.Remove(notifyLookup[addr]);
                notifyLookup.Remove(addr);
                File.WriteAllLines(savefilename, Notifies.Select(s => s.Id + "," + s.Addr + "," + s.Url + "," + s.Added.ToString()).ToArray());
                LogText("Removed address " + addr + " from watch list");
            }
        }

        //void socket_Closed(object sender, EventArgs e)
        //{
        //    LogText("BLOCKCHAIN: Connection closed");
        //    Notifies.Clear();
        //    notifyLookup.Clear();
        //    OpenBlockchain();
        //}

        //void socket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        //{
        //    LogText("BLOCKCHAIN ERROR: " + e.Exception.Message);
        //}

        //void socket_Opened(object sender, EventArgs e)
        //{
        //    LogText("BLOCKCHAIN: Connection open");
        //    if (File.Exists(savefilename))
        //        foreach (string line in File.ReadAllLines("notifies.txt"))
        //            ParseData(line);
        //}

        void LogText(string txt)
        {
            if (logTxt.InvokeRequired)
                logTxt.Invoke(new Action(delegate() { LogText(txt); }));
            else
            {
                if (logTxt.TextLength > logbufferlength)
                {
                    logTxt.SuspendLayout();
                    logTxt.Select(0, logbufferlength);
                    logTxt.SelectedText = string.Empty;
                    logTxt.ScrollToCaret();
                    logTxt.ResumeLayout();
                }
                logTxt.AppendText(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ":    " + txt + Environment.NewLine);
            }
        }

        void LogTrans(string txt, bool blank = false)
        {
            if (transLogTxt.InvokeRequired)
                transLogTxt.Invoke(new Action(delegate() { LogTrans(txt, blank); }));
            else
            {
                if (transLogTxt.TextLength > logbufferlength)
                {
                    transLogTxt.SuspendLayout();
                    transLogTxt.Select(0, logbufferlength);
                    transLogTxt.SelectedText = string.Empty;
                    transLogTxt.ScrollToCaret();
                    transLogTxt.ResumeLayout();
                }
                if (blank)
                    transLogTxt.AppendText(Environment.NewLine);
                else
                    transLogTxt.AppendText(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ": " + txt + Environment.NewLine);
                lastTxTime = DateTime.Now;
                notifyIcon1.SetNotifyIconText(connectedTimeLBL.Text + Environment.NewLine
                    + txpersecLBL.Text + Environment.NewLine
                    + "Last TX: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + Environment.NewLine
                    + "Notifys: " + Notifies.Count);
            }
        }
        private void stopBtn_Click(object sender, EventArgs e)
        {
            try
            {
                stopReq = true;
                stopping();
                //if (pipeserver != null)
                //{
                //    LogText("Closing pipe...");
                //    pipeserver.ServerLogEvent -= pipeserver_ServerLogEvent;
                //    pipeserver.DataReceivedEvent -= pipeserver_DataReceivedEvent;
                //    pipeserver = null;
                //}
                if (BitcoinClient != null)
                {
                    LogText("Disconnecting...");
                    BitcoinClient.Disconnect();
                    BitcoinClient.OnTransactionEvent -= WatchTrans;
                    BitcoinClient.OnUnknownMessageEvent -= WatchUnknown;
                    BitcoinClient.OnDisconnect -= Disc;
                    
                    BitcoinClient = null;
                }
                //stopReq = false;
            }
            catch (Exception err)
            {
                LogText("Stop Error: " + err.Message + Environment.NewLine + err.StackTrace);
            }
        }

        private void sendrawBtn_Click(object sender, EventArgs e)
        {
            //socket.Send(sendRawTxt.Text);
            //logTxt.AppendText(sendRawTxt.Text + Environment.NewLine);
            //sendRawTxt.Clear();
            try
            {
                if (!PipeServer.running)
                {
                    LogText("Pipe server not running");
                    return;
                }
                PipeServer.SendData(sendRawTxt.Text);
            }
            catch (Exception err) { LogText("ERROR: " + err.Message + Environment.NewLine + err.StackTrace); }
        }

        void AddNotify(string address, string callback, string id)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(delegate() { AddNotify(address, callback, id); }));
            else
            {
                if (!notifyLookup.ContainsKey(address))
                {
                    //string submsg = "{\"op\":\"addr_sub\", \"addr\":\"" + address + "\"}";
                    NotifyEntry ne = new NotifyEntry()
                    {
                        Added = DateTime.Now,
                        Addr = address,
                        Url = callback ?? defaulturl,
                        Id = id
                    };

                    Notifies.Add(ne);
                    notifyLookup.Add(address, ne);
                    File.WriteAllLines(savefilename, Notifies.Select(s => s.Id + "," + s.Addr + "," + s.Url + "," + s.Added.ToString()).ToArray());
                    //socket.Send(submsg);
                    LogText("Added notify for address " + address + " with ID: " + id);
                }
                else
                    LogText("ERROR: Already watching bitcoin address " + address);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopBtn_Click(null, null);
            
            //File.WriteAllLines(savefilename, Notifies.Select(s => s.Id + "," + s.Addr + "," + s.Url).ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _writer = new TextBoxStreamWriter(transLogTxt);
            // Redirect the out Console stream
            Console.SetOut(_writer);

            Console.WriteLine("Now redirecting output to the text box");
            
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                this.Hide();
            
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.Visible)
                this.Hide();
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Focus();
            }
        }

        void RestartApp(string reason)
        {
            try
            {
                Directory.CreateDirectory("logs");
                File.WriteAllLines("logs/" + "BtcNotify_Crash_(" + reason + ")_" + DateTime.Now.Ticks + ".txt", logTxt.Lines);
            }
            catch { }
            Application.Restart();
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string exe = Process.GetCurrentProcess().ProcessName;
            PerformanceCounter process_cpu = new PerformanceCounter("Process", "% Processor Time", exe);
            float cpu = process_cpu.NextValue();
            bool oldtx = lastTxTime.HasValue && lastTxTime.Value.AddMinutes(5) < DateTime.Now;

            if (oldtx || cpu >= 16)
                RestartApp(oldtx ? "[OldTXs]" : "" + "CPU" + cpu + "%");
            

            if (ConnectTime.HasValue)
            {
                TimeSpan span = DateTime.Now - ConnectTime.Value;
                connectedTimeLBL.Text = "Connected: "
                    + (span.Days > 0 ? span.Days + "d " : "")
                    + (span.Hours > 0 || span.Days > 0 ? span.Hours + "h " : "")
                    + (span.Minutes > 0 || span.Hours > 0 ? span.Minutes + "m " : "")
                    + span.Seconds + "s ";

                if (timerCnt == 1)
                {
                    txCntList.Add(txs);
                    btcSentCntList.Add(btcsent);
                    btcsent = 0;
                    txs = 0;
                }
                if (txCntList.Count > 10000)
                    txCntList.RemoveAt(0);
                if (btcSentCntList.Count > 360)
                    btcSentCntList.RemoveAt(0);

                decimal txps = (txCntList.Count > 0 ? Math.Round(txCntList.Sum() / (decimal)txCntList.Count, 2) : 0);
                decimal btcps = (btcSentCntList.Count > 0 ? Math.Round(btcSentCntList.Sum() / (decimal)btcSentCntList.Count, 4) : 0);

                if ((txps * 100M) > txPB.Maximum)
                    txPB.Maximum = (int)(txps * 100M).RoundTo(0);

                if ((btcps * 100M) > btcPB.Maximum)
                    btcPB.Maximum = (int)(btcps * 100M).RoundTo(0);


                txPB.Value = (int)(txps * 100M).RoundTo(0);
                txPB.ToolTipText = "TX/sec: " + txps + "/" + (txPB.Maximum / 100M);

                btcPB.Value = (int)(btcps * 100M).RoundTo(0);
                btcPB.ToolTipText = "BTC/sec: " + btcps + "/" + (btcPB.Maximum / 100M);

                txpersecLBL.Text = "TX/sec: " + txps;
                btcpersecLBL.Text = "BTC/sec: " + btcps;
            }
            else
            {
                connectedTimeLBL.Text = "Disconnected ";
                txpersecLBL.Text = "TX/sec: 0";
            }

            

            timerCnt = timerCnt == 0 ? 1 : 0;
        }



        private void notifyDeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete these entries?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    RemoveNotify(row.Cells[1].Value.ToString());
                }
            }
        }

        private void sendRawTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendrawBtn_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (autoConnect)
            {
                backgroundWorker1.DoWork += backgroundWorker1_DoWork;
                backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
                backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;
                backgroundWorker1.RunWorkerAsync();
                WindowState = FormWindowState.Minimized;
                this.Hide();
                
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LogText("Connecting in: " + e.ProgressPercentage);
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LogText("Starting...");
            startBtn_Click(null, null);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(5);
            Thread.Sleep(1000);
            backgroundWorker1.ReportProgress(4);
            Thread.Sleep(1000);
            backgroundWorker1.ReportProgress(3);
            Thread.Sleep(1000);
            backgroundWorker1.ReportProgress(2);
            Thread.Sleep(1000);
            backgroundWorker1.ReportProgress(1);
            Thread.Sleep(1000);
            backgroundWorker1.ReportProgress(0);
            throw new Exception("done");
        }


        private void autosaveCHKTOOL_CheckedChanged(object sender, EventArgs e)
        {
            if (!autosaveCHKTOOL.Checked)
            {
                //saveNotifiesCHK.Text = "Auto Save (off)";
                autosaveTOOL.Image = Properties.Resources.imageres_105;
                LogText("Notifies will not be saved to disk.");
            }
            else
            {
                //saveNotifiesCHK.Text = "Auto Save (on)";
                autosaveTOOL.Image = Properties.Resources.imageres_106;
                LogText("Notifies will be saved to " + savefilename);
            }
        }
    }
}
