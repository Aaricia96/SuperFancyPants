using SuperFancyPants.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFancyPants.Domain
{
    public class Dalek : IMonster
    {
        public string Reaction { get { return "exterminate"; } }

        public string PrintMessage()
        {
            return "A wild dalek appeared.";
        }

        public string Name { get { return "Dalek"; } }
    }
}
