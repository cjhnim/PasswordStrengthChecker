using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrengthChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordStrengthChecker.Tests
{
    [TestClass]
    public class PasswordCheckerTests
    {
        // Test IsAcceptablePassword
        [TestMethod]
        /*  inputPasswd | isAcceptable  */
        [DataRow("", false)]            //BlankPasswordShouldNotBeAcceptable
        [DataRow("1234567A", true)]     //PasswordLongerThan7CharactersShouldBeAcceptable
        [DataRow("12345678", false)]    //PasswordLongerThan7CharactersButNoAlphabetShouldBeNotAcceptable
        [DataRow("ABCDEFGH", false)]    //PasswordLongerThan7CharactersButNoDigitShouldBeNotAcceptable
        [DataRow("ABCDEF1", false)]     //PasswordEqualsOrLessThan7ChractersShouldBeNotAcceptable
        public void UserPasswordHasLengthMoreThan7AndContainAlphabetAndDigits(string inputPasswd, bool isAcceptable)
        {
            Assert.AreEqual(isAcceptable, new PasswordChecker().IsAcceptablePassword(inputPasswd));
        }

        // Test IsAcceptablePasswordEx
        [TestMethod]
        /*  inputPasswd | isAdmin | isAcceptable  */
        [DataRow("1234567A", false, true)] //IfOneOfOurProspectiveCustomersShouldBeGivenFalseFlag
        [DataRow("1234567A!", true, false)] //AdminPasswordShouldBeEqualOrLongerThan10Characters
        [DataRow("12345678A!", true, true)] //AdminPasswordShouldBeEqualOrLongerThan10Characters
        [DataRow("123456789A", true, false)] //AdminPasswordShouldBeContainSpecialChracters
        public void AdminPasswordHasLengthMoreThan10andContainAlsoSpecialCharacters(string inputPasswd, bool isAdmin, bool isAcceptable)
        {
            Assert.AreEqual(isAcceptable, new PasswordChecker().IsAcceptablePasswordEx(inputPasswd, isAdmin));
        }

        // Test GetLastReasons
        [TestMethod]
        /*  inputPasswd | isAdmin | isAcceptable | reasonCount */
        [DataRow("1234567A", false, true, 0)]
        [DataRow("1234567", false, false, 2)]
        public void WeakPasswordHasReasons(string inputPasswd, bool isAdmin, bool isAcceptable, int reasonCount)
        {
            PasswordChecker checker = new PasswordChecker();
            Assert.AreEqual(isAcceptable, checker.IsAcceptablePasswordEx(inputPasswd, isAdmin));
            Assert.AreEqual(reasonCount, checker.GetLastReasons().Count);
        }

        [TestMethod]
        /*  inputPasswd | isAdmin | isAcceptable | reasons */
        [DataRow("1234567", false, false, WeakReasonType.Length, WeakReasonType.Alphabet)] //IfPasswordIsWeak_LastReasonShouldBeNotEmpty
        [DataRow("ABCDEFGH", false, false, WeakReasonType.Digits)]  // DigitReasons
        [DataRow("12345678", false, false, WeakReasonType.Alphabet)]  // AlphabetReasons
        [DataRow("12345678AB", true, false, WeakReasonType.Special)]  // SpecialCharactersReasons
        [DataRow("1234567890", true, false, WeakReasonType.Alphabet, WeakReasonType.Special)]  // CompositeReasonsForAdmin
        [DataRow("12345", false, false, WeakReasonType.Length, WeakReasonType.Alphabet)]  // CompositeReasonsForUser
        [DataRow("1234", true, false, WeakReasonType.Length, WeakReasonType.Alphabet, WeakReasonType.Special)]  // CompletelyWrongAdminPassword
        public void WeakPasswordHasReasonsList(string inputPasswd, bool isAdmin, bool isAcceptable, params WeakReasonType[] reasonTypes)
        {
            PasswordChecker checker = new PasswordChecker();

            Assert.AreEqual(isAcceptable, checker.IsAcceptablePasswordEx(inputPasswd, isAdmin));

            var expectReasons = reasonTypes.Select(r => new WeakReasons {Type = r}).ToList();

            CollectionAssert.AreEqual(expectReasons, checker.GetLastReasons());
        }
    }
}