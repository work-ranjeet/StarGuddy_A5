namespace StarGuddy.Repository.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserEmailsRepository
    {
        Task<bool> UpdateEmailAsync(Guid userId, string email);
    }
}
