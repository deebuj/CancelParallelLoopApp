using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CancelParallelLoopApp
{
    class AsyncAwaitTest
    {
        public async Task AsyncTest()
        {
            try
            {
                // Make a list of web addresses.  
                List<string> urlList = SetUpURLList();
                List<Task<int>> tasks = new List<Task<int>>();
                foreach (string url in urlList)
                {
                    Task<int> task = ProcessURLAsync(url);
                    tasks.Add(task);
                }

                int[] results = await Task.WhenAll(tasks.ToArray());
                Console.WriteLine("Total length->" + results.Sum());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
        public async Task<int> ProcessURLAsync(string url)
        {
            var byteArray = await GetURLContentsAsync(url);
            Console.WriteLine("Url->" + url + ".ByteArray Length->" + byteArray.Length);
            return byteArray.Length;
        }
        
        public async Task<byte[]> GetURLContentsAsync(string url)
        {
            // The downloaded resource ends up in the variable named content.  
            var content = new MemoryStream();

            // Initialize an HttpWebRequest for the current URL.  
            var webReq = (HttpWebRequest)WebRequest.Create(url);

            // Send the request to the Internet resource and wait for  
            // the response.  
            using (WebResponse response = await webReq.GetResponseAsync())
            {
                // Get the data stream that is associated with the specified url.  
                using (Stream responseStream = response.GetResponseStream())
                {
                    await responseStream.CopyToAsync(content);
                }
            }
            // Return the result as a byte array.  
            return content.ToArray();

        }
        public List<string> SetUpURLList()
        {
            List<string> urls = new List<string>
            {
                "https://msdn.microsoft.com",
                "https://msdn.microsoft.com/library/windows/apps/br211380.aspx",
                "https://msdn.microsoft.com/library/hh290136.aspx",
                "https://msdn.microsoft.com/library/ee256749.aspx",
                "https://msdn.microsoft.com/library/hh290138.aspx",
                "https://msdn.microsoft.com/library/hh290140.aspx",
                "https://msdn.microsoft.com/library/dd470362.aspx",
                "https://msdn.microsoft.com/library/aa578028.aspx",
                "https://msdn.microsoft.com/library/ms404677.aspx",
                "https://msdn.microsoft.com/library/ff730837.aspx"
            };
            return urls;
        }
    }
}
