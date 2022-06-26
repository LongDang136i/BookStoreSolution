using BookStore.ViewModels.System.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.ViewModels.System.Users
{
    public class UserVm
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        public IList<string> Roles { get; set; }
    }
}