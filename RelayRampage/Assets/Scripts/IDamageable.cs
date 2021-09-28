using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void AttackEffectDelegate();
public interface IDamageable 
{

    public void AddDamageEffects(List<AttackEffectDelegate> effects);
    public void TakeDamage(float strength);
    //pass this one via the collider, since we need to figure out a direction to knock them
    public void AddImpulse(Vector2 impulse);

    //effect functions

    public void LaunchUp();
     public void BurnStatus();
    public void FrozenStatus();
    public void StunnedStatus();


}
