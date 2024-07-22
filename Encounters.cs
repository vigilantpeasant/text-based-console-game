class Encounters
{
    Random rand = new();
    string[] nameArray = ["Human Rogue", "Orc Rogue", "Goblin Rogue", "Dwarf Rogue",
                          "Human Mage", "Orc Mage", "Goblin Mage", "Dwarf Mage",
                          "Human Warrior", "Orc Warrior", "Goblin Warrior", "Dwarf Warrior",
                          "Demon", "Devil", "Imp", "Ghoul", "Vampire", "Skeleton", "Wraith"];
    string[] bossNameArray = ["King", "Lord", "Priest", "Troll", "Lich King", "Vampire Lord", "Golem"];
    string n = "";
    int s = 0;
    int h = 0;

    public void Combat(string type)
    {
        int earnedXp = 0;
        int earnedGold = 0;
        // Set properties based on enemy type
        switch (type)
        {
            case "mob":
                int nameIndex = rand.Next(nameArray.Length);
                n = nameArray[nameIndex];
                s = rand.Next(Program.player.level - 3, Program.player.level);
                if (s < 0)
                    s = 1;
                h = rand.Next(Program.player.level + 1, Program.player.level + 3);
                if (h < 0)
                    h = 1;

                earnedXp = 10 + rand.Next(Program.player.luck + 2, Program.player.luck + 4);
                earnedGold = 5 + rand.Next(Program.player.luck, Program.player.luck + 2);
                break;
            case "boss":
                int bossNameIndex = rand.Next(bossNameArray.Length);
                n = bossNameArray[bossNameIndex];
                s = rand.Next(Program.player.level + 2, Program.player.level + 8);
                if (s < 0)
                    s = 0;
                h = rand.Next(Program.player.level + 4, Program.player.level + 8);
                if (h < 0)
                    h = 0;

                earnedXp = 20 + rand.Next(Program.player.luck + 2, Program.player.luck + 4);
                earnedGold = 10 + rand.Next(Program.player.luck, Program.player.luck + 2);
                break;
        }

        while (h > 0)
        {
            Console.WriteLine("===============================");
            Console.WriteLine("----------BATTLEFIELD----------");
            Console.WriteLine("===============================");
            Console.WriteLine($"{n} Stats (at level {Program.level})");
            Console.WriteLine($"Strength: {s}  / Health: {h}");
            Console.WriteLine("===============================");
            Console.WriteLine("Input Key / Action / Description");
            Console.WriteLine("   1      / Attack / using Strength + Luck /2");
            Console.WriteLine("   2      / Attack / using Willpower + Luck /2");
            Console.WriteLine("   3      / Defend / using Armor");
            Console.WriteLine("   4      / Run    / using Luck");
            Console.WriteLine("   5      / Heal   / using Health Potion");
            Console.WriteLine("===============================");
            Console.WriteLine("Player Stats");
            Console.WriteLine($"Strength: {Program.player.strength}  / Health: {Program.player.health}");
            Console.WriteLine($"Willpower: {Program.player.willpower}  / Luck: {Program.player.luck}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Coin: {Program.player.coin}");
            Console.WriteLine($"Health Potion: {Program.player.healthPotion} / Armor: {Program.player.armor}");
            Console.WriteLine("===============================");
            string input = Console.ReadLine() ?? "";
            Console.Clear();

            // Attack using Strength + Luck /2
            if (input == "1")
            {
                // Player Action
                int damage = rand.Next(Program.player.strength - 5, Program.player.strength + (Program.player.luck / 2));
                if (damage < 0)
                    damage = 0;
                Console.WriteLine($"You attacked the {n} and you dealt {damage} damage");
                h -= damage;

                // Enemy Action
                if (h < h / 2)
                {
                    // Enemy Heal
                    if (h > 0)
                    {
                        h += 5;
                        Console.WriteLine("Enemy drinked health potion \nHe gained 5 health");
                    }
                }
                else
                {
                    // Enemy Attack
                    if (h > 0)
                    {
                        int enemyDamage = rand.Next(1, s + 1 - Program.player.armor);
                        if (enemyDamage < 0)
                            enemyDamage = 0;
                        Console.WriteLine($"{n} attacked you and he dealt {enemyDamage} damage");
                        Program.player.health -= enemyDamage;
                    }
                }
            }

            // Attack using Willpower + Luck /2
            else if (input == "2")
            {
                // Player Action
                int damage = rand.Next(Program.player.willpower - 5, Program.player.willpower + (Program.player.luck / 2));
                if (damage < 0)
                    damage = 0;
                Console.WriteLine($"You attacked the {n} and you dealt {damage} damage");
                h -= damage;
                if (h > 0)
                    Console.WriteLine($"{n}'s health is {h}");

                // Enemy Action
                if (h < h / 2)
                {
                    // Enemy Heal
                    if (h > 0)
                    {
                        h += 5;
                        Console.WriteLine("Enemy drinked health potion \nHe gained 5 health");
                    }
                }
                else
                {
                    // Enemy Attack
                    if (h > 0)
                    {
                        int enemyDamage = rand.Next(1, s + 1 - Program.player.armor);
                        if (enemyDamage < 0)
                            enemyDamage = 0;
                        Console.WriteLine($"{n} attacked you and he dealt {enemyDamage} damage");
                        Program.player.health -= enemyDamage;
                    }
                }
            }

            // Defend
            else if (input == "3")
            {
                Console.WriteLine("You tried to defend yourself");
                // Enemy Attack
                int enemyDamage = rand.Next(s / 2, s + 1) - Program.player.armor;
                if (enemyDamage < 0)
                    enemyDamage = 0;
                Console.WriteLine($"{n} attacked you and he dealt {enemyDamage} damage");
                Program.player.health -= enemyDamage;
            }

            // Run
            else if (input == "4")
            {
                // You ran away
                if (rand.Next(0, 2) == 1 || Program.player.luck > 10)
                {
                    Console.WriteLine("You run away");
                    return;
                }
                // You couldn't run away
                else
                {
                    Console.WriteLine("You tried to run away but you couldn't");
                    // Enemy Attack
                    if (h > 0)
                    {
                        int enemyDamage = rand.Next(1, s + 1 - Program.player.armor);
                        if (enemyDamage < 0)
                            enemyDamage = 0;
                        Console.WriteLine($"{n} attacked you and he dealt {enemyDamage} damage");
                        Program.player.health -= enemyDamage;
                    }
                }
            }

            // Heal
            else if (input == "5")
            {
                if (Program.player.healthPotion > 0)
                {
                    Program.player.healthPotion -= 1;
                    Program.player.health += 5;
                    Console.WriteLine("You drinked health potion \nYou gained 5 health");
                }
                else
                {
                    Console.WriteLine("You don't have any health potion");
                }
            }

            else
            {
                Console.WriteLine("null movement, try again");
            }

            if (Program.player.health <= 0)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("You died");
                Console.WriteLine("Do you want to play again? Y/N");
                Console.WriteLine("===============================");
                string deathInput = Console.ReadLine() ?? "";
                if (deathInput.ToLower() == "y")
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(0);
                Environment.Exit(0);
            }
        }
        Console.WriteLine($"{n} is dead");

        // Handle win
        Program.player.coin += earnedGold;
        Console.WriteLine($"You earned {earnedGold} coins");

        Program.player.xp += earnedXp;
        Console.WriteLine($"You earned {earnedXp} xp");

        Console.ReadKey();
        Console.Clear();
        return;
    }

    public void Store()
    {
        Console.Clear();
        bool buyingItem = true;
        Console.WriteLine("Please select the item to buy!");

        // Handle Class Selection
        while (buyingItem)
        {
            Console.WriteLine("===============================");
            Console.WriteLine("-------------STORE-------------");
            Console.WriteLine("===============================");
            Console.WriteLine("Input Key / Item Name       / Price  / Description");
            Console.WriteLine("   1      / Health Potion   /   5    / Restores 5 health");
            Console.WriteLine("   2      / Armor           /   20   / Reduces enemy damage by 2");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("   3      / Exit the store");
            Console.WriteLine("===============================");
            Console.WriteLine("Player Stats");
            Console.WriteLine($"Strength: {Program.player.strength}  / Health: {Program.player.health}");
            Console.WriteLine($"Willpower: {Program.player.willpower}/ Luck: {Program.player.luck}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Coin: {Program.player.coin} / Armor: {Program.player.armor}");
            Console.WriteLine($"Health Potion: {Program.player.healthPotion}");
            Console.WriteLine("===============================");
            string input = Console.ReadLine() ?? "";
            Console.Clear();

            // Health Potion
            if (input == "1")
            {
                if (Program.player.coin >= 5)
                {
                    Console.WriteLine("You bought the health potion");
                    Program.player.coin -= 5;
                    Program.player.healthPotion += 1;
                }
                else
                {
                    Console.WriteLine("'You don't have enough coin to buy this'");
                }
            }

            // Armor
            else if (input == "2")
            {
                if (Program.player.coin >= 20)
                {
                    Console.WriteLine("You bought the armor");
                    Program.player.coin -= 20;
                    Program.player.armor += 2;
                }
                else
                {
                    Console.WriteLine("'You don't have enough coin to buy this'");
                }
            }

            // Exit
            else if (input == "3")
            {
                buyingItem = false;
                return;
            }

            else
            {
                Console.WriteLine("null item, try again");
            }
        }
    }

    public void Skills()
    {
        Console.Clear();
        bool upgradingSkills = true;
        Console.WriteLine("Which skills do you want to upgrade?");

        int availablePoints = 0;
        int availableNextDiffuculty = 0;
        while (Program.player.xp >= 20)
        {
            availableNextDiffuculty++;
            Program.player.xp -= 20;
            availablePoints++;
        }

        if (availableNextDiffuculty > 1)
        {
            Program.level++;
        }

        while (upgradingSkills)
        {
            Console.WriteLine("===============================");
            Console.WriteLine("------------SKILLS-------------");
            Console.WriteLine("===============================");
            Console.WriteLine("Input Key / Action    / Your Skill Level");
            Console.WriteLine($"   1      / Strength  / {Program.player.strength}");
            Console.WriteLine($"   2      / Willpower / {Program.player.willpower}");
            Console.WriteLine($"   3      / Health    / {Program.player.health}");
            Console.WriteLine($"   4      / Luck      / {Program.player.luck}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("   5      / Exit");
            Console.WriteLine("===============================");
            Console.WriteLine("Player Stats");
            Console.WriteLine($"Experience: {Program.player.xp} / Available Points: {availablePoints}");
            Console.WriteLine("===============================");
            string input = Console.ReadLine() ?? "";
            Console.Clear();

            // Upgrading Strength
            if (input == "1")
            {
                if (availablePoints >= 1)
                {
                    Console.WriteLine("You upgraded the Strength");
                    availablePoints--;
                    Program.player.strength++;
                }
                else
                {
                    Console.WriteLine("You don't have enough points");
                }
            }

            // Upgrading Willpower
            else if (input == "2")
            {
                if (availablePoints >= 1)
                {
                    Console.WriteLine("You upgraded the Willpower");
                    availablePoints--;
                    Program.player.willpower++;
                }
                else
                {
                    Console.WriteLine("You don't have enough points");
                }
            }

            // Upgrading Health
            else if (input == "3")
            {
                if (availablePoints >= 1)
                {
                    Console.WriteLine("You upgraded the Health");
                    availablePoints--;
                    Program.player.health++;
                }
                else
                {
                    Console.WriteLine("You don't have enough points");
                }
            }

            // Upgrading Luck
            else if (input == "4")
            {
                if (availablePoints >= 1)
                {
                    Console.WriteLine("You upgraded the Luck");
                    availablePoints--;
                    Program.player.luck++;
                }
                else
                {
                    Console.WriteLine("You don't have enough points");
                }
            }

            // Exit
            else if (input == "5")
            {
                upgradingSkills = false;
                return;
            }

            else
            {
                Console.WriteLine("null skill, try again");
            }
        }
    }
}
