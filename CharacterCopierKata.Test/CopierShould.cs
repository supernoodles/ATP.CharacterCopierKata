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
            var copier = new Copier(destination);

            copier.Copy();

            destination.Letters.Should().Be(string.Empty);
        }

        [Test]
        public void CopyA_GivenAandNewLine()
        {
            var destination = new DestinationMock();
            var copier = new Copier(destination);

            copier.Copy();

            destination.Letters.Should().Be("A");
        }
    }

    public class SourceStub :ISource
    {
        public char GetChar()
        {
            return '\n';
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