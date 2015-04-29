/* ---------------------------------------------------------------------------
 * Name: skeleton1.cs
 * Purpose: Derived wolf class that low level skeleton type monsters will be
 *          based on inherits from enemy.cs. Later stronger skeletons can be
 *          added.
 *
 * Author: William Witten
 * Date: 3/25/2015
 * Modified by:
 * Date: 
 ---------------------------------------------------------------------------*/
public class skeleton1 : enemy
{

	new void Awake()
	{
		base.Awake();

		MaxHealth = 15;
		Health = 15;
		MaxEnergy = 5;
		Energy = 5;
		BaseAttack = 8;
		BaseDefense = 8;
		MaxMovement = 5;
		Movement = 5;
		Attack = 0;
		Defense = 0;
		Level = 1;
		Experience = 1;
		ExpToNext = 99;
		Range = 1;
	}

	public skeleton1(int MaxHealth, int health, int maxEnergy, int energy, int baseAttack, int baseDefense, int movement, int attack, int defense, int level, int experience, int range)
  : base(15, 15, 5, 5, 8, 8, 5, 0, 0, 1, 1, 1)
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
  
}