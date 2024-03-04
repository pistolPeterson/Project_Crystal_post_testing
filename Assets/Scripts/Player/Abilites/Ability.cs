using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected int cooldown;
    [SerializeField] protected int manaCost;
    protected bool isOnCoolDown = false;
    protected Actions actions;



    public IEnumerator UseAbility() //Make this in abstract ability class minus transformed.position
    {
        isOnCoolDown = true;
        AbilityUsage();
        yield return new WaitForSeconds(cooldown);
        isOnCoolDown = false;
        
    }
    public abstract void AbilityUsage();
}
