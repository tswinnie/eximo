using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eximo.datacore
{
    public class UserDataAccess
    {
        public static EximoDataContext _eximoContext;

        public UserDataAccess()
        {
        

        }

        public static void InitializeEximoContext(string dbPath)
        {
            _eximoContext = new EximoDataContext(dbPath);
        }

    
    }
}
