using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Abilities/LaserAbility")]
public class LaserAbilityScriptableObject : AbilityBaseScriptableObject
{
    public float HitForce = 1;
    public Color Color = new Color(0, 0, 255);
    public GameObject Prefab;
    public LayerMask HitMask;

    public override void SetDefaultValues(AbilityBaseTriggerable ability)
    {
        (ability as LaserTriggerable).OverloadInitialize(Name, Damage, TimeToLive, aBaseCooldown, aSprite, HitForce, Color, Prefab, HitMask);
    }
}
