using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnchantmentKata
{
    public class Weapon
    {
        public string Name { get; set; }
        public string AttackDamage { get; set; }
        public string AttackSpeed { get; set; }
        public string Effect { get; private set; } = String.Empty;

        public void Enchant()
        {
            throw new NotSupportedException();
        }
    }
}
