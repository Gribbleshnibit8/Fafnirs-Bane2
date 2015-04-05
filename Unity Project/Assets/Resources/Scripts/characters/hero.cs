/* ---------------------------------------------------------------------------
 * Name: hero.cs
 * Purpose: Base hero class that all hero classes will be built on, inherits
 *          from character.cs
 *
 * Author: William Witten
 * Date: 3/25/2015
 * Modified by:
 * Date: 
 ---------------------------------------------------------------------------*/
public class hero : character
{
  public hero(int MaxHealth, int health, int maxEnergy, int energy, int baseAttack, int baseDefense, int movement, int attack, int defense, int level, int experience)
  : base(MaxHealth, health, maxEnergy, energy, baseAttack, baseDefense, movement, attack, defense, level, experience)
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
  public void attack()
  {
    //add in code to attack an enemy by calling targetEnemy(), this.getAttack(), enemy.getDefense()
     /*
     
     check if in range of an enemy
     
     check if missed
     if(rand(%100) > 15)
     {
      int damage = this.getAttack() - enemy.getDefense()
      enemy.setHealth(damage);
      if (enemy.getHealth()<= 0), 
      {
        enemy.destroy()
        this.setExperience(49)
        if(this.getExperience() >= 100)
        {
          if(this.getLevel() < 20)
          {
          this.LevelUP();
          }
        }
      }
     }
     */
  }
  
  public void defend()
  {
    //add in code to give a 1 turn boost to defense
  }
  
  
  //setAttack and setDefense need to be modified to add in their respective item's values rather than a hard coded value.
  //this.setAttack(this.equipped[0].getDMG()) and this.setDefense(this.equipped[1].getArmorPoints());
  
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
}
