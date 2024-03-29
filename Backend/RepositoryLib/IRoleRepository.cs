﻿using EntityModelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib
{
    public interface IRoleRepository
    {

        bool CreateRole(String roleName);

        bool DeleteRole(int roleId);

        List<Role> GetAllRoles();

        bool IsUserInRole(string userName, string roleName);

        int getRoleByEmail(string emailId);

    }
}
