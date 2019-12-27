using eximo.core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eximo.data.Services
{
   
    public class PlanService : IPlanService
    {

        private EximoDataContext _eximoDataContextRef;

        public async Task<object[]> AddUserPlan(ServicePlan plan)
        {
            var planObj = new object[2];

            //add service plan for selected user
            if (plan != null)
            {
                try
                {
                    await _eximoDataContextRef.ServicePlan.AddAsync(plan).ConfigureAwait(false);
                    await _eximoDataContextRef.SaveChangesAsync();
                    planObj[0] = plan;
                    planObj[1] = true;

                }
                catch(Exception e)
                {
                    planObj[0] = e.Message;
                    planObj[1] = false;
                }
            }
            else
            {
                planObj[0] = plan;
                planObj[1] = false;
            }

            return planObj;
        }

        public async Task<object[]> GetUserPlan(int? userId)
        {
            var planObj = new object[2];
            //get service plan for selected user
            if (userId != null)
            {
                try
                {
                    var servicePlan = await _eximoDataContextRef.ServicePlan.FirstOrDefaultAsync(s => s.UserId == userId).ConfigureAwait(false);
                    planObj[0] = servicePlan;
                    planObj[1] = true;

                }
                catch (Exception e)
                {
                    planObj[0] = e.Message;
                    planObj[1] = false;
                }
            }
            else
            {
                planObj[0] = userId;
                planObj[1] = false;
            }

            return planObj;
        }

        public async Task<object[]> RemoveUserPlan(int? userId)
        {
            var planObj = new object[2];
            //remove service plan for selected user
            if (userId != null)
            {
                try
                {
                    var planToRemove = await _eximoDataContextRef.ServicePlan.FirstOrDefaultAsync(s => s.UserId == userId).ConfigureAwait(false);
                    _eximoDataContextRef.ServicePlan.Remove(planToRemove);
                    await _eximoDataContextRef.SaveChangesAsync().ConfigureAwait(false);

                    planObj[0] = planToRemove;
                    planObj[1] = true;

                }
                catch (Exception e)
                {
                    planObj[0] = e.Message;
                    planObj[1] = false;
                }
            }
            else
            {
                planObj[0] = userId;
                planObj[1] = false;
            }

            return planObj;
        }

        public async Task<object[]> UpdateUserPlan(ServicePlan plan)
        {
            var planObj = new object[2];
            //get service plan for selected user
            if (plan != null)
            {
                try
                {
                    var planToUpdate = await _eximoDataContextRef.ServicePlan.FirstOrDefaultAsync(s => s.UserId == plan.UserId).ConfigureAwait(false);
                    _eximoDataContextRef.ServicePlan.Update(planToUpdate);
                    await _eximoDataContextRef.SaveChangesAsync().ConfigureAwait(false);

                    planObj[0] = planToUpdate;
                    planObj[1] = true;

                }
                catch (Exception e)
                {
                    planObj[0] = e.Message;
                    planObj[1] = false;
                }
            }
            else
            {
                planObj[0] = plan;
                planObj[1] = false;
            }

            return planObj;
        }
    }
}
