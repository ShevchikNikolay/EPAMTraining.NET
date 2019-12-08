using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop
{
    public class PaintingException:Exception
    {
        public PaintingException(string message): base(message)
        {

        }
    }
}
