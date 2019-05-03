using evaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evaluation.ViewModels
{
    public class TestViewModel
    {
        public List<TestTypeModel> TestTypeList { get; set; }
        public int TestType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string TestName { get; set; }

    }
}
