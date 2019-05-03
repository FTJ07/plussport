using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evaluation.Models
{
    public class TestDetailsModel
    {
        public int TestDetailsId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int TestId { get; set; }
        public int Result { get; set; }
        public bool IsActive { get; set; }
    }
}
