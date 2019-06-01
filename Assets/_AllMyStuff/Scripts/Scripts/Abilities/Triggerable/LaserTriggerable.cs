using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTriggerable : AbilityBaseTriggerable
{
    [HideInInspector]
    public float HitForce = 1;
    [HideInInspector]
    public Color Color = new Color(0, 0, 255);
    [HideInInspector]
    public GameObject Prefab;
    [HideInInspector]
    public LayerMask HitMask;

    public virtual void OverloadInitialize(string _name, int _damage, float _timeToLive, float _baseCooldown, Sprite _buttonImage, float _hitForce, Color _color, GameObject _prefab, LayerMask _hitMask)
    {
        HitForce = _hitForce;
        Color = _color;
        Prefab = _prefab;
        HitMask = _hitMask;
        
        base.Initialize(_name, _damage, _timeToLive, _baseCooldown, _buttonImage);
    }

    public override void TriggerAbility(Vector3 source, Vector3 destination)
    {
        //Ray ray = new Ray(source, (destination - source).normalized);
        //Debug.DrawRay(source, (destination - source).normalized * 100, new Color(255, 0, 0), 2);
        GameObject go = PlayerController.Instantiate(Prefab, source, Quaternion.LookRotation((destination - source).normalized));
        Laser L = go.GetComponent<Laser>();
        L.Initialize(Damage, HitForce, TimeToLive, destination, HitMask);

        base.TriggerAbility(source, destination);
    }
}
