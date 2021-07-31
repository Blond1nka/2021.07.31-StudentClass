using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass.Models
{
    public class GradeModel
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Subject { get; set; }
        public int Student_Id { get; set; }
    }
}
