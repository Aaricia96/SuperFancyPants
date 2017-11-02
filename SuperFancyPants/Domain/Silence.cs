using SuperFancyPants.Domain.Interface;

namespace SuperFancyPants.Domain
{
    public class Silence : IMonster
    {
        public string Reaction { get { return "draw stripe"; } }

        public string PrintMessage()
        {
            return "A wild silence appeared.";
        }

        public string Name { get { return "Silence"; } }
    }
}
