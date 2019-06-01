using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBaseTriggerable
{
    [HideInInspector]
    public string Name = "";
    [HideInInspector]
    public int Damage = 1;
    [HideInInspector]
    public float TimeToLive;
    [HideInInspector]
    public float BaseCooldown;
    [HideInInspector]
    public bool CanBeCast;
    [HideInInspector]
    public Sprite ButtonImage;
    [HideInInspector]
    public Sprite DarkMask;

    protected float nextReadyTime;
    public float cooldownTimeLeft { get; protected set; }
    
    protected Text cooldownTextDisplay;
    
    bool cooldownComplete, prevCooldownComplete;

    public virtual void Initialize(string _name, int _damage, float _timeToLive, float _baseCooldown, Sprite _buttonImage)
    {
        Name = _name;
        Damage = _damage;
        TimeToLive = _timeToLive;
        BaseCooldown = _baseCooldown;
        ButtonImage = _buttonImage;
        DarkMask = _buttonImage;
    }

    public virtual void UpdateCooldowns(Image darkMask)
    {
        cooldownComplete = (Time.time > nextReadyTime);
        cooldownTimeLeft -= Time.time;
        if (cooldownComplete && !prevCooldownComplete)
        {
            CanBeCast = true;
        }
        else if (!cooldownComplete)
        {
            CanBeCast = false;
        }

        prevCooldownComplete = cooldownComplete;
    }

    public virtual void TriggerAbility(AbilityController parent)
    {
        nextReadyTime = Time.time + BaseCooldown;
        cooldownTimeLeft = BaseCooldown;
        cooldownTextDisplay.enabled = true;
        CanBeCast = false;
    }

    public virtual void ClearAttachedGameObjects()
    {
        cooldownTextDisplay = null;
    }
    
    public virtual void SetLinks(Text cooldownTextDisplay)
    {
        this.cooldownTextDisplay = cooldownTextDisplay;
    }
}
