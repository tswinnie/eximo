using eximo.core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eximo.data.Services
{
    public interface IPlanService
    {
        Task<object[]> GetUserPlan(int? userId);
        Task<object[]> AddUserPlan(ServicePlan plan);
        Task<object[]> UpdateUserPlan(ServicePlan plan);
        Task<object[]> RemoveUserPlan(int? userId);

    }
}
