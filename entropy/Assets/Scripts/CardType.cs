using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardType
{

    public static Hashtable cardType = new Hashtable();

    static CardType()
    {
        cardType.Add("card", 0);
        cardType.Add("playerCard", 1);
        cardType.Add("goodCard", 2);
        cardType.Add("badCard", 3);
    }
}
