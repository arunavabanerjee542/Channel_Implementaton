using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel
{
    class Program
    {
        static async Task Main(string[] args)
        {


            ChannelData<int> channelData = new ChannelData<int>();

            // Producer 

          Task t = Task.Factory.StartNew( async () =>
            {
                for (int i = 0; ; i++)
                {
                    {
                        await Task.Delay(1000);
                        channelData.Write(i);

                    }
                }


            }


            );
              





            // Consumer

            while(1==1)
            {
                Console.WriteLine(await channelData.Read() );
            }





        }
    }
}
