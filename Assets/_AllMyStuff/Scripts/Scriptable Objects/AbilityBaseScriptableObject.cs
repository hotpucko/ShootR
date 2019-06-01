using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbilityBaseScriptableObject : ScriptableObject
{
    public string Name = "New Ability";
    public Sprite aSprite;
    public AudioClip aSound;
    public float aBaseCooldown = 1f;
    public int Damage = 1;
    public float TimeToLive = 5;

    public AbilityBaseTriggerable abilityTriggerable;

    public virtual void SetDefaultValues(AbilityBaseTriggerable ability)
    {
        ability.Initialize(Name, Damage, TimeToLive, aBaseCooldown, aSprite);
    }

}
