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
    public class EnchantmentProviderTests
    {
        private IEnchantmentProvider _provider;
        private Mock<IRandomNumberGenerator> _randomNumberGenerator;

        [SetUp]
        public void Setup()
        { 
            _randomNumberGenerator = new Mock<IRandomNumberGenerator>();
            _provider = new EnchantmentProvider( Helper.Enchantments.Values.ToList(), _randomNumberGenerator.Object );
        }


        [TestCase( "Fire", 0 )]
        [TestCase( "Ice", 1 )]
        [TestCase( "LifeSteal", 2 )]
        [TestCase( "Agility", 3 )]
        [TestCase( "Strength", 4 )]
        public void TestEachEnchancement( string enhancementName, int index )
        {
            _randomNumberGenerator.Setup( x => x.GetNumber( 0, 4 ) ).Returns( index );

            _provider.GetRandomEnchantment().Name.Should().Be( enhancementName );
        }

    }
}
