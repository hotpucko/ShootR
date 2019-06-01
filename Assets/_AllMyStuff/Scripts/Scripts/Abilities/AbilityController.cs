using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour
{
    AbilityBaseTriggerable[] abilities = new AbilityBaseTriggerable[4]; //list of abilities
    [SerializeField] Image[] abilityIconGO = new Image[4];
    [SerializeField] Sprite DefaultIcon;
    [SerializeField] Image[] darkMask = new Image[4]; //the dark cooldown mask on top of the ability icon
    [SerializeField] Text[] cooldownTextDisplay = new Text[4]; //the text ontop of the ability icon
    [SerializeField] string[] abilityButtonAxisName = new string[4] {
        "AbilityQ",
        "AbilityW",
        "AbilityE",
        "AbilityR"
    };
    private bool isColliding = false; //a variable to keep track of if the player has collided this frame with a pickupable
    
    private void Start()
    {

    }

    void Update()
    {
        isColliding = false;
        UpdateCooldowns();
        CheckForInput();
    }

    private void CheckForInput()
    {
        for (int i = 0; i < abilityButtonAxisName.Length; i++)
        {
            if (Input.GetAxis(abilityButtonAxisName[i]) > 0)
            {
                if (abilities[i] != null)
                {
                    useAbility(i);
                }
            }
        }
    }

    private void UpdateCooldowns()
    {
        for (int i = 0; i < abilities.Length; i++)
        {
            if (abilities[i] != null)
            {
                abilities[i].UpdateCooldowns(darkMask[i]);

                if (abilities[i].CanBeCast)
                {
                    darkMask[i].enabled = false;
                    cooldownTextDisplay[i].text = abilities[i].Name;
                }
                else
                {
                    darkMask[i].enabled = true;
                    cooldownTextDisplay[i].text = abilities[i].cooldownTimeLeft.ToString();//(Mathf.Ceil(abilities[i].cooldownTimeLeft * 10.0f) / 10.0f).ToString(); //rounds to 1 decimal place
                    darkMask[i].fillAmount = abilities[i].cooldownTimeLeft / abilities[i].BaseCooldown;
                }
            }
        }
    }

    public void AddAbility(AbilityBaseTriggerable ability, int slot)
    {
        ClearAbility(slot);
        abilities[slot] = ability;
        abilityIconGO[slot].sprite = abilities[slot].ButtonImage;
        darkMask[slot].sprite = abilities[slot].DarkMask;
        abilities[slot].SetLinks(cooldownTextDisplay[slot]);
    }

    public void ClearAbilities()
    {
        for (int i = 0; i < abilities.Length; i++)
        {
            abilities[i].ClearAttachedGameObjects();
            abilities[i] = null;
            abilityIconGO[i].sprite = DefaultIcon;
            darkMask[i].sprite = DefaultIcon;
        }
    }

    public void ClearAbility(int slot)
    {
        if (abilities[slot] == null)
            return;
        abilities[slot].ClearAttachedGameObjects();
        abilities[slot] = null;
        abilityIconGO[slot].sprite = DefaultIcon;
        darkMask[slot].sprite = DefaultIcon;
    }

    public void useAbility(int slot)
    {
        if(abilities[slot].CanBeCast)
        {
            abilities[slot].TriggerAbility(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isColliding == true)
            return;
        if (other.gameObject.GetComponent<ForceFieldPickupable>() != null)
        {
            int firstFreeslot = GetFirstFreeAbilitySlot();
            if(firstFreeslot == -1)
            {
                //all ability slots are full, do other stuff
                Debug.Log("All ability slots are full.");
            }
            else
            {
                Debug.Log("adding ability " + other.gameObject.GetComponent<ForceFieldPickupable>().abilityTriggerable.Name + " to skill slot " + firstFreeslot);
                //System.ObjectExtensions.Copy = deep copy, enables having multiple of the same ability FROM THE SAME SOURCE
                AddAbility(System.ObjectExtensions.Copy(other.gameObject.GetComponent<ForceFieldPickupable>().abilityTriggerable), firstFreeslot);
            }
            Destroy(other.gameObject);
        }
        isColliding = true;
    }

    private int GetFirstFreeAbilitySlot()
    {
        for (int i = 0; i < abilities.Length; i++)
        {
            if (abilities[i] == null)
                return i;
        }
        return -1;
    }
}
