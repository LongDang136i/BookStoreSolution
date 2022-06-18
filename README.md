# ASP.NET Core 3.1 project

########################################################################
## Technologies
- ASP.NET Core 3.1
- Entity Framework Core 3.1


########################################################################
## Install Packages
- BookStore.Data:
-- Microsoft.EntityFrameworkCore.SqlServer
-- Microsoft.EntityFrameworkCore.Design
-- Microsoft.EntityFrameworkCore.Tools
-- Microsoft.AspNetCore.Identity
-- Microsoft.AspNetCore.Identity.EntityFrameworkCore
-- Microsoft.Extensions.Configuration.FileExtensions
-- Microsoft.Extensions.Configuration.Json

- BookStore.ViewModels
-- Microsoft.AspNetCore.Http
-- FluentValidation.AspNetCore

- BookStore.ApiIntegration
-- Newtonsoft.Json

- BookStore.Application
-- System.IdentityModel.Tokens.Jwt

- BookStore.BackEndApi
-- Swashbuckle.AspNetCore
-- Microsoft.AspNetCore.Authentication.JwtBearer
-- FluentValidation.AspNetCore

- BookStore.AdminApp
-- Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
-- Microsoft.IdentityModel.Logging
-- Microsoft.IdentityModel.Tokens
-- System.IdentityModel.Tokens.Jwt
-- FluentValidation.AspNetCore
-- Microsoft.AspNetCore.Session


########################################################################
## Description Solution
- BookStore.Data:
-- EF: Database Context
-- Entities: Database Design
-- Enums: Enum value (Status, OrderStatus,...)
-- Configuration: Config Entities with Fluent API



########################################################################
## Detail Solution
- BookStore.Data:
-- Config Entities with Fluent API




########################################################################
## Process
- Login
-- Admin & Web App send create request from user input(M-View-Controller: LoginController,...)
-- Process in ApiIntegration and return (UserApiClient)
-- Process in Application (UserService)
-- Process in BackEndApi (UsersController)






########################################################################
## Tokens, Keywords in appsettings,lauchSettings

"ConnectionStrings": {
    "BookStoreSolutionDb": "Server=.;Database=BookStoreSolution;Trusted_Connection=True;"
  }

  "DefaultLanguageId": "en",

  "Tokens": {
    "Key": "0123456789ABCDEF",
    "Issuer": "https://bookstore.com"
  }

















// Note

//---------------------------------------------------------------------------------//
#region Private Menthod


#endregion

//---------------------------------------------------------------------------------//
#region Admin App


#endregion

//---------------------------------------------------------------------------------//
#region Both Admin & Web App


#endregion

//---------------------------------------------------------------------------------//
#region Web App


#endregion


#HTTP Request
GET: được sử dụng để lấy thông tin từ server theo URI đã cung cấp.
HEAD: giống với GET nhưng response trả về không có body, chỉ có header.
POST: gửi thông tin tới sever thông qua các biểu mẫu http.
PUT: ghi đè tất cả thông tin của đối tượng với những gì được gửi lên.
PATCH: ghi đè các thông tin được thay đổi của đối tượng.
DELETE: xóa tài nguyên trên server.
CONNECT: thiết lập một kết nối tới server theo URI.
OPTIONS: mô tả các tùy chọn giao tiếp cho resource.
TRACE: thực hiện một bài test loop – back theo đường dẫn đến resource.

#Status code
200 OK – Trả về thành công cho những phương thức GET, PUT, PATCH hoặc DELETE.
201 Created – Trả về khi một Resouce vừa được tạo thành công.
204 No Content – Trả về khi Resource xoá thành công.
304 Not Modified – Client có thể sử dụng dữ liệu cache.
400 Bad Request – Request không hợp lệ
401 Unauthorized – Request cần có auth.
403 Forbidden – bị từ chối không cho phép.
404 Not Found – Không tìm thấy resource từ URI
405 Method Not Allowed – Phương thức không cho phép với user hiện tại.
410 Gone – Resource không còn tồn tại, Version cũ đã không còn hỗ trợ.
415 Unsupported Media Type – Không hỗ trợ kiểu Resource này.
422 Unprocessable Entity – Dữ liệu không được xác thực
429 Too Many Requests – Request bị từ chối do bị giới hạn






