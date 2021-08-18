using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Collections;

using BitCoinSharp.Store;
using BitCoinSharp.Examples;
using BitCoinSharp;

namespace TestForm
{
    public partial class Form1 : Form
    {
        int logbufferlength = 32767;
        Queue<PeerAddress> hostQueue { get; set; }
        TextWriter _writer = null;

        public Form1()
        {
            InitializeComponent();
            
        }

        void LogText(object obj) { LogText(obj.ToString()); }
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

        private void printPeersBtn_Click(object sender, EventArgs e)
        {
            Thread bg = new Thread(new ThreadStart(() =>
            {

                var @params = NetworkParameters.ProdNet();

                using (var blockStore = new MemoryBlockStore(@params))
                {
                    var chain = new BlockChain(@params, blockStore);
                    var host = new PeerAddress(IPAddress.Loopback, 8333);
                    var peer = new Peer(@params, host, chain);

                    //START:
                    //var host = hostQueue.Dequeue();
                    LogText("Connecting to node " + host);

                    //var peer = new Peer(@params, host, chain);

                    //try
                    //{
                    peer.Connect();
                    //}
                    //catch
                    //{
                    //    if (hostQueue.Peek() != null)
                    //        goto START;
                    //}

                    LogText("Connected!");
                    peer.OnTransactionEvent += WatchTrans;
                    peer.OnUnknownMessageEvent += WatchUnknown;
                    peer.OnDisconnect += Disc;

                    new Thread(peer.Run).Start();

                    //var blockHash = new Sha256Hash(blockHashTxt.Text);
                    //var future = peer.BeginGetBlock(blockHash, null, null);
                    //LogText("Waiting for node to send us the requested block: " + blockHash);
                    //var block = peer.EndGetBlock(future);
                    //LogText(block.ToString());
                    //peer.Disconnect();

                }
            }));
            bg.Start();
        }

        private void fetchBlockBtn_Click(object sender, EventArgs e)
        {
            //if (hostQueue == null)
            //    printPeersBtn_Click(null, null);
            //else
            //{
                Thread bg = new Thread(new ThreadStart(() =>
                {
                    
                    var @params = NetworkParameters.ProdNet();

                    using (var blockStore = new MemoryBlockStore(@params))
                    {
                        var chain = new BlockChain(@params, blockStore);
                        var host = new PeerAddress(IPAddress.Loopback, 8333);
                        var peer = new Peer(@params, host, chain);

                    //START:
                        //var host = hostQueue.Dequeue();
                        LogText("Connecting to node " + host);
                        
                        //var peer = new Peer(@params, host, chain);
                     
                        //try
                        //{
                            peer.Connect();
                        //}
                        //catch
                        //{
                        //    if (hostQueue.Peek() != null)
                        //        goto START;
                        //}

                            LogText("Connected!");
                        peer.OnTransactionEvent += WatchTrans;
                        peer.OnUnknownMessageEvent += WatchUnknown;
                        peer.OnDisconnect += Disc;

                        new Thread(peer.Run).Start();

                        //var blockHash = new Sha256Hash(blockHashTxt.Text);
                        //var future = peer.BeginGetBlock(blockHash, null, null);
                        //LogText("Waiting for node to send us the requested block: " + blockHash);
                        //var block = peer.EndGetBlock(future);
                        //LogText(block.ToString());
                        //peer.Disconnect();
                        
                    }
                }));
                bg.Start();
                
            //}
        }

        private void Disc(Peer peer)
        {
            peer.OnTransactionEvent -= WatchTrans;
            peer.OnUnknownMessageEvent -= WatchUnknown;
            peer.OnDisconnect -= Disc;
        }

        private void WatchTrans(Transaction tx)
        {
            LogText("Transaction!");
            //LogText(tx.ToString());
            foreach (var tuple in tx.GetOutputBalances())
                LogText(tuple.First + " " + new decimal(tuple.Second / (double)100000000).ToString() + " BTC");
        }

        private void WatchUnknown(BitCoinSharp.Message msg)
        {
            LogText("Unknown!");
            LogText(msg.ToString());
        }

        private void goBtn_Click(object se, EventArgs ea)
        {
            Thread bg = new Thread(new ThreadStart(() =>
                {

                    var @params = NetworkParameters.ProdNet();
                    var filePrefix = "pingservice-prodnet";

                    // Try to read the wallet from storage, create a new one if not possible.
                    Wallet wallet;
                    var walletFile = new FileInfo(filePrefix + ".wallet");
                    try
                    {
                        wallet = Wallet.LoadFromFile(walletFile);
                    }
                    catch (IOException)
                    {
                        wallet = new Wallet(@params);
                        wallet.Keychain.Add(new EcKey());
                        wallet.SaveToFile(walletFile);
                    }
                    // Fetch the first key in the wallet (should be the only key).
                    var key = wallet.Keychain[0];

                    LogText(wallet);

                    // Load the block chain, if there is one stored locally.
                    LogText("Reading block store from disk");
                    using (var blockStore = new BoundedOverheadBlockStore(@params, new FileInfo("custom.blockchain")))
                    {
                        // Connect to the localhost node. One minute timeout since we won't try any other peers
                        try
                        {
                            LogText("Connecting ...");
                        
                        var chain = new BlockChain(@params, wallet, blockStore);

                        var peerGroup = new PeerGroup(blockStore, @params, chain);
                        peerGroup.AddAddress(new PeerAddress(IPAddress.Loopback, 8333));
                        peerGroup.Start();
                        
                        // We want to know when the balance changes.
                        //wallet.CoinsReceived +=
                        //    (sender, e) =>
                        //    {
                        //        // Running on a peer thread.
                        //        Debug.Assert(!e.NewBalance.Equals(0));
                        //        // It's impossible to pick one specific identity that you receive coins from in BitCoin as there
                        //        // could be inputs from many addresses. So instead we just pick the first and assume they were all
                        //        // owned by the same person.
                        //        var input = e.Tx.Inputs[0];
                        //        var from = input.FromAddress;
                        //        var value = e.Tx.GetValueSentToMe(wallet);
                        //        LogText("Received " + Utils.BitcoinValueToFriendlyString(value) + " from " + from);
                        //        // Now send the coins back!
                        //        var sendTx = wallet.SendCoins(peerGroup, from, value);
                        //        Debug.Assert(sendTx != null); // We should never try to send more coins than we have!
                        //        LogText("Sent coins back! Transaction hash is " + sendTx.HashAsString);
                        //        wallet.SaveToFile(walletFile);
                        //    };

                        peerGroup.DownloadBlockChain();
                        //LogText("Send coins to: " + key.ToAddress(@params));
                        //LogText("Waiting for coins to arrive. Press Ctrl-C to quit.");
                        // The PeerGroup thread keeps us alive until something kills the process.

                        }
                        catch (Exception err)
                        {
                            LogText("ERROR: " + err.Message);
                            return;
                        }
                    }
                }));
            bg.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _writer = new TextBoxStreamWriter(logTxt);
            // Redirect the out Console stream
            Console.SetOut(_writer);

            Console.WriteLine("Now redirecting output to the text box");
        }
    }
}
