using UnityEngine;
using System.Collections;

public class Stats {

    public int healthPoints { get; set; }
    public int magicPoints { get; set; }
    public int strengthPoints { get; set; }
    public int speedPoints { get; set; }
    public int intelligencePoints { get; set; }

    public Stats(int healthPoints, int magicPoints, int strengthPoints, int speedPoints, int intelligencePoints)
    {
        this.healthPoints = healthPoints;
        this.magicPoints = magicPoints;
        this.strengthPoints = strengthPoints;
        this.speedPoints = speedPoints;
        this.intelligencePoints = intelligencePoints;
    }

    public void AddHealthPoints(int health) { this.healthPoints += health; }
	
    public void AddMagicPoints(int magic) { this.magicPoints += magicPoints; }

    public void AddStrengthPoints(int strength) { this.strengthPoints += strength; }

    public void AddSpeedPoints(int speed) { this.speedPoints += speed; }

    public void AddIntPoints(int intelligence) { this.intelligencePoints += intelligence; }

}
