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
        public void TestNotImplementMethod()
        {
            new PasswordChecker().IsAcceptablePassword(null);
        }
    }
}