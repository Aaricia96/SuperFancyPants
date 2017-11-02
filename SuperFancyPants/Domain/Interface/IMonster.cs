using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFancyPants.Domain.Interface
{
    public interface IMonster
    {
        int Health { get; set; }

        string Reaction { get; }

        void Fight();

        string PrintMessage();

        string Name { get; }
    }
}
