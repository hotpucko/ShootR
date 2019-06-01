using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDataSingleton : Singleton<AbilityDataSingleton>
{
    [SerializeField] ForceFieldAbilityScriptableObject FFBase;

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
            default:
                Debug.Log("ability of type " + ability.GetType() + " did not match switch statement in AbilityDataSingleton.cs");
                return null;
        }
    }
}
