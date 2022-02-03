using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnchantmentKata
{
    public interface IEnchantmentProvider
    {
        Enchantment GetRandomEnchantment();
    }

    public class EnchantmentProvider : IEnchantmentProvider
    {
        private readonly IImmutableList<Enchantment> _enchantments;
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly int _enchanmentCount;

        public EnchantmentProvider( ICollection<Enchantment> enchantments, IRandomNumberGenerator randomNumberGenerator )
        {
            _enchantments = enchantments.ToImmutableList();
            _enchanmentCount = enchantments.Count;
            _randomNumberGenerator = randomNumberGenerator;
        }

        public Enchantment GetRandomEnchantment()
        {
            return _enchantments[ _randomNumberGenerator.GetNumber( 0, _enchanmentCount - 1 ) ];
        }
    }
}
