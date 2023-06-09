﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DOOR.EF.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace DOOR.EF.Data
{
    public partial class DOOROracleContext : DbContext
    {
        protected readonly String _strUserName;
        public string LoggedInUserId { get; set; }

        public void SetUserID(int schoolID, string UserID)
        {
            this.LoggedInUserId = UserID;
            var school_id_in = new OracleParameter("p_School_ID", OracleDbType.Int32, schoolID, ParameterDirection.Input);
            var user_id_in = new OracleParameter("p_User_ID", OracleDbType.Varchar2, UserID, ParameterDirection.Input);
            try
            {
                this.Database.ExecuteSqlRaw("BEGIN pkg_context.set_context({0},{1}); END;", school_id_in, user_id_in);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
