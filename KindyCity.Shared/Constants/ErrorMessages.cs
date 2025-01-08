namespace KindyCity.Shared.Constants
{
    public static class ErrorMessages
    {
        // Lỗi không xác định đã xảy ra
        public const string MESSAGE_ERROR_REQUEST_UNSPECIFIEDERRORHASOCCURRED = "An unspecified error has occurred.";

        // Dữ liệu đầu vào không hợp lệ
        public const string MESSAGE_ERROR_REQUEST_INVALIDINPUT = "The input provided is invalid.";

        // Bạn không có quyền truy cập vào tài nguyên này
        public const string MESSAGE_ERROR_REQUEST_UNAUTHORIZEDACCESS = "You do not have permission to access this resource.";

        // Yêu cầu không thể hoàn thành do xung đột với trạng thái hiện tại của tài nguyên
        public const string MESSAGE_ERROR_REQUEST_RESOURCECONFLICT = "The request could not be completed due to a conflict with the current state of the resource.";

        // Không tìm thấy tài nguyên được yêu cầu
        public const string MESSAGE_ERROR_REQUEST_NOTFOUND = "The requested resource was not found.";

        // Phương thức HTTP được sử dụng không được phép cho tài nguyên này
        public const string MESSAGE_ERROR_REQUEST_METHODNOTALLOWED = "The HTTP method used is not allowed for this resource.";

        // Tài nguyên yêu cầu chỉ có thể tạo ra nội dung không phù hợp với các tiêu đề Accept được gửi trong yêu cầu
        public const string MESSAGE_ERROR_REQUEST_NOTACCEPTABLE = "The requested resource is capable of generating only content not acceptable according to the Accept headers sent in the request.";

        // Thực thể yêu cầu có loại phương tiện mà máy chủ hoặc tài nguyên không hỗ trợ
        public const string MESSAGE_ERROR_REQUEST_UNSUPPORTEDMEDIATYPE = "The request entity has a media type which the server or resource does not support.";

        // Máy chủ không thể đáp ứng các yêu cầu của trường tiêu đề Expect trong yêu cầu
        public const string MESSAGE_ERROR_REQUEST_EXPECTATIONFAILED = "The server cannot meet the requirements of the Expect request-header field.";

        // Kết nối đến cơ sở dữ liệu thất bại
        public const string MESSAGE_ERROR_DATABASE_CONNECTIONFAILED = "Failed to connect to the database.";

        // Đã xảy ra lỗi khi thực hiện truy vấn cơ sở dữ liệu
        public const string MESSAGE_ERROR_DATABASE_QUERYFAILED = "An error occurred while executing the database query.";

        // Không tìm thấy bản ghi yêu cầu trong cơ sở dữ liệu
        public const string MESSAGE_ERROR_DATABASE_RECORDNOTFOUND = "The requested record was not found in the database.";

        // Bản ghi với định danh tương tự đã tồn tại trong cơ sở dữ liệu
        public const string MESSAGE_ERROR_DATABASE_DUPLICATERECORD = "A record with the same identifier already exists in the database.";

        // Đã xảy ra vi phạm đồng thời khi truy cập cơ sở dữ liệu
        public const string MESSAGE_ERROR_DATABASE_CONCURRENCYVIOLATION = "A concurrency violation occurred while accessing the database.";

        // Hoạt động đã hết thời gian chờ. Vui lòng thử lại sau
        public const string MESSAGE_ERROR_NETWORK_TIMEOUT = "The operation timed out. Please try again later.";

        // Mạng không thể truy cập. Vui lòng kiểm tra kết nối internet của bạn
        public const string MESSAGE_ERROR_NETWORK_UNREACHABLE = "The network is unreachable. Please check your internet connection.";

        // Đã xảy ra lỗi giao thức trong quá trình truyền thông mạng
        public const string MESSAGE_ERROR_NETWORK_PROTOCOLERROR = "A protocol error occurred during the network communication.";

        // Kết nối mạng đã được đặt lại. Vui lòng thử lại
        public const string MESSAGE_ERROR_NETWORK_CONNECTIONRESET = "The network connection was reset. Please try again.";

        // Không thể tìm thấy máy chủ được chỉ định
        public const string MESSAGE_ERROR_NETWORK_HOSTNOTFOUND = "The specified host could not be found.";

        // Hệ thống đã hết bộ nhớ
        public const string MESSAGE_ERROR_SYSTEM_OUTOFMEMORY = "The system has run out of memory.";

        // Đã xảy ra lỗi I/O khi truy cập tài nguyên hệ thống
        public const string MESSAGE_ERROR_SYSTEM_IOERROR = "An I/O error occurred while accessing the system resources.";

        // Bạn không có quyền cần thiết để thực hiện thao tác này
        public const string MESSAGE_ERROR_SYSTEM_UNAUTHORIZEDOPERATION = "You do not have the necessary permissions to perform this operation.";

        // Thao tác thất bại do lỗi nội bộ hệ thống
        public const string MESSAGE_ERROR_SYSTEM_OPERATIONFAILED = "The operation failed due to an internal system error.";

        // Đã phát hiện lỗi cấu hình trong hệ thống
        public const string MESSAGE_ERROR_SYSTEM_CONFIGURATIONERROR = "A configuration error has been detected in the system.";

        // Xác thực thất bại. Vui lòng kiểm tra thông tin đăng nhập của bạn
        public const string MESSAGE_ERROR_AUTHENTICATION_FAILED = "Authentication failed. Please check your credentials.";

        // Phiên làm việc của bạn đã hết hạn. Vui lòng đăng nhập lại
        public const string MESSAGE_ERROR_AUTHENTICATION_TOKENEXPIRED = "Your session has expired. Please log in again.";

        // Truy cập bị từ chối. Bạn không có đủ quyền hạn
        public const string MESSAGE_ERROR_AUTHENTICATION_ACCESSDENIED = "Access denied. You do not have sufficient privileges.";

        // Tài khoản của bạn đã bị khóa do nhiều lần đăng nhập thất bại
        public const string MESSAGE_ERROR_AUTHENTICATION_ACCOUNTLOCKED = "Your account has been locked due to multiple failed login attempts.";

        // Token xác thực cung cấp không hợp lệ hoặc đã hết hạn
        public const string MESSAGE_ERROR_AUTHENTICATION_INVALIDTOKEN = "The provided authentication token is invalid or has expired.";

        // Xác thực đầu vào thất bại. Vui lòng kiểm tra dữ liệu đã nhập
        public const string MESSAGE_ERROR_INPUT_VALIDATIONFAILED = "Input validation failed. Please check the entered data.";

        // Thiếu giá trị bắt buộc
        public const string MESSAGE_ERROR_INPUT_REQUIREDVALUE = "A required value is missing.";

        // Giá trị đầu vào nằm ngoài phạm vi cho phép
        public const string MESSAGE_ERROR_INPUT_OUTOFRANGE = "The input value is out of the acceptable range.";

        // Định dạng đầu vào không hợp lệ
        public const string MESSAGE_ERROR_INPUT_FORMATINVALID = "The input format is invalid.";

        // Đầu vào vượt quá độ dài tối đa cho phép
        public const string MESSAGE_ERROR_INPUT_TOOLONG = "The input exceeds the maximum allowed length.";

        // Không tìm thấy tệp được chỉ định
        public const string MESSAGE_ERROR_FILE_FILENOTFOUND = "The specified file was not found.";

        // Kích thước tệp vượt quá giới hạn cho phép
        public const string MESSAGE_ERROR_FILE_FILETOOLARGE = "The file size exceeds the maximum allowed limit.";

        // Loại tệp không được hỗ trợ
        public const string MESSAGE_ERROR_FILE_FILETYPEUNSUPPORTED = "The file type is not supported.";

        // Tệp có dấu hiệu bị hỏng
        public const string MESSAGE_ERROR_FILE_FILECORRUPTED = "The file appears to be corrupted.";

        // Bạn không có quyền truy cập tệp được chỉ định
        public const string MESSAGE_ERROR_FILE_FILEACCESSDENIED = "You do not have permission to access the specified file.";


    }
}
