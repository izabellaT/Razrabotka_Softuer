using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestierMask.Data.Model
{
    public class EmployeeTask
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int TaskId { get; set; }
        public Task Tasks { get; set; }
    }
}
