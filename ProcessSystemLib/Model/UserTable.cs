using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib.Model
{
    public class UserTable
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int LoginId { get; set; }
        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
        public string RoleType { get; set; }

    }
}
