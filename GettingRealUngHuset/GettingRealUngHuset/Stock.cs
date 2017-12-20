using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealUngHuset
{
    class Stock
    {
        public static void CheckStock()
        {
            Controller controller = new Controller();
            controller.GetKamaralistHome();
        }
    }
}
