using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Agency : User
    {
        public virtual List<Division> Divisions { get; set; }
    }
}
