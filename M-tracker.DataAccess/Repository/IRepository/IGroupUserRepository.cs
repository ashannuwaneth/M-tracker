﻿using M_tracker.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Repository.IRepository
{
    public interface IGroupUserRepository  : IRepository<GroupUser>
    {
        Array GetAll(string txt);

        Array ListAllUsers();
        void Update(GroupUser obj);
    }
}
