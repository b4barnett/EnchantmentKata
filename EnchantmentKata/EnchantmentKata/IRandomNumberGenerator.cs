using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnchantmentKata
{
    public interface IRandomNumberGenerator
    {
        int GetNumber( int min, int max )
        {
            Random random = new Random();
            return random.Next( min, max );
        }
    }
}
