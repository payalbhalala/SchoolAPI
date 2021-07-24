using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers(bool trackChanges);

        User GetUser(Guid companyId, bool trackChanges);

        void CreateUser(User User);

        IEnumerable<User> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

        void DeleteUser(User User);
    }
}