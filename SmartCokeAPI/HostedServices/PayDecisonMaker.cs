using hubtelapi_dotnet_v1.Hubtel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartCokeAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartCokeAPI.HostedServices
{
    public interface IScopedProcessingService
    {
        void DoWork();
    }

    public class ScopedProcessingService : IScopedProcessingService
    {
        public readonly SmartCokeContext _context = null;

        public ScopedProcessingService(SmartCokeContext context)
        {
            _context = context;
        }

        public void DoWork()
        {
            while (true)
            {
              //  MobilePaymentCheck();
           // _context.SaveChanges();
                Thread.Sleep(300000);
            }
          
        }

        public void MobilePaymentCheck(string orderId)
        {
            var order = _context.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();

                try
                {
                    WebRequest request = WebRequest.Create("https://community.ipaygh.com/v1/gateway/json_status_chk");
                    // Set the Method property of the request to POST.  
                    request.Method = "POST";
                    // Create POST data and convert it to a byte array.  
                    string text = "merchant_key=210ce7da-2f51-11e8-8a3c-f23c9170642f&invoice_id=" + order.OrderId;

                    // string postData = "merchant_key=210ce7da-2f51-11e8-8a3c-f23c9170642f&invoice_id=PO030793514";  //&total=1&pymt_instrument=0249262722&extra_wallet_issuer_hint=MTN
                    string postData = text;

                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    // Set the ContentType property of the WebRequest.  
                    request.ContentType = "application/x-www-form-urlencoded";
                    // Set the ContentLength property of the WebRequest.  
                    request.ContentLength = byteArray.Length;
                    // Get the request stream.  
                    Stream dataStream = request.GetRequestStream();
                    // Write the data to the request stream.  
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    // Close the Stream object.  
                    dataStream.Close();
                    // Get the response.  
                    WebResponse response = request.GetResponse();
                    // Display the status.  
                    Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                    // Get the stream containing content returned by the server.  
                    dataStream = response.GetResponseStream();
                    // Open the stream using a StreamReader for easy access.  
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.  
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.  
                    Console.WriteLine(responseFromServer);
                    int c = order.OrderId.Count() + 4;
                    // string[] idremove = responseFromServer.Replace("","").Split(',');
                    string[] tokens = responseFromServer.Remove(0, c).Replace("\"", "").Replace("{", "").Replace("}", "").Split(',');
                    //lbl1.Text = tokens.ToString();

                    Dictionary<string, string> d = new Dictionary<string, string>();
                    foreach (var token in tokens)
                    {
                        string[] t = token.Split(':');
                        d.Add(t[0].ToLower().Trim(), t[1].Trim());
                    }

                    PayDecisions(order, d["status"]);

                    order.PaidAmount = d["total_amount_charged"];


                    //mp1.Show();
                    // Clean up the streams.  
                    reader.Close();
                    dataStream.Close();
                    response.Close();
                }
                catch (Exception ex)
                {

                }
            
        }


        public void PayDecisions(Orders order, string status)
        {
            if (status == "paid" && order.Status != status)
            {
                MOMOSuccessUpdate(order);

                SendSMS(order);
            }
            else if (status == "awaiting_payment" && order.Status != status)
            {
                MOMOAwaitingUpdate(order);
            }
            else if (status == "failed" && order.Status != status)
            {
                MOMOFailUpdate(order);
            }
        }

        public void MOMOSuccessUpdate(Orders order)
        {
            order.Status = "Paid";
            order.MailStatus = "Not Sent";
            order.PaidAmount = order.TotalAmount;
        }

        public void MOMOFailUpdate(Orders order)
        {
            order.Status = "Fail";
            order.MailStatus = "Not Sent";
        }

        public void MOMOAwaitingUpdate(Orders order)
        {
            order.Status = "Awaiting payment";
        }

        private void SendSMS(Orders order)
        {

            try
            {
                string msgs = null;

                string resultz = order.PhoneNumber.Substring(0, 1);
                var MsgNuber = order.PhoneNumber;

                if (resultz == "0")
                {
                    MsgNuber = GetFormattedPhoneNumber(MsgNuber);
                    msgs = "Dear" + " " + order.Fname + " " + "thank you for" + " " + "using our service." + "Your OrderID:" + order.OrderId + " " + "check your email for details";
                    HubtrlMessage(MsgNuber, msgs);
                }
                else
                {
                    msgs = "Dear" + " " + order.Fname + " " + "thank you for" + " " + "using our service." + "Your OrderID:" + order.OrderId + " " + "check your email for details";
                    HubtrlMessage(MsgNuber, msgs);
                }



            }
            catch (Exception ex)
            {

            }
        }

        public string GetFormattedPhoneNumber(string phone)
        {
            if (phone != null && phone.Trim().Length == 10)
                return string.Format("{1}", phone.Replace(phone.Substring(0, 1), "233"));
            return phone;
        }


        public void HubtrlMessage(string num, string info)
        {
            const string clientId = "eesuojtu";
            const string clientSecret = "shfgzcjx ";

            try
            {
                var host = new ApiHost(new BasicAuth(clientId, clientSecret));
                var messageApi = new MessagingApi(host);
                MessageResponse msg = messageApi.SendQuickMessage("COCA-COLA", num, info, true);
                Console.WriteLine(msg.Status);
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(HttpRequestException))
                {
                    var ex = e as HttpRequestException;
                    if (ex != null && ex.HttpResponse != null)
                    {
                        Console.WriteLine("Error Status Code " + ex.HttpResponse.Status);
                    }
                }
                throw;
            }

            //Console.ReadKey();
        }

    }
    public class PayDecisionMaker : IHostedService, IDisposable
    {
       
        private Timer _timer;
        public IServiceProvider Services { get; }

        public PayDecisionMaker(IServiceProvider services)
        {
            Services = services;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IScopedProcessingService>();

                scopedProcessingService.DoWork();
            }

        }

     


        public Task StopAsync(CancellationToken cancellationToken)
        {
           
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
