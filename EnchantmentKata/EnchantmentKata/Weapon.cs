using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnchantmentKata
{
    public class Weapon
    {
        private readonly IEnchantmentProvider _enchantmentProvider;
        private readonly string _baseWeaponName;
        private string _weaponPrefix = String.Empty;
        private Enchantment _currentEnchantment;
        private IRandomNumberGenerator _randomNumberGenerator;

        public Weapon( IEnchantmentProvider enchantmentProvider, string baseWeaponName, IRandomNumberGenerator randomNumberGenerator )
        {
            _enchantmentProvider = enchantmentProvider;
            _baseWeaponName = baseWeaponName;
            _randomNumberGenerator = randomNumberGenerator;
        }

        public string Name => _currentEnchantment?.Prefix + _baseWeaponName;
        public string AttackDamage { get; init; }
        public string AttackSpeed { get; init; }
        public string Effect => _currentEnchantment?.Effect ?? String.Empty;

        public void Enchant()
        {
            //10% chance, this should probably be config
            if ( _currentEnchantment != null && _randomNumberGenerator.GetNumber( 1, 10 ) == 10 )
            {
                _currentEnchantment = null;
            }
            else 
            {
                PerformEnchantment();
            }
        }

        private void PerformEnchantment()
        {
            Enchantment enchantment;

            do
            {
                enchantment = _enchantmentProvider.GetRandomEnchantment();
            } while ( enchantment == _currentEnchantment );

            _currentEnchantment = enchantment;
        }
    }
}
