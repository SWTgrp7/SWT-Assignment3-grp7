using Microwave.Classes.Boundary;
using Microwave.Classes.Interfaces;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;

namespace Microwave.Test.Unit
{
    [TestFixture]
    public class PowerTubeTest
    {
        private PowerTube uut;
        private IOutput output;

        [SetUp]
        public void Setup()
        {
            output = Substitute.For<IOutput>();
            uut = new PowerTube(output);
        }

        [TestCase(1)]
        [TestCase(50)]
        [TestCase(100)]
        [TestCase(699)]
        [TestCase(700)]
        public void TurnOn_WasOffCorrectPower_CorrectOutput(int power)
        {
            uut.TurnOn(power);
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains($"{power}")));
        }

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(701)]
        [TestCase(750)]
        public void TurnOn_WasOffOutOfRangePower_ThrowsException(int power)
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => uut.TurnOn(power));
        }

        [Test]
        public void TurnOff_WasOn_CorrectOutput()
        {
            uut.TurnOn(50);
            uut.TurnOff();
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains("off")));
        }

        [Test]
        public void TurnOff_WasOff_NoOutput()
        {
            uut.TurnOff();
            output.DidNotReceive().OutputLine(Arg.Any<string>());
        }

        [Test]
        public void TurnOn_WasOn_ThrowsException()
        {
            uut.TurnOn(50);
            Assert.Throws<System.ApplicationException>(() => uut.TurnOn(60));
        }

        [Test]
        public void GetMaxPowerInWatts_DefaultValue_CorrectValue()
        {
            Assert.That(uut.GetMaxPowerInWatts(), Is.EqualTo(700));
        }
        

        [TestCase(1)]
        [TestCase(500)]
        [TestCase(1000)]
        [TestCase(2399)]
        [TestCase(2400)]
        public void Get_Set_MaxPowerInWatts_NewValue_CorrectValue(int SetPower)
        {
            uut.SetMaxPowerInWatts(SetPower);
            Assert.That(uut.GetMaxPowerInWatts(), Is.EqualTo(SetPower));
        }
        
        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(2401)]
        [TestCase(2750)]
        public void SetMaxPowerInWatts_OutOfRangeValue_ThrowsException(int SetPower)
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => uut.SetMaxPowerInWatts(SetPower));
        }

       
    }
}