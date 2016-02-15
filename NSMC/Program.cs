using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSMC
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NotifyService.NotifyServiceClient client = new NotifyService.NotifyServiceClient();

                while (true)
                {
                    string txt = Console.ReadLine();

                    string[] list=client.SysCommand("star", txt);
                    Console.WriteLine("total:{0}", list.Length);
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
