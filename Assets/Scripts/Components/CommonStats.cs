using UnityEngine;
using System.Collections;

public class Stats {

    int healthPoints { get; set; }
    int magicPoints { get; set; }
    int strengthPoints { get; set; }
    int speedPoints { get; set; }
    int intelligencePoints { get; set; }

    public Stats(int healthPoints, int magicPoints, int strengthPoints, int speedPoints, int intelligencePoints)
    {
        this.healthPoints = healthPoints;
        this.magicPoints = magicPoints;
        this.strengthPoints = strengthPoints;
        this.speedPoints = speedPoints;
        this.intelligencePoints = intelligencePoints;
    }

    public void addHealthPoints(int health) { this.healthPoints += health; }
	
    public void addMagicPoints(int magic) { this.magicPoints += magicPoints; }

    public void addStrengthPoints(int strength) { this.strengthPoints += strength; }

    public void addSpeedPoints(int speed) { this.speedPoints += speed; }

    public void addIntPoints(int intelligence) { this.intelligencePoints += intelligence; }

}
