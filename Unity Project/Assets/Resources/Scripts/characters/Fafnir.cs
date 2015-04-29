/* ---------------------------------------------------------------------------
 * Name: Fafnir.cs
 * Purpose: Final boss character script
 *
 * Author: William Witten
 * Date: 4/26/2015
 * Modified by:
 * Date: 
 ---------------------------------------------------------------------------*/
public class Fafnir : enemy
{
  public Fafnir(int MaxHealth, int health, int maxEnergy, int energy, int baseAttack, int baseDefense, int movement, int attack, int defense, int level, int experience, int range)
  : base(200, 200, 5, 5, 100, 100, 5, 0, 25, 1, 1, 1)
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
