using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtcNotifySvc
{
    public class BlockChainMessage
    {
        public string op { get; set; }
        public BtcTransaction x { get; set; }
    }
    public class BtcTransaction
    {
        public string hash { get; set; }
        public int ver { get; set; }
        public int vin_sz { get; set; }
        public int vout_sz { get; set; }
        public string lock_time { get; set; }
        public int size { get; set; }
        public string relayed_by { get; set; }
        public double tx_index { get; set; }
        public double time { get; set; }
        public BtcTxIn[] inputs { get; set; }
        public BtcTxOut[] @out { get; set; }
    }

    public class BtcTxIn
    {
        public BtcPrevOut prev_out { get; set; }
    }

    public class BtcPrevOut
    {
        public double value { get; set; }
        public int type { get; set; }
        public string addr { get; set; }
    }

    public class BtcTxOut
    {
        public double value { get; set; }
        public int type { get; set; }
        public string addr { get; set; }
    }
}
