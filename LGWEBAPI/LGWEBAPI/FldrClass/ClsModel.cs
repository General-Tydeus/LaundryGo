using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGWEBAPI.FldrClass
{
    public class DuplicateData
    {
        public string FldValueFieldName { get; set; }
        public string FldTableName { get; set; }
        public string FldFieldName { get; set; }

    }
    public class Users
    {
        public string UserCode { get; set; }
        public string PWord { get; set; }
        public string GroupCode { get; set; }
        public string UserName { get; set; }
        public string CNCode { get; set; }
        public bool Active { get; set; }
        public string CompleteName { get; set; }
        public string Email { get; set; }
    }
}
