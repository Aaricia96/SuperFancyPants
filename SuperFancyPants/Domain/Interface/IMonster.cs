using System;
using System.Collections.Generic;
using System.Text;

namespace SuperFancyPants.Domain.Interface
{
    public interface IMonster
    {
        string Reaction { get; }

        string PrintMessage();

        string Name { get; }
    }
}
