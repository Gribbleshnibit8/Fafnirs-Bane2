/* ---------------------------------------------------------------------------
 * Name: enemy.cs
 * Purpose: Base enemy class that all enemy classes will be built on, inherits
 *          from Character.cs
 *
 * Author: William Witten
 * Date: 3/25/2015
 * Modified by:
 * Date: 
 ---------------------------------------------------------------------------*/
public class enemy : Character
{
  public enemy(int MaxHealth, int health, int maxEnergy, int energy, int baseAttack, int baseDefense, int movement, int attack, int defense, int level, int experience, int range)
  : base(MaxHealth, health, maxEnergy, energy, baseAttack, baseDefense, movement, attack, defense, level, experience, range)
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
  
	/*---------------------------------------------------------------------
  * These functions will not be implemented in version 1.
  * 
  public void attackAction()
  {
  	//add in hero specific attack actions.
  }
  
  public void defend()
  {
    //add in code to give a 1 turn boost to defense
  }
  
  public void useSkill()
  {
    //add code to pick and use an available skill
  }
  
  public void move()
  {
    // add in code to initiate movement
  }
  
  public void useItem()
  {
    // add in code to select and use an item.
  }
*/
}
