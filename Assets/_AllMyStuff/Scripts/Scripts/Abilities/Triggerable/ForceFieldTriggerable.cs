using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceFieldTriggerable : AbilityBaseTriggerable
{
    // add todo: change these fields to be private set public get
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

    public override void TriggerAbility(Vector3 source, Vector3 destination)
    {
        GameObject go = AbilityController.Instantiate(Prefab, destination, Quaternion.Euler(0, 0, 0));
        ForceField ff = go.GetComponent<ForceField>();
        ff.Initialize(Damage, Radius, HitForce, TimeToLive, UpForce);
         
        base.TriggerAbility(source, destination);
    }
}
