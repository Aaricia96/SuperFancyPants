using SuperFancyPants.Domain.Interface;

namespace SuperFancyPants.Domain
{
    public class WeepingAngel : IMonster
    {
        public string Reaction { get { return "don't blink"; } }
        public string PrintMessage()
        {
            return "A wild weeping angel appeared.";
        }

        public string Name { get { return "Weeping Angel"; } }
    }
}
