﻿using M_tracker.DataAccess.Data;
using M_tracker.DataAccess.Repository.IRepository;
using M_tracker.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Repository
{
    public class GroupUserRepository : Repository<GroupUser>, IGroupUserRepository
    {
        private readonly ApplicationDataContext _db;
        
        public GroupUserRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
     

        }

        public Array GetAll(string txt)
        {

            var users = (from User in _db.Users
                         where User.UserName.StartsWith(txt)
                         select new
                         {
                             label = User.UserName,
                             value = User.Id
                         }).ToList();

            return users.ToArray();
        }

        public Array ListAllUsers()
        {
            var UserLst = (from gu in _db.GroupTypeUsers
                           join u in _db.Users on gu.UserId equals u.Id
                           join gl in _db.GroupUsers on gu.GroupId equals gl.Id
                           select new
                           {
                               Id = gu.Id,
                               GroupName = u.UserName,
                               IsActive= gl.IsActive == true ? "Yes":"No",
                               IsAdmin= gl.IsAdmin == true ? "Yes":"No"
                           }).ToArray();

            return UserLst;


        }

        public void Update(GroupUser obj)
        {
           _db.GroupUsers.Update(obj);
        }
    }
}
