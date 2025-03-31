using AppBanHang.DTOs;
using AppBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppBanHang.Utilities
{
    public static class APIHelper
    {
        public static async Task<string?> PostPaymentRequest<TRequestType>(string url, string clientKey, string apiKey, TRequestType request)
        {
            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-client-id", clientKey);
                client.DefaultRequestHeaders.Add("x-api-key", apiKey);
                
                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
                catch(HttpRequestException ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        public static async Task<string?> GetPaymentRequest(string url, string clientKey, string apiKey)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-client-id", clientKey);
                client.DefaultRequestHeaders.Add("x-api-key", apiKey);

                var response = await client.GetAsync(url);
                try {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException ex) {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        public static string GenerateSignature(string data, string checkSumKey)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(checkSumKey));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));

            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
