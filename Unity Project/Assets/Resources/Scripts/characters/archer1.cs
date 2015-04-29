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

		MaxHealth = 20;
		Health = 20;
		MaxEnergy = 5;
		Energy = 5;
		BaseAttack = 5;
		BaseDefense = 5;
		MaxMovement = 7;
		Movement = 7;
		Attack = 0;
		Defense = 0;
		Level = 1;
		Experience = 1;
		ExpToNext = 99;
		Range = 2;
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
    set Range(2);
    */
  }
  
  //setAttack and setDefense need to be modified to add in their respective item's values rather than a hard coded value.
  //this.setAttack(this.equipped[0].getDMG()) and this.setDefense(this.equipped[1].getArmorPoints());

   public void levelUP()
  {
    MaxHealth = MaxHealth + (3 * Level);
    Health = MaxHealth - (MaxHealth - Health);
    MaxEnergy = MaxEnergy + 1;
    BaseAttack = (BaseAttack + (2 * Level));
    Attack = 1;
    BaseDefense = BaseDefense + (3 * Level);
    Defense = 1;
    Level = Level + 1;
    Experience = 1;
    ExpToNext = 99;
  }
}
