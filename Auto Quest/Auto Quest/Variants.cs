using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Auto_Quest
{
    public class Database //Database is used as a database to keep all different equipment, rarities and others in one variable
    {
        Random random;
        //Constructor
        public Database()
        {
            random = new Random(); //Everyting has to use the same random, otherwise if generated too closely they'll use the same seed
            AddEnemiesToList();
            AddWeaponsToList();
            AddHelmsToList();
            AddBreastplatesToList();
            AddGreavesToList();
            AddBootsToList();
            AddSpecialsToList();
            AddEquipmentToList();
        }

        //Rarities
        public readonly Dictionary<int, string> rarities = new Dictionary<int, string>
        {
            {0, "Common"},
            {1, "Uncommon" },
            {2, "Rare" },
            {3, "Epic" },
            {4, "Legendary" },
            {5, "Mythical" }
        };

        //A list of all enemy types
        public dynamic[] enemies;
        public void AddEnemiesToList()
        {
            dynamic[] enemiesToAdd = {
                new Wolf(random),
                new Slime(random),
                
            };
            this.enemies = enemiesToAdd;
        }

        //Weaknesses are Heavy, Light, Magic, Ranged
        //List of all Weapons
        public Weapon[] weaponList; //Finished
        public void AddWeaponsToList()
        {
            Weapon[] weaponsToAdd = {
                //Common
                new Weapon("Axe", 5, 0.25, 0, 100, "Heavy"),
                new Weapon("Shovel", 3, 0.5, 0, 100, "Light"),
                new Weapon("Lance", 10, 0.25, 0, 200, "Heavy"),
                new Weapon("Rapier", 5, 1.5, 0, 200, "Light"),
                new Weapon("Cannon", 100, 0.1, 0, 500, "Ranged"),
                new Weapon("Two Handed Sword", 10, 0.5, 0, 500, "Heavy"),
                new Weapon("One Handed Sword", 5, 1, 0, 500, "Light"),
                new Weapon("Bow", 7, 1.2, 0, 300, "Ranged"),
                new Weapon("Mace", 9, 0.9, 0, 500, "Light"),
                new Weapon("Dagger", 3, 3, 0, 300, "Light"),
                //Uncommon
                new Weapon("Ball and Chain", 10, 1, 1, 750, "Heavy"),
                new Weapon("Water Staff", 2, 0.25, 1, 400, "Magic", "Ranged"),
                new Weapon("Long Bow", 12, 0.5, 1, 750, "Ranged"),
                new Weapon("Spear", 15, 0.4, 1, 750, "Heavy"),
                new Weapon("Cutlass", 10, 1, 1, 750, "Light"),
                new Weapon("Great Sword", 15, 0.5, 1, 1000, "Heavy"),
                new Weapon("Large Scythe", 20, 0.4, 1, 1100, "Heavy"),
                new Weapon("Throwing Axe", 10, 1.2, 1, 900, "Ranged", "Light"),
                new Weapon("Small Scythe", 8, 1.5, 1, 800, "Light"),
                //Rare
                new Weapon("Fire Staff", 4, 0.25, 2, 1200, "Magic", "Light"),
                new Weapon("Heavy Crossbow", 25, 0.5, 2, 1200, "Ranged", "Heavy"),
                new Weapon("Nun Chuks", 10, 2, 2, 1500, "Light"),
                new Weapon("Recurve Bow", 15, 1, 2, 1600, "Ranged"),
                new Weapon("Javelin", 25, 0.5, 2, 1500, "Ranged", "Heavy"),
                new Weapon("Whip", 15, 1, 2, 1500, "Light", "Ranged"),
                new Weapon("Long Sword", 20, 0.75, 2, 1750, "Light", "Heavy"),
                new Weapon("Sabre", 15, 1, 2, 1750, "Light"),
                new Weapon("Flail", 12, 1.1, 2, 1750, "Light", "Heavy"),
                new Weapon("Halberd", 16, 1, 2, 1900, "Heavy"),
                new Weapon("Hunting Sword", 20, 0.8, 2, 2000, "Heavy"),
                new Weapon("Electric Staff", 4, 1, 2, 1500, "Magic", "Ranged"),
                new Weapon("Katana", 20, 1.5, 2, 2000, "Light"),
                new Weapon("Butterfly Knife", 10, 5, 2, 2200, "Light"),
                new Weapon("RPG", 200, 0.5, 2, 2500, "Ranged"),
                //Epic
                new Weapon("Sapphire Dragon Sword", 50, 1.2, 3, 4000, "Light"),
                new Weapon("Ruby Dragon Sword", 60, 1.0, 3,  4100, "Heavy"),
                new Weapon("Emerald Dragon Sword", 55, 1.1, 3, 4200, "Light"),
                new Weapon("Gold Dragon Sword", 70, 1.1, 3, 4300,"Heavy"),
                new Weapon("Diamond Dragon Sword", 75, 1.5, 3, 4500,"Light", "Magic"),
                new Weapon("Blackscaled Dagger", 20, 5, 3, 5000, "Light"),
                new Weapon("Shadow Dagger", 10, 10, 3, 5500, "Light", "Magic"),
                new Weapon("Frostfire Dagger", 25, 5, 3, 5500, "Light", "Magic"),
                new Weapon("Poisoned Dagger", 10, 10, 3, 5200, "Light", "Magic"),
                new Weapon("Frostfire Staff", 10, 1, 3, 4000, "Magic", "Ranged"),
                new Weapon("Staff of Destruction", 25, 0.75, 3, 4000, "Magic", "Ranged"),
                new Weapon("Shadow Staff", 5, 2, 3, 4000, "Magic", "Ranged"),
                new Weapon("Blackfrost Axe", 100, 0.9, 3, 5200, "Heavy", "Magic"),
                new Weapon("Lighting Axe", 50, 2, 3, 5200, "Heavy", "Magic"),
                new Weapon("Molten Axe", 75, 1.5, 3, 5500, "Heavy", "Magic"),
                //Legendary
                new Weapon("Mjølner", 150, 1, 4, 7500, "Ranged", "Magic"),
                new Weapon("Yatagarasu", 200, 0.8, 4, 7500, "Light", "Magic"),
                new Weapon("Petrified Axe", 175, 0.9, 4, 7600, "Heavy", "Light"),
                new Weapon("Dark Matter Dagger", 50, 4, 4, 10000, "Heavy", "Magic"),
                new Weapon("Sword of The Old One", 500, 0.5, 4, 8000, "Heavy", "Light"),
                new Weapon("Dragon Breath Sword", 155, 1.1, 4, 10000,"Light", "Magic"),
                new Weapon("Tempest Bow", 200, 0.8, 4, 10000, "Ranged", "Magic"),
                new Weapon("Staff of Echoes", 75, 1, 4, 10000, "Ranged", "Magic"),
                new Weapon("Divine Staff", 50, 1, 4, 5500, "Ranged", "Magic"),
                new Weapon("Divine Bow", 150, 1, 4, 6000, "Light", "Ranged"),
                new Weapon("Divine Sword", 125, 1.1, 4, 6000, "Light", "Magic"),
                new Weapon("Divine Axe", 150, 1, 4, 6000, "Light", "Heavy"),
                new Weapon("Divine Dagger", 50, 5, 4, 6000, "Light", "Magic"),
                //Mythical
                new Weapon("Dagger of The Dark God", 200, 5, 5, 20000, "Light", "Magic"),
                new Weapon("Axe of The Dark God", 500, 2, 5, 20000, "Heavy", "Magic"),
                new Weapon("Staff of The Dark God", 100, 1, 5, 20000, "Ranged", "Magic"),
                new Weapon("Bow of The Dark God", 750, 1.5, 5, 20000, "Ranged", "Magic"),
                new Weapon("Sword of The Dark God", 500, 2, 5, 20000, "Light", "Magic"),
                new Weapon("Devil's Dagger", 150, 10, 5, 20000, "Light", "Magic"),
                new Weapon("Sword from The Center of The Universe", 1000, 1.5, 5, 30000, "Light", "Magic"),
                new Weapon("Heaven's Bow", 2000, 1.25, 5, 30000, "Ranged", "Magic"),
                new Weapon("Axe of The Fallen Emperor", 2500, 1, 5, 30000, "Heavy", "Magic"),
                new Weapon("Staff of The Void", 500, 1.1, 5, 30000, "Ranged", "Magic"),
            };
            this.weaponList = weaponsToAdd;
        }

        //List of all helms
        public Helm[] helmList; //Not finished
        public void AddHelmsToList()
        {
            Helm[] helmsToAdd = {
                //Common
                new Helm("Plastic Bag", 0, 10, 0, 1, 0, "Light", 0, 0, 5, 0, 0),
                new Helm("Wooden Helmet", 0, 75, 0, 1, 1, "Heavy", 1, 1, 0, 0, 1),
                new Helm("Santa Hat", 0, 150, 0, 0, 10, "Magic", 0, 0, 10, 10, 0),
                new Helm("Pumpkin", 0, 150, 0, 2, 5, "Heavy", 0, 0, 0, 0, 0),
                new Helm("Water Melon", 0, 150, 10, 0, 0, "Ranged", 2, 10, 0, 0, 1),
                new Helm("Skull", 0, 400, 10, 10, 10, "Heavy", 3, 0, 0, 0, 3),
                new Helm("Tin Can", 0, 350, 0, 10, 0, "Heavy", 10, 0, 0, 0, 0),
                new Helm("Bronze Helmet", 0, 500, 10, 1, 0, "Light", 0, 5, 0, 5, 0),
                new Helm("Wizard Hat", 0, 500, 10, 0, 20, "Magic", 0, 10, 5, 20, 0),
                new Helm("Halloween Mask", 0, 350, 0, 5, 5, "Ranged", 5, 5, 5, 5, 0),
                new Helm("Plastic Crown", 0, 350, 0, 0, 10, "Light", 10, 1, 5, 15, 0),
                //Uncommon
                new Helm("Leather Helmet", 1, 600, 10, 0, 0, "Light", 5, 0, 10, 5, 1),
                new Helm("Bird Mask", 1, 700, 10, 0, 0, "Ranged", 10, 10, 10, 10, 0),
                new Helm("Steel Bucket", 1, 600, 0, 10, 0, "Heavy", 5, 15, 0, 0, 5),
                new Helm("Glasses", 1, 900, 0, 5, 0, "Ranged", 10, 20, 0, 20, 0),
                new Helm("Fez", 1, 1100, 5, 5, 10, "Magic", 0, 0, 10, 30, 1),
                new Helm("Top Hat", 1, 1200, 0, 10, 5, "Light", 5, 0, 10, 40, 2),
                new Helm("Bycicle Helmet", 1, 1300, 10, 0, 0, "Light", 10, 10, 30, 5, 0),
                new Helm("Workout Headband", 1, 1400, 20, 5, 0, "Heavy", 5, 10, 10, 5, 5),
                new Helm("Sans Mask", 1, 1500, 100, 0, 20, "Magic", 0, 0, 10, 0, 5),
                //Rare
                new Helm("Steel Helmet", 2, 1600, 0, 20, 0, "Heavy", 10, 5, 0, 10, 5),
                new Helm("Alien Mask", 2, 1700, 10, 5, 30, "Magic", 0, 0, 5, 0, 0),
                new Helm("Biker Helmet", 2, 1800, 20, 0, 0, "Light", 15, 20, 30, 10, 0),
                new Helm("Explorer's Hat", 2, 1900, 0, 0, 0, "Ranged", 0, 0, 50, 30, 1),
                new Helm("Nurse Cap", 2, 2000, 0, 5, 10, "Light", 0, 0, 10, 50, 0),
                new Helm("Warm Fuzzy Furr Hoody", 2, 2100, 20, 5, 0, "Heavy", 0, 10, 0, 10, 3),
                new Helm("Crocodile Mask", 2, 2200, 5, 30, 0, "Heavy", 30, 0, 5, 0, 7),
                new Helm("Builder's Helmet", 2, 2300, 10, 5, 0, "Light", 20, 20, 5, 10, 5),
                new Helm("Steel Crown", 2, 2400, 5, 10, 30, "Magic", 0, 5, 5, 50, 0),
                new Helm("Pilot Goggles", 2, 2500, 10, 5, 0, "Light", 5, 20, 40, 20, 0),
                //Epic
            };
            this.helmList = helmsToAdd;
        }

        //List of all breastplates
        public Breastplate[] breastplateList; //Not finished
        public void AddBreastplatesToList()
        {
            Breastplate[] breastplatesToAdd = {
                //Common
                new Breastplate("Paper", 0, 20, 1, 0, 0, "Light", 0, 0, 1, 0, 0),
            };
            this.breastplateList = breastplatesToAdd;
        }

        //List of all greaves
        public Greaves[] greavesList; //Not finished
        public void AddGreavesToList()
        {
            Greaves[] greavesToAdd = {
                //Common
                new Greaves("Paper Greaves", 0, 40, 1, 2, 0, "Light", 0, 5, 1, 0, 0),
            };
            this.greavesList = greavesToAdd;
        }

        //List of all boots
        public Boots[] bootsList; //Not finished
        public void AddBootsToList()
        {
            Boots[] bootsToAdd = {
                //Common
                new Boots("Paper Boots", 0, 50, 5, 0, 0, "Light", 0, 0, 10, 0, 0),
            };
            this.bootsList = bootsToAdd;
        }

        //List of all boots
        public Special[] specialsList; //Not finished
        public void AddSpecialsToList()
        {
            Special[] specialsToAdd = {
                //Common
                new Special("Paper Amulet", 0, 30, 0, 3, 0, "Light", 5, 0, 1, 1, 1),
            };
            this.specialsList = specialsToAdd;
        }


        //Adds all equipment type arrays to an array
        public Equipment[][] equipment;
        public void AddEquipmentToList()
        {
            Equipment[][] equipmentToAdd = {
                weaponList,
                helmList,
                breastplateList,
                greavesList,
                bootsList,
                specialsList,

            };
            this.equipment = equipmentToAdd;
        }
    }

    //Player weapon class
    public class Weapon : Equipment
    {
        public int attack; //Attack stat of weapon
        public double attackSpeed; //Attackspeed in seconds (Aka. 2 attackspeed = 2 times per second)
        public string weaponClass; //Weapon class used to determine whether the enemy is weak to player weapon
        public string weaponClass2;

        //2 constructors. 1 if the weapon only has 1 weaponclass, 2 if the weapon has 2 wepaonclasses
        public Weapon(string name, int attack, double attackSpeed, int rarity, int price, string weaponClass)
        {
            this.name = name;
            this.attack = attack;
            this.attackSpeed = attackSpeed;
            this.rarity = rarity;
            this.price = price;
            this.weaponClass = weaponClass;
        }
        public Weapon(string name, int attack, double attackSpeed, int rarity, int price, string weaponClass, string weaponClass2)
        {
            this.name = name;
            this.attack = attack;
            this.attackSpeed = attackSpeed;
            this.rarity = rarity;
            this.price = price;
            this.weaponClass = weaponClass;
            this.weaponClass2 = weaponClass2;
        }
    }


    //Base Enemy class. EnemyVariants.cs contain children of Enemy class.
    public class Enemy
    {
        public string name; //Name is decided by rarity.
        public int maxHp; //Max HP is the enemy's maximum hp.
        public int currentHp; //CurrentHP is the current hp of the enemy
        public double armor; //Armor of the enemy. Reduces dmg taken.
        public double magicResist; //Reduces the magic damage taken.
        public int experience; //Experience the player receives after killing the enemy
        public Item drop; //The item drop of the enemy. Its rarity is decided by the enemy rarity
        public string weakness; //The wepaonclass that this enemy is weak to.
        public int rarity;
        //Rarity directly decides which rarity of the enemy it is. Rarity of enemy also partially affects the rarity of its item

        //Items list of a list of the items the enemy can drop.
        public Dictionary<int, string> items;
        //enemyNames is a list of the names the enemy can have. It depends on rarity.
        public Dictionary<int, string> enemyNames;

        //Gives the enemy a rarity
        public virtual int AddRarity(int min, int max, Random random)
        {
            
            object syncLock = new object();
            int randomNum = random.Next(min, max);
            //Generates an rarity
            int number;
            switch (randomNum)
            {
                case int n when n <= 60:
                    number = 0;
                    break;
                case int n when n <= 80:
                    number = 1; ;
                    break;
                case int n when n <= 90:
                    number = 2; ;
                    break;
                case int n when n <= 95:
                    number = 3; ;
                    break;
                case int n when n <= 99:
                    number = 4; ;
                    break;
                case int n when n <= 100:
                    number = 5; ;
                    break;
                default:
                    number = 0; ;
                    break;
            }
            return number;
        }

        //Item has a higher chance of being rare depening on the enemy rarity
        public virtual Item AddItem(Random random)
        {
            //Selects random number to determine item rarity (ITEMS ARE WORK IN PROGRESS)
            int randomNum = random.Next(0, 100);
            int worth = 1;
            //Generates an item
            Item item = new Item("Yo",1,1);
            switch (randomNum)
            {
                case int n when n <= 60 - (rarity * 10):
                    item = new Item(items[0], worth, 0);
                    break;
                case int n when n <= 80 - (rarity * 8):
                    item = new Item(items[1], worth, 1);
                    break;
                case int n when n <= 90 - (rarity * 6):
                    item = new Item(items[2], worth, 2);
                    break;
                case int n when n <= 95 - (rarity * 4):
                    item = new Item(items[3], worth, 3);
                    break;
                case int n when n <= 99 - (rarity * 2):
                    item = new Item(items[4], worth, 4);
                    break;
                case int n when n <= 100:
                    item = new Item(items[5], worth, 5);
                    break;
                default:
                    item = new Item(items[7], worth, 0);
                    break;
            }
            item.worth = item.worth + item.rarity + rarity;
            return item;
        }

        //Generates a name depending on the enemy rarity
        public virtual string AddName()
        {
            string name = enemyNames[rarity];
            return name;
        }
    }

    public class Buff
    {
        public string name;
        public int id;
        public string description;

        public Buff(string name, string description, int id)
        {
            this.name = name;
            this.description = description;
            this.id = id;
        }
    } //Not used

    //Player classes
    public class Classes
    {

    } //Not used

    //Item drop from an enemy
    public class Item
    {
        public string name;
        public int worth;
        public int rarity;

        public Item(string name, int worth, int rarity)
        {
            this.name = name;
            this.worth = worth;
            this.rarity = rarity;
        }
    }

    public class Equipment
    {
        public string name;
        public int rarity;
        public int price;
    }

    //Player helm class
    public class Helm : Equipment
    {
        public int bonusAttackspeed;
        public int bonusAttackdamage;
        public int bonusMagicdamage;
        public string bonusClassdamage;
        public int bonusCritdamage;
        public int bonusCritchance;
        public int bonusSpeed;
        public int bonusCharisma;
        public int bonusStrength;

        public Helm(string name, int rarity, int price, int bonusAttackspeed, int bonusAttackdamage, int bonusMagicdamage, string bonusClassdamage, int bonusCritdamage, int bonusCritchance, int bonusSpeed, int bonusCharisma, int bonusStrength)
        {
            this.name = name;
            this.rarity = rarity;
            this.price = price;
            this.bonusAttackspeed = bonusAttackspeed;
            this.bonusAttackdamage = bonusAttackdamage;
            this.bonusMagicdamage = bonusMagicdamage;
            this.bonusClassdamage = bonusClassdamage;
            this.bonusCritdamage = bonusCritdamage;
            this.bonusCritchance = bonusCritchance;
            this.bonusSpeed = bonusSpeed;
            this.bonusCharisma = bonusCharisma;
            this.bonusStrength = bonusStrength;
        }
    }

    //Player breastplate class
    public class Breastplate : Equipment
    {
        public int bonusAttackspeed;
        public int bonusAttackdamage;
        public int bonusMagicdamage;
        public string bonusClassdamage;
        public int bonusCritdamage;
        public int bonusCritchance;
        public int bonusSpeed;
        public int bonusCharisma;
        public int bonusStrength;

        public Breastplate(string name, int rarity, int price, int bonusAttackspeed, int bonusAttackdamage, int bonusMagicdamage, string bonusClassdamage, int bonusCritdamage, int bonusCritchance, int bonusSpeed, int bonusCharisma, int bonusStrength)
        {
            this.name = name;
            this.rarity = rarity;
            this.price = price;
            this.bonusAttackspeed = bonusAttackspeed;
            this.bonusAttackdamage = bonusAttackdamage;
            this.bonusMagicdamage = bonusMagicdamage;
            this.bonusClassdamage = bonusClassdamage;
            this.bonusCritdamage = bonusCritdamage;
            this.bonusCritchance = bonusCritchance;
            this.bonusSpeed = bonusSpeed;
            this.bonusCharisma = bonusCharisma;
            this.bonusStrength = bonusStrength;
        }
    }

    //Player Greaves class
    public class Greaves : Equipment
    {
        public int bonusAttackspeed;
        public int bonusAttackdamage;
        public int bonusMagicdamage;
        public string bonusClassdamage;
        public int bonusCritdamage;
        public int bonusCritchance;
        public int bonusSpeed;
        public int bonusCharisma;
        public int bonusStrength;

        public Greaves(string name, int rarity, int price, int bonusAttackspeed, int bonusAttackdamage, int bonusMagicdamage, string bonusClassdamage, int bonusCritdamage, int bonusCritchance, int bonusSpeed, int bonusCharisma, int bonusStrength)
        {
            this.name = name;
            this.rarity = rarity;
            this.price = price;
            this.bonusAttackspeed = bonusAttackspeed;
            this.bonusAttackdamage = bonusAttackdamage;
            this.bonusMagicdamage = bonusMagicdamage;
            this.bonusClassdamage = bonusClassdamage;
            this.bonusCritdamage = bonusCritdamage;
            this.bonusCritchance = bonusCritchance;
            this.bonusSpeed = bonusSpeed;
            this.bonusCharisma = bonusCharisma;
            this.bonusStrength = bonusStrength;
        }
    }

    //Player Boots class
    public class Boots : Equipment
    {
        public int bonusAttackspeed;
        public int bonusAttackdamage;
        public int bonusMagicdamage;
        public string bonusClassdamage;
        public int bonusCritdamage;
        public int bonusCritchance;
        public int bonusSpeed;
        public int bonusCharisma;
        public int bonusStrength;

        public Boots(string name, int rarity, int price, int bonusAttackspeed, int bonusAttackdamage, int bonusMagicdamage, string bonusClassdamage, int bonusCritdamage, int bonusCritchance, int bonusSpeed, int bonusCharisma, int bonusStrength)
        {
            this.name = name;
            this.rarity = rarity;
            this.price = price;
            this.bonusAttackspeed = bonusAttackspeed;
            this.bonusAttackdamage = bonusAttackdamage;
            this.bonusMagicdamage = bonusMagicdamage;
            this.bonusClassdamage = bonusClassdamage;
            this.bonusCritdamage = bonusCritdamage;
            this.bonusCritchance = bonusCritchance;
            this.bonusSpeed = bonusSpeed;
            this.bonusCharisma = bonusCharisma;
            this.bonusStrength = bonusStrength;
        }
    }

    //Player Special Class
    public class Special : Equipment
    {
        public int bonusAttackspeed;
        public int bonusAttackdamage;
        public int bonusMagicdamage;
        public string bonusClassdamage;
        public int bonusCritdamage;
        public int bonusCritchance;
        public int bonusSpeed;
        public int bonusCharisma;
        public int bonusStrength;

        public Special(string name, int rarity, int price, int bonusAttackspeed, int bonusAttackdamage, int bonusMagicdamage, string bonusClassdamage, int bonusCritdamage, int bonusCritchance, int bonusSpeed, int bonusCharisma, int bonusStrength)
        {
            this.name = name;
            this.rarity = rarity;
            this.price = price;
            this.bonusAttackspeed = bonusAttackspeed;
            this.bonusAttackdamage = bonusAttackdamage;
            this.bonusMagicdamage = bonusMagicdamage;
            this.bonusClassdamage = bonusClassdamage;
            this.bonusCritdamage = bonusCritdamage;
            this.bonusCritchance = bonusCritchance;
            this.bonusSpeed = bonusSpeed;
            this.bonusCharisma = bonusCharisma;
            this.bonusStrength = bonusStrength;
        }
    }
}
