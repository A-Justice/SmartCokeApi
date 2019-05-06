using System;
using System.Collections.Generic;

namespace SmartCokeAPI.Models
{
    public partial class Orders
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string EventType { get; set; }
        public string Location { get; set; }
        public string GhanaPostGps { get; set; }
        public string Venue { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Duration { get; set; }
        public string PackageName { get; set; }
        public string PaymentType { get; set; }
        public double? Amount { get; set; }
        public string Status { get; set; }
        public DateTime? LoggedDate { get; set; }
        public string EpicorStatus { get; set; }
        public string EventSize { get; set; }
        public string OrderId { get; set; }
        public string Rsvpname { get; set; }
        public string Rsvpnumber { get; set; }
        public string Region { get; set; }
        public string Area { get; set; }
        public string Lname { get; set; }
        public string TxnResponseCode { get; set; }
        public string MerchTxnRef { get; set; }
        public string OrderInfo { get; set; }
        public string Merchant { get; set; }
        public string PaidAmount { get; set; }
        public string Message { get; set; }
        public string ReceiptNo { get; set; }
        public string AcqResponseCode { get; set; }
        public string AuthorizeId { get; set; }
        public string BatchNo { get; set; }
        public string TransactionNo { get; set; }
        public string Card { get; set; }
        public string Dseci { get; set; }
        public string Dsxid { get; set; }
        public string Dsenrolled { get; set; }
        public string Dsstatus { get; set; }
        public string VerToken { get; set; }
        public string VerType { get; set; }
        public string VerSecurityLevel { get; set; }
        public string VerStatus { get; set; }
        public string RiskOverallResult { get; set; }
        public string TxnReversalResult { get; set; }
        public string TxnResponseCodeDesc { get; set; }
        public string CscResultCode { get; set; }
        public string CscResultCodeDesc { get; set; }
        public string ReceiptErrorMessage { get; set; }
        public string MailStatus { get; set; }
        public string ServCharge { get; set; }
        public string DistributorId { get; set; }
        public string DistributorName { get; set; }
        public string District { get; set; }
        public string DistrictId { get; set; }
        public string TotalAmount { get; set; }
        public string DistributorAmount { get; set; }
        public string DeliveryMail { get; set; }
        public string CountCode { get; set; }
        public string Momonumber { get; set; }
        public string Momonetwork { get; set; }
        public string ReferenceType { get; set; }
        public string ReferenceDetails { get; set; }
        public string LoyalytyPoint { get; set; }
        public string Volume { get; set; }
        public string CustId { get; set; }
        public string PromoCode { get; set; }
        public string ShareAcoke { get; set; }
        public string Btrefrence { get; set; }
        public string Btdate { get; set; }
        public string BtbankName { get; set; }
    }
}
