using SuperFancyPants.Domain;
using SuperFancyPants.Domain.Enum;
using SuperFancyPants.Domain.Interface;
namespace SuperFancyPants.Factory
{
    public class MonsterFactory
    {
        public IMonster CreateMonster(EMonster type)
        {
            IMonster monster = null;

            switch(type)
            {
                case EMonster.Silence:
                    {
                        monster = new Silence();
                        break;
                    }
                case EMonster.WeepingAngel:
                    {
                        monster = new WeepingAngel();
                        break;
                    }
            }
            return monster;
        } 
    }
}
