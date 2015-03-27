/* ---------------------------------------------------------------------------
 * Name: character.cs
 * Purpose: Base character class that all hero and enemy characters will be
 *          built on.
 *
 * Author: William Witten
 * Date: 3/25/2015
 * Modified by:
 * Date: 
 ---------------------------------------------------------------------------*/
public class character 
{
	private int maxHealth;
	private int health;
	private int maxEnergy;
	private int energy;
	private int maxMovement;
	private int movement;
	private int baseAttack;
	private int attack;
	private int baseDefense;
	private int defense;
	private int level;
	private int experience;
	private int expToNext;

	public void setMaxHealth(int maxHealth)
	{
		this.maxHealth = maxHealth;
	}
	
	public void setHealth(int health)
	{
		if((this.getHealth() + health) <= this.getMaxHealth())
		{
			this.health = health;
		}
	}
	
	public void setMaxEnergy(int maxEnergy)
	{
		this.maxEnergy = maxEnergy;
	}
	
	public void setEnergy(int energy)
	{
		if((this.getEnergy() + energy) <= this.getMaxEnergy())
		{
			this.energy = energy;
		}
	}
	
	public void setMaxMovement(int movement)
	{
			this.maxMovement = movement;
	}
	
	public void setMovement(int movement)
	{
	
			this.movement = this.getMovement() + movement;
	}
	
	public void setBaseAttack(int baseAttack)
	{
		this.baseAttack = baseAttack;
	}
	
	public void setAttack(int attack)
	{
		this.attack = this.getBaseAttack() + attack;
	}
	
	public void setBaseDefense(int baseDefense)
	{
		this.baseDefense = baseDefense;
	}
	
	public void setDefense(int defense)
	{
		this.defense = this.getBaseDefense() + defense;
	}
	
	public void setLevel(int level)
	{
		if((this.getLevel() + level) <= 20 && level > 0)
		{
			this.level = level;
		}
	}
	
	public void setExperience(int exp)
	{
		if((this.getExperience() + exp) < 100 && exp > 0)
		{
			this.experience = this.getExperience() + exp;
		}
    else if((this.getExperience() +exp) >= 100)
    {
      this.levelUP();
    }
	}
	
	public void setExpToNext()
	{
		this.expToNext = (100 - this.getExperience());
	}
	
	public int getMaxHealth()
	{
		return maxHealth;
	}
	
	public int getHealth()
	{
		return health;
	}
	
	public int getMaxEnergy()
	{
		return maxEnergy;
	}
	
	public int getEnergy()
	{
		return energy;
	}
	
	public int getMovement()
	{
		return movement;
	}
	
	public int getBaseAttack()
	{
		return baseAttack;
	}
	
	public int getAttack()
	{
		return attack;
	}
	
	public int getBaseDefense()
	{
		return baseDefense;
	}
	
	public int getDefense()
	{
		return defense;
	}
	
	public int getLevel()
	{
		return this.level;
	}
	
	public int getExperience()
	{
		return this.experience;
	}
	
	public int getExpToNext()
	{
		return this.expToNext;
	}

	public void levelUP()
	{
		// do nothing, be overridden in derived classes
	}
 
	
  public character()
  {
    	setMaxHealth(1);
		setHealth(1);
		setMaxEnergy(1);
		setEnergy(1);
		setBaseAttack(1);
		setBaseDefense(1);
		setMovement(1);
		setAttack(1);
		setDefense(1);
		setLevel(1);
		setExperience(1);
		setExpToNext();
  }
  
	public character(int maxHP, int HP, int maxMP, int MP, int baseATK, int baseDEF, int MOV, int ATK, int DEF, int LVL, int EXP)
	{
		setMaxHealth(maxHP);
		setHealth(HP);
		setMaxEnergy(maxMP);
		setEnergy(MP);
		setBaseAttack(baseATK);
		setBaseDefense(baseDEF);
		setMovement(MOV);
		setAttack(ATK);
		setDefense(DEF);
		setLevel(LVL);
		setExperience(EXP);
		setExpToNext();
	}

}