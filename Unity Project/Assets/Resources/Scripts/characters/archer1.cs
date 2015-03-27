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
  archer1(int MaxHealth, int health, int maxEnergy, int energy, int baseAttack, int baseDefense, int movement, int attack, int defense, int level, int experience) 
  : base(20, 20, 5, 5, 5, 5, 7, 0, 0, 1, 1)
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
    this.setMaxHealth(this.getMaxHealth() + (3 * this.getLevel()));
    this.setHealth(this.getMaxHealth() - this.getHealth());
    this.setMaxEnergy(this.getMaxEnergy() + 1);
    this.setBaseAttack(this.getBaseAttack() + (2 * this.getLevel()));
	this.setAttack (1);
    this.setBaseDefense(this.getBaseDefense() + (3 * this.getLevel()));
	this.setDefense (1);
	this.setLevel (this.getLevel () + 1);
    this.setExperience(1);
    this.setExpToNext();
  }
}