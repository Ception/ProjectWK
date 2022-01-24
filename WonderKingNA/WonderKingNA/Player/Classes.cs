using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WonderKingNA.Player {
    internal class Classes {
        public enum FirstJob {
            NULL,
            Swordsman = 1,
            Mage,
            Thief,
            Scout,
        }

        public enum SecondJob {
            Warrior = 5,
            Knight, //6
            Priest, //7	
            Wizard, //8
            Rogue, //9
            Ninja, //10
            Gunner, //11
            Archer, //12
        }

        public enum ThirdJob {
            Berserker = 13,
            Pladin,
            Saint, 
            Warlock,	
            Knave,
            Assassin,
            Gunslinger,
            Ranger,
        }


        public enum FourthJob {
            Juggernaut = 21,
            Temple_Knight,
            Exorcist,
            Necromancer,
            Raider,
            Nightstalker,
            Sharpshooter,
            Beast_Keeper,
        }
    }
}
