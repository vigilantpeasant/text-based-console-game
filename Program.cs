
class Program
{
    public static Player player = new();
    public static Encounters encounter = new();
    public static int level = 1;
    static void Main(string[] args)
    {
        Console.Clear();
        SelectNameAndClass();
        Adventure();
    }

    static void SelectNameAndClass()
    {
        // Select Name
        Console.WriteLine("Name the player");
        player.name = Console.ReadLine() ?? player.name;

        Console.Clear();

        // Select Class
        bool selectingClass = true;
        Console.WriteLine("Select the class");

        // Handle Class Selection
        while (selectingClass)
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Input Key / Class Names / Strength / Willpower / Health / Luck");
            Console.WriteLine("   1      /   Warrior   /    10    /     0     /   10   /  5  ");
            Console.WriteLine("   2      /   Sorcerer  /    0     /     10    /   10   /  5  ");
            Console.WriteLine("   3      /   Paladin   /    10    /     0     /   15   /  0  ");
            Console.WriteLine("   4      /   Barbarian /    15    /     0     /   10   /  0  ");
            Console.WriteLine("   5      /   Mage      /    0     /     15    /   10   /  0  ");
            Console.WriteLine("   6      /   Warlock   /    0     /     10    /   15   /  0  ");
            Console.WriteLine("===============================");
            string input = Console.ReadLine() ?? "";
            Console.Clear();

            // Warrior
            if (input.ToLower() == "1")
            {
                player.playerClass = "Warrior";
                selectingClass = false;
                break;
            }

            // Sorcerer
            else if (input.ToLower() == "2")
            {
                player.playerClass = "Sorcerer";
                selectingClass = false;
                break;
            }

            // Paladin
            else if (input.ToLower() == "3")
            {
                player.playerClass = "Paladin";
                selectingClass = false;
                break;
            }

            // Barbarian
            else if (input.ToLower() == "4")
            {
                player.playerClass = "Barbarian";
                selectingClass = false;
                break;
            }

            // Mage
            else if (input.ToLower() == "5")
            {
                player.playerClass = "Mage";
                selectingClass = false;
                break;
            }

            // Warlock
            else if (input.ToLower() == "6")
            {
                player.playerClass = "Warlock";
                selectingClass = false;
                break;
            }

            else
            {
                Console.WriteLine("null class, try again");
            }
        }

        // Handle Class Stats
        switch (player.playerClass)
        {
            case "Warrior":
                player.strength = 10;
                player.willpower = 0;
                player.health = 10;
                player.luck = 5;
                break;
            case "Sorcerer":
                player.strength = 0;
                player.willpower = 10;
                player.health = 10;
                player.luck = 5;
                break;
            case "Paladin":
                player.strength = 10;
                player.willpower = 0;
                player.health = 15;
                player.luck = 0;
                break;
            case "Barbarian":
                player.strength = 15;
                player.willpower = 0;
                player.health = 10;
                player.luck = 0;
                break;
            case "Mage":
                player.strength = 0;
                player.willpower = 15;
                player.health = 10;
                player.luck = 0;
                break;
            case "Warlock":
                player.strength = 0;
                player.willpower = 10;
                player.health = 15;
                player.luck = 0;
                break;
        }

        // Handle Results
        if (player.name == "")
        {
            player.name = "Player";
        }
        Console.WriteLine($"Player name is {player.name}.");
        Console.WriteLine($"Player class is {player.playerClass}");

        Console.ReadKey();
        Console.Clear();

        return;
    }

    static void Adventure()
    {
        while (level <= 50)
        {
            if (level % 10 == 0)
            {
                // Boss spawner
                Console.WriteLine($"You are at level {level}");
                Console.WriteLine("You encountered a boss");
                Console.ReadKey();
                encounter.Combat("boss");
                // Store menu spawner
                Console.WriteLine("You encountered a store");
                Console.ReadKey();
                Console.Clear();
                encounter.Store();
                // Skills menu spawner
                Console.WriteLine("Upgrade your skills");
                Console.ReadKey();
                Console.Clear();
                encounter.Skills();
            }

            // Mob spawner
            Console.WriteLine($"You are at level {level}");
            Console.WriteLine("You encountered a enemy");
            Console.ReadKey();
            Console.Clear();
            encounter.Combat("mob");
            // Store menu spawner
            Console.WriteLine("You encountered a store");
            Console.ReadKey();
            Console.Clear();
            encounter.Store();
            // Skills menu spawner
            Console.WriteLine("Upgrade your skills");
            Console.ReadKey();
            Console.Clear();
            encounter.Skills();

            level++;
        }
    }
}
