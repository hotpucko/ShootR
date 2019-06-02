using UnityEngine;
using UnityEngine.UI;

public class BasePickupable : MonoBehaviour
{
    public AbilityBaseTriggerable abilityTriggerable;
    enum abilitiesEnum { ForceFieldTriggerable, LaserTriggerable }
    [SerializeField] abilitiesEnum ability;
    [SerializeField] Text AbilityNameText;

    private void Start()
    {
        switch (ability)
        {
            case abilitiesEnum.ForceFieldTriggerable:
                abilityTriggerable = new ForceFieldTriggerable();
                Debug.Log(abilityTriggerable.ToString() + ", " + AbilityDataSingleton.Instance.ToString());
                abilityTriggerable = (ForceFieldTriggerable)AbilityDataSingleton.Instance.SetDefaultValues(abilityTriggerable);
                
                break;
            case abilitiesEnum.LaserTriggerable:
                abilityTriggerable = new LaserTriggerable();
                abilityTriggerable = (LaserTriggerable)AbilityDataSingleton.Instance.SetDefaultValues(abilityTriggerable);
                break;
            default:
                break;
        }
        AbilityNameText.text = abilityTriggerable.Name;
        //abilityTriggerable = (Type.GetType(ability.ToString()))Activator.CreateInstance(Type.GetType(ability.ToString()));
        //abilityTriggerable = (AbilityBaseTriggerable)AbilityDataSingleton.Instance.SetDefaultValues(abilityTriggerable);
    }
}
