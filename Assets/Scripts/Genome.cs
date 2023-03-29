using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genome
{
    public Gene[] OffspringGenes { get; protected set; }
    public int Length;

    public Genome(int GenesLen, int GemsLen)
    {
        this.Length = GemsLen;
        OffspringGenes = new Gene[GenesLen];
        for (int i = 0; i < OffspringGenes.Length; i++)
        {
            OffspringGenes[i] = new Gene(GemsLen);
        }
    }
}
