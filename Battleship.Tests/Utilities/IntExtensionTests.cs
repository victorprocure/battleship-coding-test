using Battleship.CLI.Utilities;
using Xunit;
using System;

namespace Battleship.Tests.Utilities
{
    public class IntExtensionTests
    {
        [Fact]
        public void GivenNumberShouldReturnLetter()
        {
            var num = 2;

            var letter = num.ToAlphabetLetter();
            
            Assert.Equal("B", letter);
        }

        [Fact]
        public void GivenNumberGreaterThan26ReturnDoubleLetter()
        {
            var num = 27;
            
            var letter = num.ToAlphabetLetter();

            Assert.Equal("AA", letter);
        }

        [Fact]
        public void GivenInvalidNumberShouldThrowRangeError()
        {
            var num = 0; 

            Assert.Throws<ArgumentOutOfRangeException>(() => num.ToAlphabetLetter());
        }
    }
}