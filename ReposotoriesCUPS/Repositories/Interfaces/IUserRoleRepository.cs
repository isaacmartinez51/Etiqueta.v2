﻿using Repositories.Data.Entities;
using Repositories.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IUserRoleRepository : IGenericRepository<UserRoleEModel>
    {
        Task<List<UserRoleVModel>> GetQueryUserRoleByUserId(int id);

        Task<bool> UpdateUserRoleTODO(UserVModel item);
    }
}
