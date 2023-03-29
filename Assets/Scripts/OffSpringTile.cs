using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// A custom Tile that allows growing of child tiles based on gene info.
/// </summary>
public class OffSpringTile : LivingTile
{
    /// <summary>
    /// Length of possible child genes for this tile.
    /// </summary>
    public int possibleGenesLen;

    /// <summary>
    /// Direction vectors for spawning child tiles.
    /// </summary>
    static Vector3Int DOWN = new Vector3Int(-1, 0, 0),
        UP = new Vector3Int(1, 0, 0),
        LEFT = new Vector3Int(0, -1, 0),
        RIGHT = new Vector3Int(0, 1, 0);

    private static int EnergyDraw = 10;

    /// <summary>
    /// Spawn plant tile on death of this tile.
    /// </summary>
    public override void Die()
    {
        PlantTile plant = ScriptableObject.CreateInstance<PlantTile>();
        plant.tilePos = this.tilePos;
        tilemap.SetTile(tilePos, plant);
        Object.Destroy(this);
    }

    /// <summary>
    /// Grow child tiles based on gene info.
    /// </summary>
    /// <param name="possibleGenesNum">Length of possible child genes for this tile.</param>
    private void Grow(int possibleGenesNum)
    {
        Vector3Int dir = new Vector3Int();
        for (int i = 0; i < activeGene.OffspringGems.Length; i++)
        {
            if (activeGene.OffspringGems[i] >= possibleGenesNum)
            {
                continue;
            }

            dir = HandleChildGenome(dir, i);

            if (tilemap.GetTile<LivingTile>(tilePos + dir) != null)
            {
                return;
            }
            tilemap.SetTile(tilePos + dir, CreateChild(dir, i));
        }
    }

    /// <summary>
    /// Create a new child tile.
    /// </summary>
    /// <param name="dir">Direction to create child tile.</param>
    /// <param name="i">Iterative variable for creating child tile.</param>
    /// <returns>New child tile.</returns>
    private OffSpringTile CreateChild(Vector3Int dir, int i)
    {
        var child = ScriptableObject.CreateInstance<OffSpringTile>();
        child.activeGene = this.genome.OffspringGenes[this.activeGene.OffspringGems[i]];
        child.tilePos = this.tilePos + dir;
        child.genome = this.genome;
        child.energy = EnergyDraw;
        this.energy -= EnergyDraw;
        return child;
    }

    /// <summary>
    /// Handles updating direction vector based on genome information.
    /// </summary>
    /// <param name="dir">Direction vector to update.</param>
    /// <param name="i">Iterative variable for updating direction vector.</param>
    /// <returns>Updated direction vector.</returns>
    private Vector3Int HandleChildGenome(Vector3Int dir, int i)
    {
        switch (i)
        {
            case 0:
                dir = UP;
                break;
            case 1:
                dir = DOWN;
                break;
            case 2:
                dir = RIGHT;
                break;
            case 3:
                dir = LEFT;
                break;
        }
        return dir;
    }

    /// <summary>
    /// Grow child tiles then die.
    /// </summary>
    public override void Turn()
    {
        Grow(possibleGenesLen);
        Die();
    }

    /// <summary>
    /// Setup this Tile on activation.
    /// </summary>
    public void OnEnable()
    {
        tBase = Resources.Load<Tile>("White");
        tilemap = GameObject.FindObjectOfType<Tilemap>();
        sprite = tBase.sprite;
        color = tBase.color;
        colliderType = tBase.colliderType;
    }

    /// <summary>
    /// Default constructor for this tile.
    /// </summary>
    public OffSpringTile()
        : this(new Gene(), Vector3Int.zero, 16, 40, 10) { }

    /// <summary>
    /// Constructor with parameters for this tile.
    /// </summary>
    /// <param name="active">Active gene for this tile.</param>
    /// <param name="pos">Position of this tile.</param>
    /// <param name="possibleGenesNum">Length of possible child genes for this tile.</param>
    public OffSpringTile(
        Gene active,
        Vector3Int pos,
        int possibleGenesNum,
        int allGenesNum,
        int energyInit
    )
    {
        this.possibleGenesLen = possibleGenesNum;
        this.genome = new Genome(possibleGenesNum, allGenesNum);
        this.activeGene = active;
        this.energy = energyInit;
        this.tilePos = pos;
    }
}
