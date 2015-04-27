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
    maxHealth = maxHealth + (3 * level);
    health = maxHealth - (maxHealth - health);
    maxEnergy = maxEnergy + 1;
    baseAttack = baseAttack + (2 * level);
	attack = 1;
    baseDefense = (baseDefense + (2 * level));
	defense = 1;
	level = level + 1 ;
    experience = 1 ;
    expToNext = 1 ;
  }
}