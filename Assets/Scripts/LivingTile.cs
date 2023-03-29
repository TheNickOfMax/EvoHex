using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

abstract public class LivingTile : Tile
{
    protected Gene activeGene;
    protected Tile tBase;
    public Vector3Int tilePos;
    protected int energy;
    protected Genome genome;
    protected Tilemap tilemap;
    abstract public void Die();
    abstract public void Turn();
}
