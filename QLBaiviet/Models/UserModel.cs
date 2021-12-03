using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLBaiviet.Models
{
    public class UserModel
    {
        private qlbaivietEntities db = null;
        public UserModel() 
        {
            db = new qlbaivietEntities();
        }
        public bool Login(string username, string password)
        {
            object[] sqlParam =
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
            var res = db.Database.SqlQuery<bool>("Sp_Login @Username, @Password", sqlParam).SingleOrDefault();
            return res;
        }
    }
}