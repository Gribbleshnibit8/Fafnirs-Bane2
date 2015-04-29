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

		MaxHealth = 20;
		Health = 20;
		MaxEnergy = 5;
		Energy = 5;
		BaseAttack = 10;
		BaseDefense = 10;
		MaxMovement = 5;
		Movement = 5;
		Attack = 0;
		Defense = 0;
		Level = 1;
		Experience = 1;
		ExpToNext = 99;
		Range = 1;
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
    MaxHealth = (MaxHealth + (5 * Level));
    Health = MaxHealth - (MaxHealth - Health);
    MaxEnergy = MaxEnergy + 1;
    BaseAttack = BaseAttack + (4 * Level);
    Attack = 1;
    BaseDefense = BaseDefense + (4 * Level);
    Defense = 1;
    Level = Level + 1;
    Experience = 1;
    ExpToNext = 99;
  }
}
