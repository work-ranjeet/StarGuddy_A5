using StarGuddy.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Interface
{
    public interface IUserDetailRepository
    {
        Task<UserDetail> GetUserDetailByUserId(Guid userId);
    }
}
