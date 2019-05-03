using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evaluation.Models
{
    public class TestModel
    {
        public int TestId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public string TestName { get; set; }
        public int TestType { get; set; }
    }
}
