using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantTile : LivingTile
{
    public override void Die()
    {
        tilemap.SetTile(tilePos, null);
        Destroy(this);
    }

    public override void Turn() { }

    public void OnEnable()
    {
        this.tBase = this.tBase = Resources.Load<Tile>("Green");
        this.tilemap = GameObject.FindObjectOfType<Tilemap>();
        this.sprite = tBase.sprite;
        this.color = tBase.color;
        this.colliderType = tBase.colliderType;
    }

    public PlantTile(Genome Genome, Vector3Int Pos)
    {
        this.genome = Genome;
        this.energy = 10;
        this.tilePos = Pos;
    }
}
