using Microwave.Classes.Boundary;
using Microwave.Classes.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Microwave.Test.Unit
{
    [TestFixture]
    public class BuzzerTest
    {
        private Buzzer uut;
        private IOutput output;

        [SetUp]
        public void Setup()
        {
            output = Substitute.For<IOutput>();
            uut = new Buzzer(output);
        }

        [Test]
        public void BuzzOnCookingDone_CorrectOutput()
        {
            uut.BuzzOnCookingDone();
            output.Received(1).OutputLine(
                Arg.Is<string>(str => 
                    str.Contains("Beeeep!...")));
        }

        [Test]
        public void BuzzOnButtonPress_CorrectOutput()
        {
            uut.BuzzOnButtonPress();
            output.Received(1).OutputLine(
                Arg.Is<string>(str =>
                    str.Contains("Beep!")));
        }
    }
}