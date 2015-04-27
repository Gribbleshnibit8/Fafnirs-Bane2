/* ---------------------------------------------------------------------------
 * Name: archer1.cs
 * Purpose: Derived archer class that low level archers will be based on
 *         inherits from character.cs. Later stronger archers can be added.
 *
 * Author: William Witten
 * Date: 3/25/2015
 * Modified by:
 * Date: 
 ---------------------------------------------------------------------------*/
public class archer1 : hero
{

	new void Awake()
	{
		base.Awake();

		maxHealth = 20;
		health = 20;
		maxEnergy = 5;
		energy = 5;
		baseAttack = 5;
		baseDefense = 5;
		maxMovement = 7;
		movement = 7;
		attack = 0;
		defense = 0;
		level = 1;
		experience = 1;
		expToNext = 99;
		range = 2;
	}


  archer1(int MaxHealth, int health, int maxEnergy, int energy, int baseAttack, int baseDefense, int movement, int attack, int defense, int level, int experience, int range) 
  : base(20, 20, 5, 5, 5, 5, 7, 0, 0, 1, 1, 2)
  {
    /* inherited from base class as follows: 
    set maxHealth(20);
    set Health(20);
    set MaxEnergy(5);
    set Energy(5);
    set BaseAttack(5);
    set BaseDefense(5);
    set Movement(7);
    set Attack(0);
    set Defense(0);
    set Level(1);
    set Experience(1);
    set ExpToNext();
    set range(2);
    */
  }
  
  //setAttack and setDefense need to be modified to add in their respective item's values rather than a hard coded value.
  //this.setAttack(this.equipped[0].getDMG()) and this.setDefense(this.equipped[1].getArmorPoints());

   public void levelUP()
  {
    maxHealth = maxHealth + (3 * level);
    health = maxHealth - (maxHealth - health);
    maxEnergy = maxEnergy + 1;
    baseAttack = (baseAttack + (2 * level));
    attack = 1;
    baseDefense = baseDefense + (3 * level);
    defense = 1;
    level = level + 1;
    experience = 1;
    expToNext = 99;
  }
}
