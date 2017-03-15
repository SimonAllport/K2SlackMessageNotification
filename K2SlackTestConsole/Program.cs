using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2SlackTestConsole
{
    class Program
    {
        static void Main(string[] args)

        {
            K2Slack.SlackClient.PostMessage(" @Stevefisher Hello World","stevefisher","general") ;
        }
    }
}
