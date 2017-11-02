﻿using SuperFancyPants.Domain.Interface;

namespace SuperFancyPants.Domain
{
    public class WeepingAngel : IMonster
    {
        public int Health { get { return Health; } set { Health = value; } }

        public string Reaction { get { return "don't blink"; } }

        public WeepingAngel()
        {
            //Health = 5;
        }

        public void Fight()
        {
            Health -= 2;
        }

        public string PrintMessage()
        {
            return "A wild weeping angel appeared.";
        }

        public string Name { get { return "Weeping Angel"; } }
    }
}
