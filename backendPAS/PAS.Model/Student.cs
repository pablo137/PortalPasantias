using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Career { get; set; }
    }
}
