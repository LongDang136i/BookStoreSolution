using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels.System.Roles
{
    public class RoleVm
    {
        public Guid RoleId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}