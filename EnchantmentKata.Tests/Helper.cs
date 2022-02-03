using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnchantmentKata.Tests
{
    public static class Helper
    {
        public static IReadOnlyDictionary<string, Enchantment> Enchantments = new Dictionary<string, Enchantment>()
            {
                { "Fire", new Enchantment( "Fire", "Inferno ", "+5 fire damage" ) },
                { "Ice", new Enchantment( "Ice", "Icy ", "+5 ice damage" ) },
                { "LifeSteal", new Enchantment( "LifeSteal", "Vampire ", "+5 life steal" ) },
                { "Agility", new Enchantment( "Agility", "Quick ", "+5 agility") },
                { "Strength", new Enchantment( "Strength", "Angry ", "+5 strength" ) }
            };
    }
}
