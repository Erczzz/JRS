﻿using MessagePack;
using System.Diagnostics.CodeAnalysis;

namespace JRS.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        [AllowNull]
        public List<User> Users { get; set; }
        public Role() 
        { 
        }
        public Role(int roleId, string roleName)
        {
            RoleId = roleId;
            RoleName = roleName;
        }
    }
}
