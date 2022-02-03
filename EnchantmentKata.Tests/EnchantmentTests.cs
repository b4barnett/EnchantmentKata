using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnchantmentKata.Tests
{
    public class EnchantmentTests
    {
        private Weapon _weapon;
        private const string BaseName = "Dagger of the Nooblet";
        private const string AttackDamage = "5 - 10 attack damage";
        private const string AttackSpeed = "1.2 attack speed";
        private Dictionary<string, Enchantment> _enchantments;
        private Mock<IEnchantmentProvider> _mockEnchantmentProvider;

        [ SetUp]
        public void Setup()
        {
            _mockEnchantmentProvider = new Mock<IEnchantmentProvider>();
            _weapon = new Weapon( _mockEnchantmentProvider.Object, BaseName )
            {
                AttackDamage = AttackDamage,
                AttackSpeed = AttackSpeed
            };

            _enchantments = new Dictionary<string, Enchantment>()
            { 
                { "Fire", new Enchantment( "Fire", "Inferno ", "+5 fire damage" ) },
                { "Ice", new Enchantment( "Ice", "Icy ", "+5 ice damage" ) },
                { "LifeSteal", new Enchantment( "LifeSteal", "Vampire ", "+5 life steal" ) },
                { "Agility", new Enchantment( "Agility", "Quick ", "+5 agility") },
                { "Strength", new Enchantment( "Strength", "Angry ", "+5 strength" ) }
            };
        }

        [Test]
        public void BaseWeapon()
        {
            _weapon.Name.Should().Be( BaseName );
            _weapon.AttackDamage.Should().Be( AttackDamage );
            _weapon.AttackSpeed.Should().Be( AttackSpeed );
            _weapon.Effect.Should().Be( String.Empty );
        }

        //EnchantmentKey, Expected Name, Expected Effect
        [TestCase( "Fire", "Inferno ", "+5 fire damage")]
        [TestCase( "Ice", "Icy ", "+5 ice damage")]
        [TestCase( "LifeSteal", "Vampire ", "+5 life steal")]
        [TestCase( "Agility", "Quick ", "+5 agility")]
        [TestCase( "Strength", "Angry ", "+5 strength") ]
        public void EnchantmentTest( string enchantment, string name, string effect)
        {
            _mockEnchantmentProvider.Setup( x => x.GetRandomEnchantment() )
                                    .Returns( _enchantments[ enchantment ] );

            _weapon.Enchant();

            _weapon.Name.Should().Be( name + BaseName );
            _weapon.AttackDamage.Should().Be( AttackDamage );
            _weapon.AttackSpeed.Should().Be( AttackSpeed );
            _weapon.Effect.Should().Be( effect );
        }
    }
}
