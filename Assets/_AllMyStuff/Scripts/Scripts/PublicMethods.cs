using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerAttributes
{
    public Attributes attribute;
    public int amount;

    public playerAttributes(Attributes attribute, int amount)
    {
        this.attribute = attribute;
        this.amount = amount;
    }
}
