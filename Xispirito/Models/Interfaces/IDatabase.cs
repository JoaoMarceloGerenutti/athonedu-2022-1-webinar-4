using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models.Interfaces
{
    public interface IDatabase<User>
    {
        List<User> ListUser();

        // CRUD - Create.
        void InsertUser(User user);

        // CRUD - Read.
        User SelectUser(int userId);

        // CRUD - Update.
        void UpdateUser(User user);

        // CRUD - Delete.
        void DeleteUser(int userId);
    }
}