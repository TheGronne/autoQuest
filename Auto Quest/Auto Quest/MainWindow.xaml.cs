using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Auto_Quest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Current equipment
        dynamic[] currentEquipment = new dynamic[6];

        //Current enemy
        Enemy currentEnemy;

        //Stats
        int attack;
        int intelligence;
        int speed;
        int charisma;
        double attackSpeed;
        int critChance;
        int magicDamage;
        int strength;
        int bonusCritDamage;

        //Current level experience
        int maxExperience;
        int currentExperience;
        int currentLevel = 1;

        //Inventory
        int currentGold = 1000;

        //List of Items
        List<Item> inventory = new List<Item>();

        //Timers
        System.Timers.Timer killingTimer = new System.Timers.Timer();
        System.Timers.Timer walkingTimer = new System.Timers.Timer();
        System.Timers.Timer sellingTimer = new System.Timers.Timer();

        //Datase
        Database database = new Database();

        //Equipment already owned
        List<dynamic> ownedEquipment = new List<dynamic>();

        //Runs when the program starts
        public MainWindow()
        {
            InitializeComponent();

            InsertTestData();

            SetUp();
            NewEnemy();
            UpdateAllUI();
        }

       
        //Gives the player a new equipment
        void AddEquipment(Weapon weapon, int i)
        {
            attack -= currentEquipment[0].attack;
            attackSpeed -= currentEquipment[0].attackSpeed;

            //Changes your current weapon
            currentEquipment[0] = weapon;
            attack += currentEquipment[0].attack;
            attackSpeed *= currentEquipment[0].attackSpeed;

            //Updates the weapon UI
            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application 
                killingTimer.Interval = (1000 / (attackSpeed / 100));
            }));
        }
        void AddEquipment(dynamic equipment, int i)
        {
            attack -= currentEquipment[i].bonusAttackdamage;
            attackSpeed -= currentEquipment[i].bonusAttackspeed;
            charisma -= currentEquipment[i].bonusCharisma;
            strength -= currentEquipment[i].bonusStrength;
            critChance -= currentEquipment[i].bonusCritchance;
            bonusCritDamage -= currentEquipment[i].bonusCritdamage;
            magicDamage -= currentEquipment[i].bonusMagicdamage;
            speed -= currentEquipment[i].bonusSpeed;

            //Changes your current weapon
            currentEquipment[1] = equipment;
            attack += currentEquipment[i].bonusAttackdamage;
            attackSpeed += currentEquipment[i].bonusAttackspeed;
            charisma += currentEquipment[i].bonusCharisma;
            strength += currentEquipment[i].bonusStrength;
            critChance += currentEquipment[i].bonusCritchance;
            bonusCritDamage += currentEquipment[i].bonusCritdamage;
            magicDamage += currentEquipment[i].bonusMagicdamage;
            speed += currentEquipment[i].bonusSpeed;


            //Updates the weapon UI
            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application 
                killingTimer.Interval = (1000 / (attackSpeed / 100));
            }));
        }

        //Generates a new enemy
        void NewEnemy()
        {
            database.AddEnemiesToList();
            //Will randomly generate an enemy later
            Random random = new Random();
            int randomNum = random.Next(0, database.enemies.Length);
            Enemy enemy = database.enemies[randomNum];

            Console.WriteLine(randomNum);
            Console.WriteLine(database.enemies[0].name);
            Console.WriteLine(database.enemies[0].rarity);
            Console.WriteLine(database.enemies[1].name);
            Console.WriteLine(database.enemies[1].rarity);

            enemy.maxHp *= currentLevel;
            enemy.currentHp = enemy.maxHp;
            enemy.experience *= (int)Math.Round((double)currentLevel / 2 + 0.1);
            
            currentEnemy = enemy;
            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application 
                ProgressTitle.Content = "Slaying " + currentEnemy.name;
                ProgressBar.Value = 0;
                ProgressBar.Maximum = currentEnemy.maxHp;
            }));
            
            UpdateAllUI();
        }

        //Attacks the monster
        void AttackMonster(Object source, ElapsedEventArgs e)
        {
            //Damage calculation
            int damageDealt = attack - (int)Math.Round(currentEnemy.armor);

            //Break damage is the super effective damage against the enemy's weakness. Breaking their defensive
            int breakDamage = 1;
            //If the enemy has a weakness to current weapon
            if (currentEquipment[0].weaponClass == currentEnemy.weakness || currentEquipment[0].weaponClass2 == currentEnemy.weakness)
            {
                breakDamage += 1;
            }
            //Checks all other equipment's bonusClassdamage
            for (int i = 1; i < currentEquipment.Length; i++)
            {
                if (currentEquipment[i].bonusClassdamage == currentEnemy.weakness)
                {
                    breakDamage += 1;
                }
            }
            damageDealt *= breakDamage;

            //Calculates crit chance
            Random random = new Random();
            int number = random.Next(0, 101);
            if (number <= critChance)
            {
                damageDealt *= 2;
            }

            //If you deal 0 damage you deal 1 damage.
            if (damageDealt <= 0)
            {
                damageDealt = 1;
            }

            currentEnemy.currentHp -= damageDealt;
            Console.WriteLine(damageDealt);
            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application 
                ProgressBar.Value = currentEnemy.maxHp - currentEnemy.currentHp;
            }));

            //If the enemy dies
            if (currentEnemy.currentHp <= 0)
            {
                MonsterDeath();
            }
        }

        //Runs when an enemy dies.
        void MonsterDeath()
        {
            //Adds experience of enemy
            AddExperience(currentEnemy.experience);
            //Adds enemy drop to player inventory
            inventory.Add(currentEnemy.drop);

            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application 

                //Tries to find a duplicate
                bool foundDuplicate = false;
                int i = 0; //i is used to count where were are in foreach
                int ii = 0; //ii is used to set to be i so we remember when we found duplicate
                foreach (Label child in InventoryNamePanel.Children)
                {
                    if (child.Content.ToString() == currentEnemy.drop.name)
                    {
                        foundDuplicate = true;
                        ii = i;
                    }
                    i++;
                }

                //If we found a duplicate, we find the corresponding label to update its content
                if (foundDuplicate == true)
                {
                    i = 0;
                    foreach (Label child in InventoryQuantityPanel.Children)
                    {
                        if (i == ii)
                        {
                            child.Content = int.Parse(child.Content.ToString()) + 1;
                        }
                        i++;
                    }
                }
                else
                {
                    //Adds item to inventory
                    Label item = new Label();
                    Label quantity = new Label();
                    item.Content = currentEnemy.drop.name;
                    quantity.Content = 1;
                    InventoryNamePanel.Children.Add(item);
                    InventoryQuantityPanel.Children.Add(quantity);
                }
                UpdateAllUI();
            }));

            //If our inventory is full, we start heading back to the town
            if (inventory.Count >= strength)
            {
                this.Dispatcher.Invoke((Action)(() =>
                {//this refer to form in WPF application 
                    ProgressBar.Value = 0;
                    ProgressBar.Maximum = 100;
                    ProgressTitle.Content = "Returning To Town...";
                }));
                //Changes the timers calling different functions
                killingTimer.Enabled = false;
                walkingTimer.Enabled = true;
            }
            else
            {
                NewEnemy();
            }
        }

        //Adds experience. Updates UI and checks if you level up
        void AddExperience(int experienceGained)
        {
            currentExperience += experienceGained;

            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application 
                ExperienceBar.Value = currentExperience;
            }));

            if (currentExperience >= maxExperience)
            {
                LevelUp();
            }
        }

        //Runs when the player levels up
        void LevelUp()
        {
            //Calculates remaining experience
            int remainingExperience = currentExperience - maxExperience;
            currentExperience = remainingExperience;
            //Increased experienced needed to level up
            maxExperience *= 2;

            //Testing
            attack += 3;
            intelligence += 5;
            speed += 5;
            charisma += 5;
            attackSpeed += 5;
            critChance += 1;
            magicDamage += 5;
            strength += 1;

            currentLevel++;
            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application 
                //Updates UI
                LevelValueLabel.Content = "" + currentLevel;
                ExperienceBar.Maximum = maxExperience;
                ExperienceBar.Value = 0;
                ExperienceBar.Value = currentExperience;

                killingTimer.Interval = (1000 / (attackSpeed / 100));
                walkingTimer.Interval = (1);
                sellingTimer.Interval = (50000 / speed);
            }));
        }

        //Runs when the player has to travel between killing field and town
        void ReturnToTown(Object source, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application
                ProgressBar.Maximum = 20000 / speed;
                //If we're in the town
                if (ProgressBar.Value == ProgressBar.Maximum)
                {
                    //Checks whether we're returning to town or killing field
                    if (inventory.Count > 0)
                    {
                        walkingTimer.Enabled = false;
                        sellingTimer.Enabled = true;
                        ProgressBar.Value = 0;
                        ProgressTitle.Content = "Selling Items...";
                        ProgressBar.Maximum = inventory.Count;
                    } else
                    {
                        walkingTimer.Enabled = false;
                        killingTimer.Enabled = true;
                    }
                } else
                {
                    ProgressBar.Value += 1;
                }
            }));
        }

        //Sells all items
        void SellingItems(Object source, ElapsedEventArgs e)
        {
            if (inventory.Count > 0)
            {
                //Calculates how many of the same item exists
                int numberOfDuplicates = 1;
                string itemName = inventory[0].name;
                for (int i = 1; i < inventory.Count; i++)
                {
                    if (inventory[i].name == itemName)
                    {
                        numberOfDuplicates += 1;
                        inventory.RemoveAt(i);
                        i--;
                    }
                }

                //Makes charisma a double, able to divide by 10, then round it and turn it into an int.
                currentGold += (inventory[0].worth + (int)Math.Round((double)charisma / 10) * currentLevel) * numberOfDuplicates;
                this.Dispatcher.Invoke((Action)(() =>
                {//this refer to form in WPF application 
                    ProgressBar.Value += 1 * numberOfDuplicates;
                    InventoryNamePanel.Children.RemoveAt(1);
                    InventoryQuantityPanel.Children.RemoveAt(1);
                    InventoryBar.Value = inventory.Count - 1;
                    UpdateAllUI();
                }));
                inventory.Remove(inventory[0]);
            }
            else
            {
                this.Dispatcher.Invoke((Action)(() =>
                {//this refer to form in WPF application 
                    ProgressBar.Value = 0;
                    ProgressBar.Maximum = 100;
                    ProgressTitle.Content = "Returning To Killing Field...";
                }));
                BuyItem();
            }
        }

        //Runs after selling all items
        void BuyItem()
        {
            Random random = new Random();
            int randomNum = random.Next(0, database.equipment.Length);

            dynamic purchasedEquipment = new object();
            List<dynamic> purchaseableEquipment = new List<dynamic>();
            
            for (int i = 0; i < database.equipment[randomNum].Length; i++)
            {
                if (database.equipment[randomNum][i].price <= currentGold)
                {
                    if (!ownedEquipment.Contains(database.equipment[randomNum][i]))
                    {
                        purchaseableEquipment.Add(database.equipment[randomNum][i]);
                    }
                }
            }

            //If the player can buy a weapon
            if (purchaseableEquipment.Count > 0)
            {
                purchasedEquipment = purchaseableEquipment[0];
                //Generates a random number
                int num = random.Next(0, 500);
                num += intelligence; //Intelligence makes it easier to hit the next if statement
                if (num >= 500)
                {
                    for (int i = 0; i < purchaseableEquipment.Count; i++)
                    {
                        //Finds the most expensive weapon
                        if (purchaseableEquipment[i].price >= purchasedEquipment.price)
                        {
                            //Checks if it's worth more than the current weapon
                            if (purchaseableEquipment[i].price >= currentEquipment[randomNum].price)
                            {
                                purchasedEquipment = purchaseableEquipment[i];
                            }
                        }
                    }
                }
                else
                {
                    //Players purchases a random weapon.
                    num = random.Next(0, purchaseableEquipment.Count);
                    purchasedEquipment = purchaseableEquipment[num];
                    AddEquipment(purchasedEquipment, randomNum);
                    ownedEquipment.Add(purchasedEquipment);
                    currentGold -= purchasedEquipment.price;
                }
            }

            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application 
                UpdateAllUI();
            }));

            //Player starts walking and stops selling/buying
            walkingTimer.Enabled = true;
            sellingTimer.Enabled = false;
        }

        //Updates all UI that is not a progress bar or inventory
        void UpdateAllUI()
        {
            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application 
                ATKLabel.Content = "ATK: " + attack;
                ATKSPDLabel.Content = "ATKSPD: " + attackSpeed + "%";
                INTLabel.Content = "INT: " + intelligence;
                SPDLabel.Content = "SPD: " + speed;
                CHALabel.Content = "CHA: " + charisma;
                CRITLabel.Content = "CRIT: " + critChance + "%";
                MGCLabel.Content = "MGC: " + magicDamage;
                STRLabel.Content = "STR: " + strength;
                GoldQTY.Content = currentGold.ToString();
                Weapon.Content = "Weapon: " + currentEquipment[0].name;
                WeaponRarityLabel.Content = database.rarities[currentEquipment[0].rarity];
                Shield.Content = "Shield: ";
                Helm.Content = "Helm: " + currentEquipment[1].name;
                HelmRarityLabel.Content = database.rarities[currentEquipment[1].rarity];
                Breastplate.Content = "Breastplate: " + currentEquipment[2].name;
                BreastplateRarityLabel.Content = database.rarities[currentEquipment[2].rarity];
                Greaves.Content = "Greaves: " + currentEquipment[3].name;
                GreavesRarityLabel.Content = database.rarities[currentEquipment[3].rarity];
                Boots.Content = "Boots: " + currentEquipment[4].name;
                BootsRarityLabel.Content = database.rarities[currentEquipment[4].rarity];
                Special.Content = "Special: " + currentEquipment[5].name;
                SpecialRarityLabel.Content = database.rarities[currentEquipment[5].rarity];
                LevelValueLabel.Content = currentLevel.ToString();
                InventoryBar.Value = inventory.Count;
                InventoryBar.Maximum = strength;
                HelmRarityLabel.Content = database.rarities[currentEquipment[1].rarity];
                Helm.Content = "Helm: " + currentEquipment[1].name;
            }));
        }

        //Inserts test data
        void InsertTestData()
        {
            //Inserts test stats
            maxExperience = 100;
            ExperienceBar.Maximum = maxExperience;

            currentLevel = 1;
            attack = 0;
            intelligence = 5;
            speed = 100;
            charisma = 0;
            attackSpeed = 100;
            critChance = 1;
            magicDamage = 5;
            strength = 10;

            //Makes equipment
            currentEquipment[0] = new Weapon("Stick", 1, 1, 0, 0, "Light");
            currentEquipment[1] = new Helm("Dirt Helm", 0, 0, 0, 0, 0, "Light", 0, 0, 0, 0, 0);
            currentEquipment[2] = new Breastplate("Dirt Breastplate", 0, 0, 0, 0, 0, "Light", 0, 0, 0, 0, 0);
            currentEquipment[3] = new Greaves("Dirt Greaves", 0, 0, 0, 0, 0, "Light", 0, 0, 0, 0, 0);
            currentEquipment[4] = new Boots("Dirst Boots", 0, 0, 0, 0, 0, "Light", 0, 0, 0, 0, 0);
            currentEquipment[5] = new Special("Dirt Amulet", 0, 0, 0, 0, 0, "Magic", 0, 0, 0, 0, 0);

            attack += currentEquipment[0].attack;
            attackSpeed *= currentEquipment[0].attackSpeed;

            for (int i = 1; i < currentEquipment.Length; i++)
            {
                attack += currentEquipment[i].bonusAttackdamage;
                speed += currentEquipment[i].bonusSpeed;
                charisma += currentEquipment[i].bonusCharisma;
                attackSpeed += currentEquipment[i].bonusAttackspeed;
                critChance += currentEquipment[i].bonusCritchance;
                magicDamage += currentEquipment[i].bonusMagicdamage;
                strength += currentEquipment[i].bonusStrength;
            }
        }

        //Sets everything up like timers and UI. Also used to update timers
        void SetUp()
        {
            //Sets up a timer to run AttackMonster function depending on weapon and player attack speed
            killingTimer.Interval = (1000 / (attackSpeed / 100));
            killingTimer.Elapsed += AttackMonster;
            killingTimer.AutoReset = true;
            killingTimer.Enabled = true;

            //Sets up a timer to run ReturnToTown, runs faster if player has high speed
            walkingTimer.Interval = (1);
            walkingTimer.Elapsed += ReturnToTown;
            walkingTimer.AutoReset = true;
            walkingTimer.Enabled = false;

            //Sets up a timer to run SellingItems, runs fast if player has high speed
            sellingTimer.Interval = (50000 / speed);
            sellingTimer.Elapsed += SellingItems;
            sellingTimer.AutoReset = true;
            sellingTimer.Enabled = false;
        }
    }
}