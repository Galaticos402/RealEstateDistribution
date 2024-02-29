using Infrastructure.DTOs.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class VnPayService : IVnPayService
    {
        private readonly string IP_ADDR = "127.0.0.1";
        private readonly string TMN_CODE = "VOZI9UHB";
        private readonly string VERSION = "2.1.0";
        private readonly string COMMAND = "pay";
        private readonly string CREATE_DATE = DateTime.Now.ToString("yyyyMMddHHmmss");
        private readonly string CURR_CODE = "VND";
        private readonly string LOCALE = "vn";
        private readonly string RETURN_URL = "https://localhost:7208";
        private readonly string EXPIRED = DateTime.Now.AddMinutes(15).ToString("yyyyMMddHHmmss");
        private readonly string SECURE_HASH = "OGCKJUVCFTVWZRWFIVGAKTHRRFPBMFDL";
        private readonly string SECURE_HASH_TYPE = "SHA256";
        private readonly string ORDER_TYPE = "other";
        private readonly string TXN_REF = new Random().NextInt64().ToString();
        public string GetPaymentUrl(int saleBatchId, int customerId, int amount)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param[VNPayConfiguration.VNP_VERSION] = VERSION;
            param[VNPayConfiguration.VNP_COMMAND] = COMMAND;
            param[VNPayConfiguration.VNP_TMNCODE] = TMN_CODE;
            param[VNPayConfiguration.VNP_AMOUNT] = amount.ToString();
            param[VNPayConfiguration.VNP_CREATEDATE] = CREATE_DATE;
            param[VNPayConfiguration.VNP_CURRCODE] = CURR_CODE;
            param[VNPayConfiguration.VNP_IPADDR] = IP_ADDR;
            param[VNPayConfiguration.VNP_LOCALE] = LOCALE;
            param[VNPayConfiguration.VNP_ORDERINFO] = $"Dat cho cho dot ban {saleBatchId} cua khach hang {customerId}";
            param[VNPayConfiguration.VNP_ORDERTYPE] = ORDER_TYPE;
            param[VNPayConfiguration.VNP_RETURNURL] = RETURN_URL;
            param[VNPayConfiguration.VNP_EXPIREDATE] = EXPIRED;
            param[VNPayConfiguration.VNP_TXNREF] = TXN_REF;
            //param[VNPayConfiguration.VNP_SECUREHASH] = SECURE_HASH;
            string paymentUrl = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html?";
            string hashData = "";
            foreach(var entry  in param)
            {
                if(entry.Value != null && entry.Value.Length > 0)
                {
                    paymentUrl += WebUtility.UrlEncode($"{entry.Key}=");
                    paymentUrl += WebUtility.UrlEncode($"{entry.Value}");
                    paymentUrl += "&";

                    hashData += WebUtility.UrlEncode($"{entry.Key}=");
                    hashData += WebUtility.UrlEncode($"{entry.Value}");
                    hashData += "&";
                }
               
            }
            hashData.Remove(hashData.Length - 1, 1);
            paymentUrl += $"{VNPayConfiguration.VNP_SECUREHASH}={HmacSha512(SECURE_HASH, hashData)}";
            return paymentUrl;
        }

        private string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private string HmacSha512(string key, string inputData)
        {
            var hash = new StringBuilder();
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var inputBytes = Encoding.UTF8.GetBytes(inputData);
            using (var hmac = new HMACSHA512(keyBytes))
            {
                var hashValue = hmac.ComputeHash(inputBytes);
                foreach (var theByte in hashValue)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }

            return hash.ToString();
        }

    }
}
