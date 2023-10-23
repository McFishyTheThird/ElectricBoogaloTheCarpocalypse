
public class Car
{
    public string name;
    public int health;
    public int maxHealth;
    public int damage;
    public int maxDamage;
    public int critChance;
    public int normalCritChance;
    public int dodgeChance;
    public int speed;
    public int armor;
    public int dancePoints;

    public void Attack(Random generator, Player playerCharacter, List<Car> enemyCars, int enemyNumber)
    {
        int willDodge = generator.Next(0, 100);
        if(willDodge <= playerCharacter.dodgeChance)
        {
            Console.WriteLine($"Unfortunatly you managed to see the attack from {enemyCars[enemyNumber].name} comming and barely dodged it");
        }
        else
        {
            int willCrit = generator.Next(0,100);
            if(willCrit <= enemyCars[enemyNumber].critChance)
            {
                enemyCars[enemyNumber].damage = enemyCars[enemyNumber].maxDamage*2;
                Console.WriteLine($"The {enemyCars[enemyNumber].name} scores a crit through legitimate means that are 100% NOT strength enhancing drugs");
            }
            playerCharacter.health -= enemyCars[enemyNumber].damage - playerCharacter.armor/2;
            enemyCars[enemyNumber].damage = enemyCars[enemyNumber].maxDamage;
            Console.WriteLine($"Luckily your dumb brain didn't manage to register that a {enemyCars[enemyNumber].name} was attacking you and you got hurt");
            Console.WriteLine("");
        }

    }
}
