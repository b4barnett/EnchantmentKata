using FluentAssertions;
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

        [ SetUp]
        public void Setup()
        {
            _weapon = new Weapon()
            {
                Name = BaseName,
                AttackDamage = AttackDamage,
                AttackSpeed = AttackSpeed
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
        [TestCase( "Fire", "Inferno", "+5 fire damaage")]
        [TestCase( "Ice", "Icy", "+5 ice damager")]
        [TestCase( "LifeSteal", "Vampire", "+5 life steal")]
        [TestCase( "Agility", "Quick", "+5 agility")]
        [TestCase( "Strength", "Angry", "+5 strength") ]
        public void EnchantmentTest( string enchantment, string name, string effect)
        {
            _weapon.Enchant();

            _weapon.Name.Should().Be( name );
            _weapon.AttackDamage.Should().Be( AttackDamage );
            _weapon.AttackSpeed.Should().Be( AttackSpeed );
            _weapon.Effect.Should().Be( effect );
        }
    }
}
