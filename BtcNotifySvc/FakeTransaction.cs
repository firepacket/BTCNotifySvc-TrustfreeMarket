using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitCoinSharp;

namespace BtcNotifySvc
{
    public class FakeTransaction : Transaction
    {
        string h = "abcdef1234567890";
        public new string HashAsString = "fake";
        
        public new List<TransactionOutput> Outputs;
        string addr;
        ulong amnt;
        decimal btc;

        public FakeTransaction(string addr, decimal btc) : base(new NetworkParameters() { ProofOfWorkLimit = new Org.BouncyCastle.Math.BigInteger("SSDS") }, new byte[] { 0x00, 0xa2, 0xae, 0x67 })
        {
            Random r = new Random();
            for (int i = 0; i < 60; i++)
                HashAsString += h[ r.Next(0, 64) ];

            Outputs = new List<TransactionOutput>();
            Transaction a = new Transaction(new NetworkParameters() { ProofOfWorkLimit = new Org.BouncyCastle.Math.BigInteger("SSDS") }, new byte[] { 0x00, 0xa2, 0xae, 0x67 });
            TransactionOutput o = new TransactionOutput(new NetworkParameters() { ProofOfWorkLimit = new Org.BouncyCastle.Math.BigInteger("SSDS") }, a, new byte[] { 0x00, 0xa2, 0xae, 0x67 }, 0);
            Outputs.Add(o);
            this.addr = addr;
            this.amnt = amnt = (ulong)(btc * (100000000));
            this.btc = btc;
        }

        new IEnumerable<Tuple<string, ulong>> GetOutputBalances()
        {
            List<Tuple<string, ulong>> l = new List<Tuple<string, ulong>>();
            l.Add(new Tuple<string, ulong>(addr, amnt));
            return l.AsEnumerable();
        }

        protected override void Parse()
        {
            throw new NotImplementedException();
        }

        
    }
}
