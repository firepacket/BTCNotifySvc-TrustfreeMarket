/*
 * Copyright 2011 John Sample.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using BitCoinSharp.Discovery;

namespace BitCoinSharp.Examples
{
    /// <summary>
    /// Prints a list of IP addresses connected to the rendezvous point on the LFnet IRC channel.
    /// </summary>
    public static class PrintPeers
    {
        public static event Action<string> LogEvent;

        private static void PrintElapsed(int start)
        {
            var now = Environment.TickCount;

            if (LogEvent != null)
                LogEvent(string.Format("Took {0:0.00} seconds", (now - start)/1000.0));
        }

        private static void PrintAddresses(IEnumerable<EndPoint> addresses)
        {
            foreach (var address in addresses)
            {
                if (LogEvent != null)
                    LogEvent(address.ToString());
            }
        }

        /// <exception cref="PeerDiscoveryException"/>
        private static void PrintIrc()
        {
            var start = Environment.TickCount;
            var d = new IrcDiscovery("#bitcoin");
            d.Send += (sender, e) => 
                {
                    if (LogEvent != null)
                        LogEvent("<- " + e.Message);
                };
            d.Receive += (sender, e) =>
            {
                if (LogEvent != null)
                    LogEvent("-> " + e.Message);
            };
            PrintAddresses(d.GetPeers());
            PrintElapsed(start);
        }

        /// <exception cref="PeerDiscoveryException"/>
        private static void PrintDns()
        {
            var start = Environment.TickCount;
            var dns = new DnsDiscovery(NetworkParameters.ProdNet());
            PrintAddresses(dns.GetPeers());
            PrintElapsed(start);
        }

        /// <exception cref="PeerDiscoveryException"/>
        public static void Run()
        {
            if (LogEvent != null)
                LogEvent("=== IRC ===");
            PrintIrc();
            if (LogEvent != null)
                LogEvent("=== DNS ===");
            PrintDns();
        }

        public static PeerAddress[] GetAddresses()
        {
            var start = Environment.TickCount;
            var d = new IrcDiscovery("#bitcoin");
            d.Send += (sender, e) => Console.WriteLine("<- " + e.Message);
            d.Receive += (sender, e) => Console.WriteLine("-> " + e.Message);
            List<EndPoint> addrs = new List<EndPoint>(d.GetPeers());

            var dns = new DnsDiscovery(NetworkParameters.ProdNet());
            foreach (var ep in dns.GetPeers())
                addrs.Add(ep);

            PrintAddresses(addrs);

            PrintElapsed(start);
            return addrs.Select(s => new PeerAddress((IPEndPoint)s)).ToArray();
        }
    }
}