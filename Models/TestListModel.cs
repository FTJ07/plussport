using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evaluation.Models
{
    public class TestListModel
    {
        public int TestId { get; set; }
        public DateTime CreateDate { get; set; }
        public string TestName { get; set; }
        public string TestTypeName { get; set; }
        public int Participate { get; set; }
    }
}
