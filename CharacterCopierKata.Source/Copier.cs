namespace CharacterCopierKata.Source
{
    public class Copier
    {
        private readonly ISource _source;
        private readonly IDestination _destination;


        public Copier(ISource source, IDestination destination)
        {
            _source = source;
            _destination = destination;
        }

        public void Copy()
        {
            char character;

            while ((character = _source.GetChar()) != '\n')
            {
                _destination.SetChar(character);
            }
        }
    }
}