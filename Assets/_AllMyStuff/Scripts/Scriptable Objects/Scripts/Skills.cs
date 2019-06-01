using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG Generator/Player/Create Skill")]
public class Skills : ScriptableObject
{
    public string Description;
    public Sprite Icon;
    public int LevelNeeded;
    public int EXPNeeded;

    public List<playerAttributes> AffectedAttributes = new List<playerAttributes>();
}
