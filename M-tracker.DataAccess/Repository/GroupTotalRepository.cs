using M_tracker.DataAccess.Data;
using M_tracker.DataAccess.Repository.IRepository;
using M_tracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Repository
{
    public class GroupTotalRepository : Repository<GroupTotal>, IGroupTotalRepository
    {
        private readonly ApplicationDataContext _db;
        public GroupTotalRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public Array GetMonths(string TypeId,string UserId)
        {
            var Months = (from gx in _db.GroupExpensesManages
                          join gt in _db.GroupTypes on gx.GroupTypeId equals gt.Id
                          join u in _db.Users on gx.UserId equals u.Id
                          where gx.GroupTypeId == Convert.ToInt32(TypeId) && gx.UserId == UserId && gx.IsProceed == false
                          group gx by gx.ExpensesDate into g
                          select new
                          {
                              ExpensesDate = g.Key
                          }).ToArray();

            return Months;


        }

        public bool ProcessExpenses(string txtGroupId, string txtDate,string user)
        {

            try
            {
                double TotalSum = 0;
                var UpdateList = (from g in _db.GroupExpensesManages
                                  where g.GroupTypeId == Convert.ToInt32(txtGroupId) && g.ExpensesDate == txtDate && g.UserId == user && g.IsProceed == false
                                  select g).ToArray();

                for (int i = 0; i < UpdateList.Length; i++)
                {
                    UpdateList[i].IsProceed = true;
                    TotalSum += UpdateList[i].Amount;
                }

                _db.GroupExpensesManages.UpdateRange(UpdateList);

                GroupTotal gt = new GroupTotal();
                gt.SubmitDate = DateTime.Now;
                gt.Amount = TotalSum;
                gt.DueAmount = TotalSum;
                gt.TotalAmount = 0;
                gt.GroupTypeId = Convert.ToInt32(txtGroupId);
                gt.UserId = user;
                gt.ProcessDate = txtDate;
                _db.GroupTotals.Add(gt);
                _db.SaveChanges();


                var GroupCount = _db.GroupTypeUsers.Where(a => a.Id == Convert.ToInt32(txtGroupId)).Count();
                var GroupTotalCount = _db.GroupTotals.Where(b => b.GroupTypeId == Convert.ToInt32(txtGroupId) && b.ProcessDate == txtDate).Count();

                if (GroupCount == GroupTotalCount)
                {
                    var GetList = (from gtt in _db.GroupTotals
                                   where gtt.GroupTypeId == Convert.ToInt32(txtGroupId) && gtt.ProcessDate == txtDate
                                   select gtt
                                  ).ToArray();

                    for (int i=0;i< GetList.Length;i++)
                    {
                        GetList[i].IsProceed = true;
                    }

                    _db.GroupTotals.UpdateRange(GetList);
                    _db.SaveChanges();
                }


               
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Array LoadGroupAmount(string groupid)
        {
            try
            {
                var List = (from gt in _db.GroupTotals
                            join g in _db.GroupTypes on gt.GroupTypeId equals g.Id
                            join u in _db.Users on gt.UserId equals u.Id
                            orderby gt.IsProceed 
                            select new
                            {
                                SubmitDate = gt.SubmitDate,
                                Amount = gt.Amount,
                                DueAmount = gt.DueAmount,
                                TotalAmount = gt.TotalAmount,
                                ProcessDate = gt.ProcessDate,
                                UserName = u.UserName,
                                IsProceed =gt.IsProceed,
                            }).ToArray();

                return List;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
