using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Shared.Constants
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; } // Trạng thái thành công hay thất bại
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; } // Dữ liệu trả về (nếu có)

        // Các hàm tạo tiện ích
        public static ApiResponse<T> SuccessResponse(T data, string message = "Request was successful.")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }
    }
}
