using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceFieldTriggerable : AbilityBaseTriggerable
{
    [HideInInspector]
    public float UpForce = 1;
    [HideInInspector]
    public float Radius = 1;
    [HideInInspector]
    public float HitForce = 1;
    [HideInInspector]
    public GameObject Prefab;

    public virtual void OverloadInitialize(string _name, int _damage, float _timeToLive, float _baseCooldown, Sprite _buttonImage, float _upForce, float _radius, float _hitForce, GameObject _prefab)
    {
        UpForce = _upForce;
        Radius = _radius;
        HitForce = _hitForce;
        Prefab = _prefab;
        base.Initialize(_name, _damage, _timeToLive, _baseCooldown, _buttonImage);
    }

    public override void TriggerAbility(AbilityController parent)
    {
       GameObject go = PlayerController.Instantiate(Prefab, parent.transform.position, parent.transform.rotation);
       ForceField ff = go.GetComponent<ForceField>();
       ff.Initialize(Damage, Radius, HitForce, TimeToLive, UpForce);
        
        base.TriggerAbility(parent);
    }
}
