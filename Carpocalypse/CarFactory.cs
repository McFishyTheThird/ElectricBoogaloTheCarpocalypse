public class CarFactory
{

    public List<Car> cars = new();
    public CarFactory()
    { 
        Car brokenCar = new() { name = "Broken Car", health = 20, maxHealth = 20, damage = 2, maxDamage = 2, critChance = 0, normalCritChance = 0, dodgeChance = 0, speed = 1, armor = 0, dancePoints = 0 };
        Car fordFocus = new() { name = "Ford Focus", health = 100, maxHealth = 100, damage = 10, maxDamage = 10, critChance = 5, normalCritChance = 5, dodgeChance = 5, speed = 10, armor = 5, dancePoints = 10 };
        Car volkswagenBeetle = new() { name = "Volkswagen Beetle", health = 200, maxHealth = 200, damage = 5, maxDamage = 5, critChance = 0, normalCritChance = 0, dodgeChance = 0, speed = 5, armor = 15, dancePoints = 20 };
        Car dodgeStealth = new() { name = "Dodge Stealth", health = 50, maxHealth = 50, damage = 20, maxDamage = 20, critChance = 50, normalCritChance = 50, dodgeChance = 25, speed = 20, armor = 0, dancePoints = 30 };
        Car rollsRoyceSilverCloud = new() { name = "Rolls Royce Silver Cloud", health = 70, maxHealth = 70, damage = 15, maxDamage = 15, critChance = 15, normalCritChance = 15, dodgeChance = 10, speed = 12, armor = 5, dancePoints = 50 };
        Car porscheCarrera = new() { name = "Porce Carrera", health = 60, maxHealth = 60, damage = 7, maxDamage = 7, critChance = 25, normalCritChance = 25, dodgeChance = 5, speed = 25, armor = 10, dancePoints = 10 };
        Car lamborghiniCountach = new() { name = "Lambarghini Countach", health = 150, maxHealth = 150, damage = 30, maxDamage = 30, critChance = 0, normalCritChance = 0, dodgeChance = 10, speed = 10, armor = 5, dancePoints = 15 };
        Car mercuryGrandMarquisLSColonyParkWagon = new() { name = "Mercury Grand Marquis LS Colony Park Wagon", health = 100, maxHealth = 100, damage = 7, maxDamage = 7, critChance = 0, normalCritChance = 0, dodgeChance = 15, speed = 12, armor = 0, dancePoints = 5 };
        Car fordMustang = new() { name = "Ford Mustang", health = 100, maxHealth = 100, damage = 15, maxDamage = 15, critChance = 10, normalCritChance = 10, dodgeChance = 10, speed = 10, armor = 0, dancePoints = 25 };
        Car limousine = new() { name = "Limousine", health = 150, maxHealth = 150, damage = 10, maxDamage = 10, critChance = 25, normalCritChance = 25, dodgeChance = 5, speed = 10, armor = 5, dancePoints = 30 };
        Car volkswagenGolfGTI = new() { name = "Volkswagen Golf GTI", health = 75, maxHealth = 75, damage = 2, maxDamage = 2, critChance = 20, normalCritChance = 20, dodgeChance = 20, speed = 7, armor = 2, dancePoints = 10 };
        Car dodgeViper = new() { name = "Dodge Viper", health = 40, maxHealth = 40, damage = 30, maxDamage = 30, critChance = 100, normalCritChance = 100, dodgeChance = 50, speed = 30, armor = 0, dancePoints = 30 };
        Car semiTruck = new() { name = "Semi-Truck", health = 300, maxHealth = 300, damage = 20, maxDamage = 20, critChance = 0, normalCritChance = 0, dodgeChance = 0, speed = 1, armor = 20, dancePoints = 0 };
        Car rweBagger = new() { name = "RWE Bagger 288", health = 500, maxHealth = 500, damage = 60, maxDamage = 60, critChance = 25, normalCritChance = 25, dodgeChance = 0, speed = 15, armor = 20, dancePoints = 999 };
        cars.AddRange(new List<Car> { brokenCar, fordFocus, volkswagenBeetle, dodgeStealth, volkswagenGolfGTI, porscheCarrera, lamborghiniCountach, mercuryGrandMarquisLSColonyParkWagon,fordMustang,rollsRoyceSilverCloud, limousine, dodgeViper, semiTruck,rweBagger });
    }

    public Car GimmeRandomCar(int levelNumber)
    {
        Random generator = new Random();
        if(levelNumber == 1 || levelNumber == 2)
        {
            return cars[0];
        }
        else if(levelNumber == 3 || levelNumber == 4)
        {
            return cars[generator.Next(1, 4)];
        }
        else if(levelNumber == 5 || levelNumber == 6 || levelNumber == 7)
        {
            return cars[generator.Next(1, 9)];
        }
        else if(levelNumber == 8 || levelNumber == 9)
        {
            return cars[generator.Next(9, 11)];
        }
        else if(levelNumber == 10)
        {
            return cars[12];
        }
        else
        {
            return cars[13];
        }
    }
}


