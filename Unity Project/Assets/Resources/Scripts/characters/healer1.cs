/* ---------------------------------------------------------------------------
 * Name: healer1.cs
 * Purpose: Derived healer class that low level healers will be based on
 *         inherits from Character.cs. Later stronger healers can be added.
 *
 * Author: William Witten
 * Date: 3/25/2015
 * Modified by:
 * Date: 
 ---------------------------------------------------------------------------*/
public class healer1 : hero
{

	new void Awake()
	{
		base.Awake();

		MaxHealth = 20;
		Health = 20;
		MaxEnergy = 7;
		Energy = 7;
		BaseAttack = 3;
		BaseDefense = 8;
		MaxMovement = 4;
		Movement = 4;
		Attack = 0;
		Defense = 0;
		Level = 1;
		Experience = 1;
		ExpToNext = 99;
		Range = 1;
	}

	public healer1(int MaxHealth, int health, int maxEnergy, int energy, int baseAttack, int baseDefense, int movement, int attack, int defense, int level, int experience, int range) 
  : base(20, 20, 7, 7, 3, 8, 4, 0, 0, 1, 1, 1)
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
    */
	}
  
  //setAttack and setDefense need to be modified to add in their respective item's values rather than a hard coded value.
  //this.setAttack(this.equipped[0].getDMG()) and this.setDefense(this.equipped[1].getArmorPoints());
   public void levelUP()
  {
    MaxHealth = MaxHealth + (3 * Level);
    Health = MaxHealth - (MaxHealth - Health);
    MaxEnergy = MaxEnergy + 1;
    BaseAttack = BaseAttack + (2 * Level);
	Attack = 1;
    BaseDefense = (BaseDefense + (2 * Level));
	Defense = 1;
	Level = Level + 1 ;
    Experience = 1 ;
    ExpToNext = 1 ;
  }
}