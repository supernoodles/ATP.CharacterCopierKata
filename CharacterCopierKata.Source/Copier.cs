namespace CharacterCopierKata.Source
{
    public class Copier
    {
        private readonly IDestination _destination;

        public Copier(IDestination destination)
        {
            _destination = destination;
        }
        public void Copy()
        {
            _destination.SetChar('A');
        }
    }
}