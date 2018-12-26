using System.Collections.Generic;
using MyCompany.MyProject.Roles.Dto;

namespace MyCompany.MyProject.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}