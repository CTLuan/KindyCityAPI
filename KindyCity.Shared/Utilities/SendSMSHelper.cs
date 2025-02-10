using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Shared.Utilities
{
    public class SendSMSHelper
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static async Task<string> SendSmsAsync(string apiUrl, string brandName, string message, string phoneNumber, string username, string password)
        {
            try
            {
                var payload = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("brandName", brandName),
                    new KeyValuePair<string, string>("message", message),
                    new KeyValuePair<string, string>("phoneNumber", phoneNumber),
                    new KeyValuePair<string, string>("user", username),
                    new KeyValuePair<string, string>("pass", password),
                    new KeyValuePair<string, string>("messageId", Guid.NewGuid().ToString())
                });

                // Tạo request
                var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
                {
                    Content = payload
                };

                //// Thêm header Content-Type (thực tế `FormUrlEncodedContent` tự thêm, nhưng vẫn thêm tay nếu cần)
                //request.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                // Gửi yêu cầu POST
                var response = await HttpClient.PostAsync(apiUrl, payload);

                // Kiểm tra kết quả phản hồi
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return $"Success: {responseContent}";
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return $"Error: {response.StatusCode} - {errorContent}";
                }
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }
        }

    }
}
