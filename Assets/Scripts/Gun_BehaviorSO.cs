using UnityEngine;

[CreateAssetMenu(fileName = "Gun_BehaviorSO", menuName = "Scriptable Objects/Gun_BehaviorSO")]
public class Gun_BehaviorSO : ScriptableObject
{
    //++IMPORTANT NOTE : There is currently no ammo system in place for guns and will be added later down the line.++
    //General Gun Behavior Variables
    //Note IsChamber may be a button beahvior requireing the player to chamber each shot after a key is pressed along with a minor animation.
    [SerializeField] private bool IsChamber = false;
    //umbrella term if a gun requires a specifc chamber like sequence to fire again ie a revolver needs to cock the hammer back after shot, pump shotguns need to be pumped, may universally apply to guns that need to chamber to fire again like most rifles or pistols later down the line.
    [SerializeField] private bool IsAutomatic = false; //calls if a gun should be automatic or not. false is the default therefore not.
    [SerializeField] private float FireRate = 0.5f; // Time between shots 
    [SerializeField] private float Dmg = 10f; // Damage of each shot of a gun (will be calliber specific later down the line ie 7.62 will do more damage than 9mm and will stay consitant across guns that use such)
    [SerializeField] private float FallOff = 100f; // The range that a guns damage will be reduced to less and less at a range (Note: this will be changed to a string at a later time to better mimic each caliber universally.
    [SerializeField] private float Recoil = 1f; // mimics recoil in the top down view by making bullets differ from the exact crosshair location if fired for extended period (diffrent than spread in that triggers after extended firing and becomes more aggresive compared to spread and is applied with such overtime.)
    [SerializeField] private float Spread = 1f; //determins the spread of the bullets fired from gun to crosshair location.
    [SerializeField] private float MultiShot = 1f; //Increase number based on how many shots are fired per times fire a shotgun fires 8 per shot a rifle or pistol does 1.
    //------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Grab functions for the above variables to be called from other scripts.
    public float GetFireRate()
    {
        return FireRate;
    }
    public float GetDmg() //maybe changed to string to call for specific calliber. (Note: may also change based on ammo type ie Hollow point, Armor Piercing, etc. as a future concept)
    {
        return Dmg;
    }
    public float GetFallOff() //Similar to above comment will be changed to string later to stay consistant with calliber. (Note: may also change based on ammo type ie Hollow point, Armor Piercing, etc. as a future concept)
    {
        return FallOff;
    }
    public float GetRecoil()
    {
        return Recoil;
    }
    public float GetSpread()
    {
        return Spread;
    }
    public float GetMultiShot()
    {
        return MultiShot;
    }

}
