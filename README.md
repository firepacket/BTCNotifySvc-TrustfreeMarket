# BTCNotifySvc the TrustfreeMarket companion Service app!

The Trustfree.Market windows GUI companion app that listens for transactions to the Escrow address and alerts the Website in real-time using long-polling or websockets. Also shows incoming transactions to old bitcoin addresses and shows network stats.

![GUI](https://github.com/firepacket/BTCNotifySvc-TrustfreeMarket/blob/main/ss.jpg)

When an Escrow is created between two parties, it uses a Named Pipe to send the information to this service which listens to any Bitcoin Node for transactions to the escrow addresss.

When it sees a transaction to the escrow addreess, it will notify the website at the URL provided giving the website user real-time responses.

Payments should be instant!

As soon as the buyer sends their payment, this app will see it and the site will respond to both the buyer and the seller telling them their next steps.

The site can be used without this by using other services, but this is a nice and easy way to keep the site fully responsive if you host your own node.

It is based off BitcoinSharp which is a C# port of BitcoinJ. I have fixed most of the bugs and this app appears to work well for me in testing.

It also allows you to inject fake transactions to simulate payment for website testing.
