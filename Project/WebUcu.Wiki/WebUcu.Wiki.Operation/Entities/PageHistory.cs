using System;
using System.Collections.Generic;
using System.Text;

namespace WebUcu.Wiki.Operation.Entities
{
    public class PageHistory
    {
        public long Id { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public string Content { get; set; }
        public int VersionNumber { get; set; }
    }
}
