namespace CharacterCopierKata.Test
{
    using FluentAssertions;
    using NUnit.Framework;
    using Source;

    [TestFixture]
    public class CopierShould
    {
        [Test]
        public void NotCopy_GivenNewLine()
        {
            var destination = new DestinationMock();
            var source = new SourceStub('\n');
            var copier = new Copier(source, destination);

            copier.Copy();

            destination.Letters.Should().Be(string.Empty);
        }

        [Test]
        public void CopyA_GivenAandNewLine()
        {
            var destination = new DestinationMock();
            var source = new SourceStub('A');
            var copier = new Copier(source, destination);

            copier.Copy();

            destination.Letters.Should().Be("A");
        }
    }

    public class SourceStub :ISource
    {
        private readonly char _seed;

        public SourceStub(char seed)
        {
            _seed = seed;
        }
        public char GetChar()
        {
            return _seed;
        }
    }

    public class DestinationMock : IDestination
    {
        public string Letters = string.Empty;
        public void SetChar(char letter)
        {
            Letters += letter;
        }
    }
}