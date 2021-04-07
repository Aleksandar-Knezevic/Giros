using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giros.Model
{
    class OrderModel
    {
        public string size { get; set; }
        public string type { get; set; }
        public int staffId { get; set; }
        public string location { get; set; }
        public List<int> drinkIds { get; set; }
        public List<int> sideIds { get; set; }
    }
}
