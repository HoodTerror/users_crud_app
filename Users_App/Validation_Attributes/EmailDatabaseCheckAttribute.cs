using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Users_DataModels.DataModels;
using Users_Repos.Repos;

namespace Users_App.Validation_Attributes
{
    public class EmailDatabaseCheckAttribute : ValidationAttribute
    {
        private readonly IEnumerable<Users> userList;

        public EmailDatabaseCheckAttribute()
        {
            userList = new UnitOfWork().Users.GetAll();
        }

        public override bool IsValid(object value)
        {
            foreach (var u in userList)
            {
                if (u.Email == value as string)
                    return false;
            }

            return true;
        }
    }
}
