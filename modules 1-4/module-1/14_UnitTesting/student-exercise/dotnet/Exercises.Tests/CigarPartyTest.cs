using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class CigarPartyTest
    {
        [TestMethod]
        public void CigarPartyWithFiftyCigarsReturnsTrue()
        {
            //arrange
            CigarParty party = new CigarParty();

            //act
            bool partyWeekend = party.HaveParty(50, true);
            bool partyWeekDay = party.HaveParty(50, false);

            //assert
            Assert.AreEqual(true, partyWeekDay);
            Assert.AreEqual(true, partyWeekend);
        }

        [TestMethod]
        public void CigarPartyWithFortyCigarsReturnsTrue()
        {
            //arrange
            CigarParty party = new CigarParty();

            //act
            bool partyWithForty = party.HaveParty(40, false);

            //assert
            Assert.AreEqual(true, partyWithForty);
        }

        [TestMethod]
        public void CigarPartyWithSixtyCigarsReturnsTrue()
        {
            //arrange
            CigarParty party = new CigarParty();

            //act
            bool partyWithSixty = party.HaveParty(60, false);

            //assert
            Assert.AreEqual(true, partyWithSixty);
        }

        [TestMethod]
        public void CigarPartyWithTooManyCigarsOnWeekdayReturnsFalse()
        {
            //arrange
            CigarParty party = new CigarParty();

            //act
            bool partyWithTooMany = party.HaveParty(270, false);

            //assert
            Assert.AreEqual(false, partyWithTooMany);
        }

        [TestMethod]
        public void CigarPartyWithLotsOfCigarsOnWeekendReturnsTrue()
        {
            //arrange
            CigarParty party = new CigarParty();

            //act
            bool partyWithLots = party.HaveParty(270, true);

            //assert
            Assert.AreEqual(true, partyWithLots);
        }

    }
}
