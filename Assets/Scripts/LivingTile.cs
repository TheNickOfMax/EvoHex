/// <summary>
/// An abstract class for tiles that can "live", ie: perform actions during game turns.
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

abstract public class LivingTile : Tile
{
    /// The current active gene of the tile.
    protected Gene activeGene;

    /// The base tile this LivingTile is derived from.
    protected Tile tBase;

    /// The position of this LivingTile on the Tilemap.
    public Vector3Int tilePos;

    /// The current energy of the LivingTile.
    protected int energy;

    /// The genome controlling this LivingTile's genes.
    protected Genome genome;

    /// The Tilemap holding this LivingTile.
    protected Tilemap tilemap;

    /// An abstract function that must be implemented to handle the tile's death.
    abstract public void Die();

    /// An abstract function that must be implemented to handle the tile's actions during a turn.
    abstract public void Turn();
}
