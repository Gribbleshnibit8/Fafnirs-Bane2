/* ---------------------------------------------------------------------------
 * Name: fighter1.cs
 * Purpose: Derived fighter class that low level fighters will be based on
 *         inherits from Character.cs. Later stronger fighters can be added.
 *
 * Author: William Witten
 * Date: 3/25/2015
 * Modified by:
 * Date: 
 ---------------------------------------------------------------------------*/
public class fighter1 : hero
{

	new void Awake()
	{
		base.Awake();

		maxHealth = 20;
		health = 20;
		maxEnergy = 5;
		energy = 5;
		baseAttack = 10;
		baseDefense = 10;
		movement = 5;
		attack = 0;
		defense = 0;
		level = 1;
		experience = 1;
		expToNext = 99;
		range = 1;
	}


	public fighter1(int MaxHealth, int health, int maxEnergy, int energy, int baseAttack, int baseDefense, int movement, int attack, int defense, int level, int experience, int range)
  : base(20, 20, 5, 5, 10, 10, 5, 0, 0, 1, 1, 1)
    {
    /* inherited from base class as follows: 
    setmaxHealth(maxHP);
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
    setRange(RNG);
    */
    }
  
    
  //setAttack and setDefense need to be modified to add in their respective item's values rather than a hard coded value.
  //this.setAttack(this.equipped[0].getDMG()) and this.setDefense(this.equipped[1].getArmorPoints());
  
  public void levelUP()
  {
    maxHealth = (maxHealth + (5 * level));
    health = maxHealth - (maxHealth - health);
    maxEnergy = maxEnergy + 1;
    baseAttack = baseAttack + (4 * level);
    attack = 1;
    baseDefense = baseDefense + (4 * level);
    defense = 1;
    level = level + 1;
    experience = 1;
    expToNext = 99;
  }
}
