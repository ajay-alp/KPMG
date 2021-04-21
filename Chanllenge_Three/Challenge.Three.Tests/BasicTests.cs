using NUnit.Framework;
using Challenge.Three;

namespace Challenge.Three.Tests
{
    public class Tests
    {
        object sut;

        [OneTimeSetUp]
        public void Setup()
        {
            sut = Program.CreateNestedObject();
        }

        [Test]
        [TestCase("a/b/c", ExpectedResult = "d")]
        [TestCase("a/b/x", ExpectedResult = null)]
        public object GetValueFromNestedObject_WhenObjectAndKeyAreProvided(string key)
        {
            return Program.GetNestedValue(sut, key);
        }

    }
}