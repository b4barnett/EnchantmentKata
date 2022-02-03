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

        public Weapon( IEnchantmentProvider enchantmentProvider, string baseWeaponName )
        {
            _enchantmentProvider = enchantmentProvider;
            _baseWeaponName = baseWeaponName;
        }

        public string Name => _weaponPrefix + _baseWeaponName;
        public string AttackDamage { get; init; }
        public string AttackSpeed { get; init; }
        public string Effect { get; private set; } = String.Empty;

        public void Enchant()
        {
            var enchantment = _enchantmentProvider.GetRandomEnchantment();

            _weaponPrefix = enchantment.Prefix;
            Effect = enchantment.Effect;
        }
    }
}
