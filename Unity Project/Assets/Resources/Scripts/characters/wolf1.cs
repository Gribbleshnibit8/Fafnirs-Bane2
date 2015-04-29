/* ---------------------------------------------------------------------------
 * Name: wolf1.cs
 * Purpose: Derived wolf class that low level wolf type monsters will be based
 *          on inherits from enemy.cs. Later stronger wolf types can be added.
 *
 * Author: William Witten
 * Date: 3/25/2015
 * Modified by:
 * Date: 
 ---------------------------------------------------------------------------*/
using UnityEngine;

public class wolf1 : enemy
{

	new void Awake()
	{
		base.Awake();

		MaxHealth = 10;
		Health = 10;
		MaxEnergy = 5;
		Energy = 5;
		BaseAttack = 3;
		BaseDefense = 3;
		MaxMovement = 8;
		Movement = 8;
		Attack = 0;
		Defense = 0;
		Level = 1;
		Experience = 1;
		ExpToNext = 99;
		Range = 1;
	}

 public wolf1(int MaxHealth, int health, int maxEnergy, int energy, int baseAttack, int baseDefense, int movement, int attack, int defense, int level, int experience, int range)
 : base(10, 10, 5, 5, 3, 3, 8, 0, 0, 1, 1, 1)
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