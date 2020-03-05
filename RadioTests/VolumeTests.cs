using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using RadioWPFApp;

namespace RadioTests
{
    public class VolumeTests
    {

        private Radio _radio;
        [SetUp]
        public void SetUp()
        {
            _radio = new Radio();
                _radio.TurnOn();
        }

        [TestCase(-1)]

        public void lowestVolumeTest(int volchange)
        {
            _radio.Volume = volchange;
            Assert.AreEqual(0, _radio.Volume);
        }

        [TestCase(101)]

        public void highestVolumeTest(int volchange)
        {
            _radio.Volume = volchange;
            Assert.AreEqual(100, _radio.Volume);
        }
    }
}
