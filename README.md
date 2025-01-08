src
│
├── KindyCity.API                     (Tầng Presentation - Entry Point)
│   ├── Controllers                   (Các API controllers)
│   ├── Filters                       (Global Exception Handling - bắt lỗi toàn cục)
│   ├── Middleware                    (Middleware như JWT, CORS...)
│   ├── DependencyInjection.cs        (Đăng ký DI cho tầng API)
│   └── Program.cs / Startup.cs       (Cấu hình ứng dụng chính)
│
├── KindyCity.Application             (Tầng Application - Logic ứng dụng)
│   ├── Behaviours                    (Pipeline behaviors cho CQRS)
│   ├── Commands                      (Xử lý các Command trong CQRS)
│   ├── Queries                       (Xử lý các Query trong CQRS)
│   ├── Interfaces                    (Interface service/repositories)
│   ├── Mappings                      (Cấu hình AutoMapper)
│   ├── Models                        (DTOs, Request/Response Models)
│   ├── Exceptions                    (Exception xử lý ở Application)
│   ├── Validators                    (Validation với FluentValidation)
│   └── DependencyInjection.cs        (Đăng ký DI cho tầng Application)
│
├── KindyCity.Domain                  (Tầng Domain - Core Business Logic)
│   ├── Entities                      (Các entity và logic nghiệp vụ)
│   ├── Enums                         (Enums dùng trong toàn bộ dự án)
│   ├── ValueObjects                  (Các value object như Address, Money)
│   └── DependencyInjection.cs        (Nếu cần dùng DI cho Domain)
│
├── KindyCity.Infrastructure          (Tầng Infrastructure - Truy cập dữ liệu)
│   ├── Data                          (EF Core DbContext, migrations)
│   ├── Repositories                  (Cài đặt repository pattern)
│   ├── Services                      (Tích hợp dịch vụ bên ngoài, ví dụ: Email)   
│   └── DependencyInjection.cs        (Đăng ký DI cho tầng Infrastructure)
│
└── KindyCity.Shared                  (Thành phần dùng chung)
    ├── Exceptions                    (Các exception dùng chung)
    ├── Constants                     (Constants toàn cục)
    ├── Utilities                     (Tiện ích dùng chung, ví dụ: EmailHelper)
    ├── Models                        (Các model dùng chung)
    ├── Extensions                    (Extension methods)
    └── DependencyInjection.cs        (Đăng ký các tiện ích dùng chung)
