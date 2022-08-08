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
        // Iteration 1
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

        // Iteration 2
        [TestMethod]
        public void IfOneOfOurProspectiveCustomersShouldBeGivenFalseFlag()
        {
            Assert.IsTrue(new PasswordChecker().IsAcceptablePasswordEx("1234567A", false));
        }

        [TestMethod]
        public void PasswordShouldBeEqualOrLongerThan10CharactersForAdmin()
        {
            Assert.IsFalse(new PasswordChecker().IsAcceptablePasswordEx("1234567A!", true));
            Assert.IsTrue(new PasswordChecker().IsAcceptablePasswordEx("12345678A!", true));
        }
    }
}