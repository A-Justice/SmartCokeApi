using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCokeAPI.Models;
using System.Text;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web;
//using _TNS;
using hubtelapi_dotnet_v1.Hubtel;
using Newtonsoft.Json;
using System.Threading;
using Microsoft.Extensions.Hosting.Internal;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.html.simpleparser;

namespace SmartCokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private static bool IsPayDecisionCheckStarted = false;
        private readonly SmartCokeContext _context;

        public OrdersController(SmartCokeContext context)
        {
            _context = context;

            if (!IsPayDecisionCheckStarted)
            {
                IsPayDecisionCheckStarted  = true;
            }
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Orders> GetOrders()
        {
            return _context.Orders;
        }

        [HttpGet("findbycustid")]
        public IEnumerable<Orders> GetOrders(string id)
        {
            return _context.Orders.Where(o=>o.CustId == id);
        }

        // GET: api/Orders/5
        [HttpGet("single")]
        public async Task<IActionResult> GetOrders([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orders = await _context.Orders.FindAsync(id);

            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders([FromRoute] int id, [FromBody] Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orders.Id)
            {
                return BadRequest();
            }

            _context.Entry(orders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> PostOrders([FromBody] Orders orders)
        {
            string paymentMessage  = null;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CustomerDetails customerDetails = null;
            try
            {
                customerDetails = _context.CustomerDetails.Where(i => i.Email == orders.Email). FirstOrDefault();
                if(string.IsNullOrEmpty(customerDetails.Orders))
                    customerDetails.Orders = "0";

                var previousOrders = Convert.ToInt32(customerDetails.Orders);

                customerDetails.Orders =  (previousOrders ++).ToString();
                orders.DeliveryDate = DateTime.Now + TimeSpan.FromDays(7);
                orders.Duration = orders.DeliveryDate.ToString();
                orders.LoggedDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
            orders.Status = "Pending";
            orders.EpicorStatus = "0";
            orders.MailStatus = "New";
            orders.LoyalytyPoint = "1";

         
            

            if (orders.PackageName == "CUSTOM" || orders.PackageName.Contains("ASSORTED"))
                orders.OrderId = GenerateCusID();
            else
                orders.OrderId = GenerateID();

            if (orders.PaymentType == "VISA/MASTERCARD")
            {
               paymentMessage = Payment(orders);
            }
            else if (orders.PaymentType == "MOBILE MONEY")
            {
                try
                {
                    MobilePayment(orders);
                }catch(Exception ex)
                {
                  //  return BadRequest("Mobile Money Transaction Failed");
                    return BadRequest(ex.Message);
                }
                  
            }
            else if (orders.PaymentType == "BANK TRANSFER")
            {
                Sendbanktransfermsg(orders);
            }

            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();

            orders.Message = paymentMessage;

            return CreatedAtAction("GetOrders", new { id = orders.Id }, orders);
        }

        [HttpPost("confirmorder")]
        public async Task<IActionResult> ConfirmOrder(string orderId)
        {
            var order = _context.Orders.Where(o=>o.OrderId == orderId).FirstOrDefault();
            if (order != null)
            {
               var confirmationMessage  =  MobilePaymentCheck(order);
                return Ok(confirmationMessage);
            }
            else
            {
                return BadRequest("Invalid Order Id");
            }
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();

            return Ok(orders);
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }

        string GenerateID()
        {
            var CompCount = CountAll();
            string me;
            Random r = new Random();
            var x = r.Next(0, 1000000);
            string s = CompCount.ToString("000");
            string t = x.ToString("000");
            me = "PO" + "" + s + "" + t;
            return me;
        }

        string GenerateCusID()
        {
           var CompCount  = CountAll();
            string me;
            Random r = new Random();
            var x = r.Next(0, 1000000);
            string s = CompCount.ToString("000");
            string t = x.ToString("000");

            me = "CO" + s + t;
           return me;
        }


        int CountAll()
        {
            return _context.Orders.Count();
        }
        public string Payment(Orders order)
        {
            //pnlRequest.Visible = false;
            // TotCharge = Convert.ToInt32(amount) + 20; 
            // Double PaymentPrice = Math.Round((Double)Double.Parse(lblTotal.Text), 2);
            try
            {

                //double totalRound = Math.Round(totalPrice, 0);  (Double)Double.Parse(lblTotal.Text)
                double totalRound = Math.Round((Double)Double.Parse(order.TotalAmount), 0);

                double toMerchant = totalRound * 100;

                //double toMerchant = totalPrice * 100;
                // Connect to the Payment Client
               // VPCRequest conn = new VPCRequest();
               // // Add the Digital Order Fields for the functionality you wish to use
               // // Core Transaction Fields
               // conn.AddDigitalOrderField("vpc_Version", conn.Version);
               // conn.AddDigitalOrderField("vpc_Command", conn.Command);
               // conn.AddDigitalOrderField("vpc_AccessCode", conn.AccessCode);
               // conn.AddDigitalOrderField("vpc_Merchant", conn.MerchantID);
               //conn.AddDigitalOrderField("vpc_ReturnURL", conn.FormatReturnURL(HttpContext.Request.Scheme,HttpContext.Request.Host.ToString(), (int)HttpContext.Request.Host.Port, HttpContext.Request.Path));
               // conn.AddDigitalOrderField("vpc_MerchTxnRef", order.OrderId);
               // conn.AddDigitalOrderField("vpc_OrderInfo", order.PackageName);

               // conn.AddDigitalOrderField("vpc_Amount", toMerchant.ToString());

               // //conn.AddDigitalOrderField("vpc_Amount", "500");

               // conn.AddDigitalOrderField("vpc_Currency", "GHS");
               // conn.AddDigitalOrderField("vpc_Locale", "en_AU");
               // //conn.AddDigitalOrderField("vpc_Currency", Currency_List.Text);
               // //conn.AddDigitalOrderField("vpc_Locale", vpc_Locale.Text);
               // //conn.AddDigitalOrderField("vpc_MerchTxnRef", vpc_MerchTxnRef.Text);
               // //conn.AddDigitalOrderField("vpc_OrderInfo", vpc_OrderInfo.Text);
               // //conn.AddDigitalOrderField("vpc_Amount", vpc_Amount.Text);
               // // Perform the transaction
               // String url = conn.Create3PartyQueryString();
               //// Page.Response.Redirect(url);
               //return url;
               return "";
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }

        /// <summary>
        /// PAYMENT FOR MOBILE MONEY 
        /// </summary>
        public void MobilePayment(Orders order)
        {
                var request = (HttpWebRequest)WebRequest.Create("https://community.ipaygh.com/v1/mobile_agents_v2");
                request.ContentType = "application/json";
                request.Method = "POST";

                //Double PaymentPrice = Math.Round((Double)totalPrice, 2); lblTotal
                // totalPrice = Double.Parse(lblTotal.Text) ;
                Double PaymentPrice = Math.Round((Double)Double.Parse(order.TotalAmount), 2);

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(new
                    {
                        merchant_key = "210ce7da-2f51-11e8-8a3c-f23c9170642f",
                        invoice_id = order.OrderId,
                        total = PaymentPrice,
                        pymt_instrument = order.Momonumber,
                        extra_wallet_issuer_hint = order.Momonetwork
                    });
                    //total = totalPrice; totalPrice    
                    streamWriter.Write(json);
                }

                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    string[] tokens = result.Replace("\"", "").Replace("{", "").Replace("}", "").Split(',');
                    Dictionary<string, string> d = new Dictionary<string, string>();
                    foreach (var token in tokens)
                    {
                        string[] t = token.Split(':');
                        d.Add(t[0].ToLower().Trim(), t[1].Trim());
                    }

                    //foreach (KeyValuePair<string, string> kvp in d)
                    //{
                    //    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    //}
                    //Console.WriteLine(d["success"]);


                }


                // another status  is awaiting_payment
                response.Close();
            
            
        }

        //public string GetFormattedPhoneNumber(string phone)
        //{
        //    if (phone != null && phone.Trim().Length == 10)
        //        return "233" + phone.Substring(1,9);
        //    return phone;
        //}

        private void Sendbanktransfermsg(Orders order)
        {
            try
            {
                //MsgNuber = ReplaceFirstOccurrence(txtPhoneNum.Text, "0", "+233");
                //string  msgs = "Dear" + " " + txtFname.Text + " " + "thank you for" + " " + "using our service." + "Your OrderID:" + OrderID + " " + "check your email for details";
                //HubtrlMessage(MsgNuber, msgs);

                
                 var   msgs = "Dear" + " " + order.Fname + " " + "thank you for" + " " + "using our service." + "Your OrderID:" + order.OrderId + " " + ".Order Pending,your bank transfer will be verified soon.";
                    HubtrlMessage(order.PhoneNumber, msgs);
                

                string resultz = order.PhoneNumber.Substring(0, 1);
                var MsgNuber = order.PhoneNumber;

                if (resultz == "0")
                {
                    MsgNuber = GetFormattedPhoneNumber(MsgNuber);
                    HubtrlMessage(MsgNuber, msgs);
                }
                else
                    HubtrlMessage(MsgNuber, msgs);

            }
            catch
            {
                
            }
        }

        //public void HubtrlMessage(string num, string info)
        //{
        //    const string clientId = "eesuojtu";
        //    const string clientSecret = "shfgzcjx ";

        //    try
        //    {
        //        var host = new ApiHost(new BasicAuth(clientId, clientSecret));
        //        var messageApi = new MessagingApi(host);
        //        MessageResponse msg = messageApi.SendQuickMessage("COCA-COLA", num, info, true);
        //        Console.WriteLine(msg.Status);
        //    }
        //    catch (Exception e)
        //    {
        //        if (e.GetType() == typeof(HttpRequestException))
        //        {
        //            var ex = e as HttpRequestException;
        //            if (ex != null && ex.HttpResponse != null)
        //            {
        //                Console.WriteLine("Error Status Code " + ex.HttpResponse.Status);
        //            }
        //        }
        //        throw;
        //    }

        //    //Console.ReadKey();
        //}


        public string MobilePaymentCheck(Orders order)
        {

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
                return d["status"];
            }
            catch (Exception ex)
            {
                return "Error";
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
                return "233" + phone.Substring(1, 9);
            return phone;
        }


        public void HubtrlMessage(string num, string info)
        {
            const string clientId = "eesuojtu";
            const string clientSecret = "shfgzcjx ";

            //try
            //{
                var host = new ApiHost(new BasicAuth(clientId, clientSecret));
                var messageApi = new MessagingApi(host);
                MessageResponse msg = messageApi.SendQuickMessage("COCA-COLA", num, info, true);
                Console.WriteLine(msg.Status);
            //}
            //catch (Exception e)
            //{
            //    if (e.GetType() == typeof(HttpRequestException))
            //    {
            //        var ex = e as HttpRequestException;
            //        if (ex != null && ex.HttpResponse != null)
            //        {
            //            Console.WriteLine("Error Status Code " + ex.HttpResponse.Status);
            //        }
            //    }
            //    throw;
            //}

            //Console.ReadKey();
        }

    }

    //public class PayDecisionMaker
    //{
    //    public PayDecisionMaker(CancellationToken token)
    //    {

    //    }


    //}
}