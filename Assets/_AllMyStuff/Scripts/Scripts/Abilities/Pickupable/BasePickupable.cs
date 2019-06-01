using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BasePickupable : MonoBehaviour
{
    public AbilityBaseTriggerable abilityTriggerable;
    enum abilitiesEnum { ForceFieldTriggerable, LaserTriggerable }
    [SerializeField] abilitiesEnum ability;

    private void Awake()
    {
        switch (ability)
        {
            case abilitiesEnum.ForceFieldTriggerable:
                abilityTriggerable = new ForceFieldTriggerable();
                abilityTriggerable = (ForceFieldTriggerable)AbilityDataSingleton.Instance.SetDefaultValues(abilityTriggerable);
                break;
            case abilitiesEnum.LaserTriggerable:
                abilityTriggerable = new LaserTriggerable();
                abilityTriggerable = (LaserTriggerable)AbilityDataSingleton.Instance.SetDefaultValues(abilityTriggerable);
                break;
            default:
                break;
        }
        //abilityTriggerable = (Type.GetType(ability.ToString()))Activator.CreateInstance(Type.GetType(ability.ToString()));
        //abilityTriggerable = (AbilityBaseTriggerable)AbilityDataSingleton.Instance.SetDefaultValues(abilityTriggerable);
    }
}
