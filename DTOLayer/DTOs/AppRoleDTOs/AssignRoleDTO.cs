using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppRoleDTOs
{
    public class AssignRoleDTO
    {
        public  int RoleID { get; set; }

        public string RoleName { get; set; }

        public bool RoleExist { get; set; }
    }
}
