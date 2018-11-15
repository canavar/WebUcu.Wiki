using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WebUcu.Wiki.Operation.Entities
{
    public class Page
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public List<string> TagList
        {
            get
            {
                if (string.IsNullOrEmpty(Tags)) {
                    return new List<string>();
                }
                else
                {
                    return new List<string>(Tags.Split(','));
                } 
            }
        }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsLocked { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public string Content { get; set; }
        public int VersionNumber { get; set; }
    }
}
