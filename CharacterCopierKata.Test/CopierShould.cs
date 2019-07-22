namespace CharacterCopierKata.Test
{
    using FluentAssertions;
    using NUnit.Framework;
    using Source;
    using System;

    [TestFixture]
    public class CopierShould
    {
        private DestinationMock _destination;
        private SourceStub _source;
        private Copier _copier;

        [Test]
        public void NotCopy_GivenNewLine()
        {
            SetUpCopierWith("\n");

            _copier.Copy();

            _destination.Letters.Should().Be(string.Empty);
        }

        [Test]
        public void CopyA_GivenAandNewLine()
        {
            SetUpCopierWith("A\n");

            _copier.Copy();

            _destination.Letters.Should().Be("A");
        }

        [Test]
        public void Fail_GivenNoNewLine()
        {
            SetUpCopierWith("A");

            _copier.Invoking(copier => copier.Copy()).Should().Throw<Exception>();
        }

        [Test]
        public void CopyAB_GivenAandNewLine()
        {
            SetUpCopierWith("AB\n");

            _copier.Copy();

            _destination.Letters.Should().Be("AB");
        }


        private void SetUpCopierWith(string seed)
        {
            _destination = new DestinationMock();
            _source = new SourceStub(seed);
            _copier = new Copier(_source, _destination);
        }
    }

    public class SourceStub : ISource
    {
        private readonly string _seed;
        private int _counter = 0;

        public SourceStub(string seed)
        {
            _seed = seed;
        }

        public char GetChar()
            => _seed[_counter++];

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