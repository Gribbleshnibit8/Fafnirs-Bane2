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
public class wolf1 : enemy
{
 public wolf1(int MaxHealth, int health, int maxEnergy, int energy, int baseAttack, int baseDefense, int movement, int attack, int defense, int level, int experience)
 : base(10, 10, 5, 5, 3, 3, 8, 0, 0, 1, 1)
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