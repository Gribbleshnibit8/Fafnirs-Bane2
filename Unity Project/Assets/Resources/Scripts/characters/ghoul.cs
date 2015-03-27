/* ---------------------------------------------------------------------------
 * Name: ghoul.cs
 * Purpose: Derived ghoul class that all ghoul type monsters will be based on
 *          inherits from enemy.cs
 *
 * Author: William Witten
 * Date: 3/25/2015
 * Modified by:
 * Date: 
 ---------------------------------------------------------------------------*/
public class ghoul : enemy
{
  public ghoul(int MaxHealth, int health, int maxEnergy, int energy, int baseAttack, int baseDefense, int movement, int attack, int defense, int level, int experience)
  : base(20, 20, 2, 2, 8, 8, 5, 0, 0, 1, 1)
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