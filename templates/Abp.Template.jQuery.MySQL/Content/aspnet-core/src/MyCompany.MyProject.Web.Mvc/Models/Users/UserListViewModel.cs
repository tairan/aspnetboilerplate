using System.Collections.Generic;
using MyCompany.MyProject.Roles.Dto;
using MyCompany.MyProject.Users.Dto;

namespace MyCompany.MyProject.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
