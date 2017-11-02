using SuperFancyPants.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFancyPants.Domain
{
    public class Cybermen : IMonster
    {
        public string Reaction { get { return "delete"; } }

        public string PrintMessage()
        {
            return "A wild cybermen appeared.";
        }

        public string Name { get { return "Cybermen"; } }
    }
}
