﻿using System;
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

        public Weapon( IEnchantmentProvider enchantmentProvider, string baseWeaponName )
        {
            _enchantmentProvider = enchantmentProvider;
            _baseWeaponName = baseWeaponName;
        }

        public string Name => _currentEnchantment?.Prefix + _baseWeaponName;
        public string AttackDamage { get; init; }
        public string AttackSpeed { get; init; }
        public string Effect => _currentEnchantment?.Effect ?? String.Empty;

        public void Enchant()
        {
            Enchantment enchantment;

            do 
            {
                enchantment = _enchantmentProvider.GetRandomEnchantment();
            }while( enchantment == _currentEnchantment );

            _currentEnchantment = enchantment;
        }
    }
}
