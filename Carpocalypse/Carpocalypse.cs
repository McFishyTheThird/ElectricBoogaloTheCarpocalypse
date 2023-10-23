

using System.Runtime.CompilerServices;

public class Carpocalypse
{
    public Shop shop = new();
    public List<Car> enemyCars  = new();
    public int enemyNumber;
    public string enemyRoundChoice;
    Player playerCharacter = new();
    public int enemyAmount;
    public int levelNumber = 1;
    public string levelType = "normal";
    public bool isLevelChanging = true;
    Random generator = new();
    public void Game()
    {
        playerCharacter.health = 100;
        playerCharacter.maxHealth = 100;
        playerCharacter.damage = 10;
        playerCharacter.maxDamage = 10;
        playerCharacter.armor = 0;
        playerCharacter.critChance = 5;
        playerCharacter.dodgeChance = 0;
        playerCharacter.normalDodgeChance = 0;
        playerCharacter.speed = 10;
        playerCharacter.dancePoints = 0;
        Console.WriteLine("Well, well, well... Look who decided to grace us with their presence!");
        Console.WriteLine("I hope your handwriting isn't as bad as your looks. Write your name down!");
        playerCharacter.name = Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"Welcome {playerCharacter.name} to your new happy little prison. This is Carpocalypse!");
        Console.WriteLine("Fight you way through multiple diffrent cars and if you manage to make it to the end i will set you free!");
        Console.WriteLine("Obviously you wont be able to escape but you are still willing to try");
        Console.WriteLine("[Press Enter To Continue]");
        Console.ReadLine();
        Console.Clear();
        while(playerCharacter.health > 1)
        {
            if(isLevelChanging == true)
            {
                if(levelNumber < 3)
                {
                    enemyAmount = generator.Next(1,3);
                }
                else if(levelNumber <= 9 && levelNumber >= 3)
                {
                    enemyAmount = generator.Next(3,5);
                }
                else if(levelNumber >= 10 && levelNumber < 12)
                {
                    enemyAmount = 2;
                }
                else
                {
                    enemyAmount = 1;
                }
                for(int i = 0; i < enemyAmount; i++)
                {
                    enemyCars.Add(new Car());
                }
                for(int i = 0; i < enemyCars.Count; i++)
                {    
                    CarFactory factory = new CarFactory();
                    enemyCars[i] = factory.GimmeRandomCar(levelNumber);
                }
                isLevelChanging = false;
            }
            if(levelNumber <= 13)
            {
                Console.WriteLine($"{playerCharacter.name}s Stats:");
                Console.WriteLine($"{playerCharacter.name}s Health:{playerCharacter.health}");
                Console.WriteLine($"{playerCharacter.name}s Damage:{playerCharacter.damage}");
                Console.WriteLine($"{playerCharacter.name}s Crit Chance:{playerCharacter.critChance}");
                Console.WriteLine($"{playerCharacter.name}s Dodge Chance:{playerCharacter.dodgeChance}");
                Console.WriteLine($"{playerCharacter.name}s Armor:{playerCharacter.armor}");
                Console.WriteLine("Hey there, Captain Indecisive! The clock's ticking, and so is my patience. Your move, or should I flip a coin for you?");
                Console.WriteLine("A:Attack B:Heal C:Look at enemy stats");
                string playerChoice = Console.ReadLine().ToLower();
                Console.Clear();
                if(playerChoice == "a" || playerChoice == "attack")
                {
                    playerCharacter.Attack(enemyCars, generator, playerCharacter, isLevelChanging);
                    if(enemyCars.Count == 0)
                    {
                        // levelType = "shop";
                        levelNumber++;
                        isLevelChanging = true;
                        playerCharacter.maxHealth += 10;
                        playerCharacter.health = playerCharacter.maxHealth;
                        playerCharacter.maxDamage += 10;
                        playerCharacter.damage = playerCharacter.maxDamage;
                        playerCharacter.armor += 1;
                        playerCharacter.critChance += .5f;
                        playerCharacter.normalDodgeChance += 1;
                        playerCharacter.dodgeChance = playerCharacter.normalDodgeChance;
                        if(levelNumber <= 13)
                        {
                            Console.WriteLine("FUCK!!! You defeated the cars. guess its time for a bigger challenge");
                        }
                    }
                    else
                    {
                        for(int i = 0; i < enemyCars.Count; i++)
                        {
                            enemyNumber = i;
                            enemyCars[i].Attack(generator, playerCharacter, enemyCars, enemyNumber);
                        }
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                else if(playerChoice == "b")
                {
                    Console.WriteLine("Since you are a massive coward who is afraid to die you choose to heal a bit");
                    playerCharacter.Heal(playerCharacter, enemyNumber, enemyCars, generator);
                    Console.ReadLine();
                    Console.Clear();
                }
                else if(playerChoice == "c")
                {
                    for(int i = 0; i < enemyCars.Count; i++)
                    {
                        Console.WriteLine($"{enemyCars[i].name} Stats:");
                        Console.WriteLine($"{enemyCars[i].name} Health:{enemyCars[i].health}");
                        Console.WriteLine($"{enemyCars[i].name} Damage:{enemyCars[i].damage}");
                        Console.WriteLine($"{enemyCars[i].name} Crit Chance:{enemyCars[i].critChance}");
                        Console.WriteLine($"{enemyCars[i].name} Dodge Chance:{enemyCars[i].dodgeChance}");
                        Console.WriteLine($"{enemyCars[i].name} Armor:{enemyCars[i].armor}");
                        Console.WriteLine("");
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Goddammit...i guess you win.");
                Console.ReadLine();
                playerCharacter.health = 0;
            }

            // Shopping(shop.shopInventory);
        }
        Console.WriteLine("HAH! You fucking loser");
        Console.ReadLine();
    }

    // public void Shopping(List<Items> shopInventory)
    // {

    // }
}
