using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Model
{
    public class History
    {
        public int? Id { get; set; }
        public int IdUser    { get; set; }
        public DateTime? datePass { get; set; }
    }
}
