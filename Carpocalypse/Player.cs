

using System.Security.Cryptography.X509Certificates;

public class Player
{
    public List<string> inventory;
    public int coins;
    public string name;
    public int health;
    public int maxHealth;
    public int maxDamage;
    public int damage;
    public float critChance;
    public int dodgeChance;
    public int normalDodgeChance;
    public int speed;
    public int armor;
    public int dancePoints;

    public void Attack(List<Car> enemyCars, Random generator, Player playerCharacter,bool  isLevelChanging)
    {
        Console.Clear();
        Console.WriteLine("which car will be the unfortunate victim of you brutality?");
        Console.WriteLine($"you can attack 1 of {enemyCars.Count} innocent cars");
        for(int i = 0; i < enemyCars.Count; i++)
        {
            Console.WriteLine($"Car {i+1}. {enemyCars[i].name}");
        }
        int attackChoice;
        while (!int.TryParse(Console.ReadLine(), out attackChoice))
        {       
            Console.Write("You didn't provide a number you stupid dumb fuck, please try again:");
        }
        if(attackChoice > enemyCars.Count)
        {
            Console.WriteLine("You fucking moron...You attack a nonexistent car and obviously miss");
            Console.WriteLine("Guess your dumber than i thought");
            Console.ReadLine();
        }
        else
        {    
            for(int i = 0; i < enemyCars.Count; i++)
            {
                if(attackChoice == i+1)
                {
                    int willDodge = generator.Next(0, 100);
                    if(willDodge <= enemyCars[i].dodgeChance)
                    {
                        Console.WriteLine($"unluckily for you the {enemyCars[i].name} managed to escape you brutal attack unscathed");
                    }
                    else
                    {
                        int willCrit = generator.Next(0,100);
                        if(willCrit <= playerCharacter.critChance)
                        {
                            playerCharacter.damage = playerCharacter.maxDamage*2;
                            Console.WriteLine("You somehow do some bullshit things and manage to score a crit");
                        }
                        playerCharacter.damage -= enemyCars[i].armor/2;
                        if(playerCharacter.damage < 1)
                        {
                            playerCharacter.damage = 1;
                        }

                        enemyCars[i].health -= playerCharacter.damage;
                        playerCharacter.damage = playerCharacter.maxDamage;
                        Console.WriteLine($"You unfortunatly managed to hit the innocent {enemyCars[i].name}");
                    }
                    if(enemyCars[i].health < 0)
                    {
                        enemyCars[i].health = 0;
                    }
                    Console.WriteLine($"{enemyCars[i].name}s Health: {enemyCars[i].health}");
                    Console.ReadLine();
                    if(enemyCars[i].health == 0)
                    {
                        enemyCars.Remove(enemyCars[i]);
                    }

                }
            }
        }


    }
    public void Heal(Player playerCharacter, int enemyNumber, List<Car> enemyCars, Random generator)
    {
        playerCharacter.dodgeChance = playerCharacter.normalDodgeChance*5;
        if(playerCharacter.dodgeChance > 80)
        {
            playerCharacter.dodgeChance = 80;
        }
        playerCharacter.health += 50;
        for(int i = 0; i < enemyCars.Count; i++)
        {
            enemyNumber = i;
            enemyCars[i].critChance = enemyCars[i].normalCritChance * 2;
            enemyCars[i].Attack(generator, playerCharacter, enemyCars, enemyNumber);
            enemyCars[i].critChance = enemyCars[i].normalCritChance;
        }
        if(playerCharacter.health > playerCharacter.maxHealth)
        {
            playerCharacter.health = playerCharacter.maxHealth;
        }
    }
}
