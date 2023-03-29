using System.Collections.Generic;
using UnityEngine;

public class Gene
{
    public int[] OffspringGems;

    //Gems are possible child genes
    // 0 -> right
    // 1 <- left
    // 2 ^ up
    // 3 | down

    public Gene()
        : this(30) { }

    public Gene(int GemMax)
    {
        this.OffspringGems = new int[4];

        for (int i = 0; i < OffspringGems.Length; i++)
        {
            this.OffspringGems[i] = new System.Random().Next(0, GemMax);
        }
    }
}
