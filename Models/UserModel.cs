using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evaluation.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public UserType UserDefineType { get; set; }
    }

    public enum UserType
    {
        Coach,
        Athlet
    }
}
