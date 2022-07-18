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

- BookStore.WebApp
-- LazZiya.ExpressLocalization
-- LazZiya.TagHelpers
-- Microsoft.AspNetCore.Html.Abstractions
-- Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
-- Microsoft.IdentityModel.Logging
-- Microsoft.IdentityModel.Tokens
-- System.IdentityModel.Tokens.Jwt
-- Microsoft.VisualStudio.Web.CodeGeneration.Design


########################################################################
## Image Demo
![alt text](https://github.com/[username]/[reponame]/blob/[branch]/image.jpg?raw=true)



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





