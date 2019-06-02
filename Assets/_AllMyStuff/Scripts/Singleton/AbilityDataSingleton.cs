using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AbilityDataSingleton : Singleton<AbilityDataSingleton>
{
    [SerializeField] ForceFieldAbilityScriptableObject FFBase;
    [SerializeField] LaserAbilityScriptableObject LaserBase;

    // (Optional) Prevent non-singleton constructor use.
    protected AbilityDataSingleton()
    {

    }

    public AbilityBaseTriggerable SetDefaultValues(AbilityBaseTriggerable ability)
    {
        switch (ability)
        {
            case ForceFieldTriggerable ff:
                ff.OverloadInitialize(FFBase.Name, FFBase.Damage, FFBase.TimeToLive, FFBase.aBaseCooldown, FFBase.aSprite, FFBase.UpForce, FFBase.Radius, FFBase.HitForce, FFBase.Prefab);
                return ff;
            case LaserTriggerable lt:
                lt.OverloadInitialize(LaserBase.name, LaserBase.Damage, LaserBase.TimeToLive, LaserBase.aBaseCooldown, LaserBase.aSprite, LaserBase.HitForce, LaserBase.Color, LaserBase.Prefab, LaserBase.HitMask);
                return lt;
            default:
                Debug.Log("ability of type " + ability.GetType() + " did not match switch statement in AbilityDataSingleton.cs");
                return null;
        }
    }
}
