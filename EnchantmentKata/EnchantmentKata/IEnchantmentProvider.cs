using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnchantmentKata
{
    public interface IEnchantmentProvider
    {
        Enchantment GetRandomEnchantment();
    }

    public record Enchantment( string Name, string Prefix, string Effect ) { }
}
