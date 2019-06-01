using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Abilities/ForceFieldAbility")]
public class ForceFieldAbilityScriptableObject : AbilityBaseScriptableObject
{
    public float Radius = 2;
    public GameObject Prefab;
    public float UpForce = 1;
    public float HitForce = 20f;
    
    public override void SetDefaultValues(AbilityBaseTriggerable ability)
    {
        (ability as ForceFieldTriggerable).OverloadInitialize(Name, Damage, TimeToLive, aBaseCooldown, aSprite, UpForce, Radius, HitForce, Prefab);
    }
}
