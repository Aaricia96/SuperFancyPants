using SuperFancyPants.Domain;
using SuperFancyPants.Domain.Enum;
using SuperFancyPants.Domain.Interface;
using System;

namespace SuperFancyPants.Factory
{
    public class MonsterFactory
    {
        public IMonster CreateMonster(EMonster type)
        {
            switch (type)
            {
                case EMonster.Silence:
                    {
                        return new Silence();
                    }
                case EMonster.WeepingAngel:
                    {
                        return new WeepingAngel();
                    }
                case EMonster.Dalek:
                    {
                        return new Dalek();
                    }
                case EMonster.Cybermen:
                    {
                        return new Cybermen();
                    }
            }
            
            return null;
        } 
    }
}
