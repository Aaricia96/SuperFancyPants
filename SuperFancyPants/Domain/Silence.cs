using SuperFancyPants.Domain.Interface;

namespace SuperFancyPants.Domain
{
    public class Silence : IMonster
    {
        public int Health { get { return Health; } set { Health = value; } }

        public string Reaction { get { return "draw stripe"; } }

        public Silence()
        {
            //Health = 10;
        }

        public void Fight()
        {
            Health -= 3;
        }

        public string PrintMessage()
        {
            return "A wild silence appeared.";
        }

        public string Name { get { return "Silence"; } }
    }
}
