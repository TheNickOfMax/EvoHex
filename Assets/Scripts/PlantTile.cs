/// <summary>
/// This class defines a Plant tile that inherits from LivingTile.
/// </summary>
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantTile : LivingTile
{
    /// <summary>
    /// This method destroys a tile by removing it from the Tilemap and destroying the GameObject.
    /// </summary>
    public override void Die()
    {
        tilemap.SetTile(tilePos, null);
        Destroy(this);
    }

    /// <summary>
    /// This method does nothing for PlantTile.
    /// </summary>
    public override void Turn() { }

    /// <summary>
    /// This method sets the PlantTile's base properties for tile material and loads them at runtime.
    /// </summary>
    public void OnEnable()
    {
        this.tBase = this.tBase = Resources.Load<Tile>("Green");
        this.tilemap = GameObject.FindObjectOfType<Tilemap>();
        this.sprite = tBase.sprite;
        this.color = tBase.color;
        this.colliderType = tBase.colliderType;
    }

    /// <summary>
    /// This is the constructor that initializes the PlantTile with a given genome and tile position.
    /// </summary>
    /// <param name="Genome">The genome for the PlantTile.</param>
    /// <param name="Pos">The position of the PlantTile.</param>
    public PlantTile(Genome Genome, Vector3Int Pos)
    {
        this.genome = Genome;
        this.energy = 10;
        this.tilePos = Pos;
    }
}
