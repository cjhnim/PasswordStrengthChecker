using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrengthChecker;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordStrengthChecker.Tests
{
    [TestClass]
    public class PasswordCheckerTests
    {
        [TestMethod]
        public void BlankPasswordShouldNotBeAcceptable()
        {
            Assert.IsFalse(new PasswordChecker().IsAcceptablePassword(""));
        }

        [TestMethod]
        public void PasswordLongerThan7CharactersShouldBeAcceptable()
        {
            Assert.IsTrue(new PasswordChecker().IsAcceptablePassword("1234567A"));
        }

        [TestMethod]
        public void PasswordLongerThan7CharactersButNoAlphabetShouldBeNotAcceptable()
        {
            Assert.IsFalse(new PasswordChecker().IsAcceptablePassword("12345678"));
        }

        [TestMethod]
        public void PasswordLongerThan7CharactersButNoDigitShouldBeNotAcceptable()
        {
            Assert.IsFalse(new PasswordChecker().IsAcceptablePassword("ABCDEFGH"));
        }

        [TestMethod]
        public void PasswordEqualsOrLessThan7ChractersShouldBeNotAcceptable()
        {
            Assert.IsFalse(new PasswordChecker().IsAcceptablePassword("ABCDEF1"));
        }
    }
}