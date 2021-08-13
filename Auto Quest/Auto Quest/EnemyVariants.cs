using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Auto_Quest
{
    //This file is for enemy inherited children.
    public class Slime : Enemy //Slime. Generally lots of hp, low armor and and gives low experience
    {
        public Slime(Random random)
        {
            enemyNames = new Dictionary<int, string>
            {
                {0, "Green Slime"},
                {1, "Aqua Blue Slime"},
                {2, "Fire Red Slime"},
                {3, "Rainbow Slime"},
                {4, "Golden Slime"},
                {5, "Diamond Slime"},
            };
            items = new Dictionary<int, string>
            {
                {0, "Slime Goo"},
                {1, "Slime Eye"},
                {2, "Slime Element"},
                {3, "Amulet of Sticky"},
                {4, "Scroll of Stickyness"},
                {5, "Goo Diamond"},
            };
            rarity = AddRarity(0, 101, random);
            maxHp = 5 * (rarity + 2);
            armor = 1 * (rarity);
            magicResist = 0;
            experience = 5 * (rarity + 1);
            currentHp = maxHp;
            weakness = "Heavy";
            drop = AddItem(random);
            name = AddName();
        }
    }

    public class Wolf : Enemy //Wolf has average hp, low-average armor, low magic resist and gives low experience
    {
        public Wolf(Random random)
        {
            enemyNames = new Dictionary<int, string>
            {
                {0, "Wolf"},
                {1, "Snow Wolf"},
                {2, "Saber Fanged Wolf"},
                {3, "Giant Wolf"},
                {4, "Possessed Wolf"},
                {5, "Werewolf"},
            };
            items = new Dictionary<int, string>
            {
                {0, "Wolf Skin"},
                {1, "Wolf Claw"},
                {2, "Wolf Fang"},
                {3, "Wolf Eye"},
                {4, "Wolf Heart"},
                {5, "Werewolf Pendant"},
            };
            rarity = AddRarity(0, 101, random);
            maxHp = 5 * (rarity + 1);
            armor = 1 * (rarity + 1);
            magicResist = 1;
            experience = 6 * (rarity + 1);
            currentHp = maxHp;
            weakness = "Ranged";
            drop = AddItem(random);
            name = AddName();
        }
    }
}
