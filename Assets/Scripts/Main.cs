using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Main GameManager method
/// </summary>
public class Main : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tilemap;

    private const int Border = 100;
    private const float ZoomSpeed = 1f;
    private const int OffspringCount = 100;
    private const int RegenCount = 100;
    private const float CamSpeed = 1.5f;

    private Camera _mainCamera;
    private System.Random _random;

    private void Start()
    {
        _mainCamera = Camera.main;
        _random = new System.Random();

        //Constructor
        _tilemap = GetComponent<Tilemap>();
        SetOffspringRange(-Border, -Border, Border, Border, OffspringCount);
    }

    private void Update()
    {
        HandleInput();
        TurnOffspringTiles();
    }

    /// <summary>
    /// Handles camera input, zooming and controlling its movement.
    /// Detects input and calls corresponding functions to turn living and offsprings
    /// </summary>
    private void HandleInput()
    {
        float camScale = 0;
        Vector3 camPos = _mainCamera.transform.position;

        camPos += new Vector3(
            Input.GetAxis("Horizontal") * CamSpeed,
            Input.GetAxis("Vertical") * CamSpeed,
            0
        );

        if (Input.GetKey(KeyCode.Q))
            camScale = ZoomSpeed;

        if (Input.GetKey(KeyCode.E))
            camScale = -ZoomSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
            TurnOffspringTiles();

        if (Input.GetKeyDown(KeyCode.R))
            RegenerateTiles();

        //Manual scalation of the orthographicsize of the camera
        _mainCamera.orthographicSize += camScale;

        //moving the camera according to the Axis Horizontal and Vertical
        _mainCamera.transform.position = camPos;
    }

    /// <summary>
    /// Sets the Tile to an Offspring Tile, given Vector3Int position.
    /// </summary>
    private void SetOffspringTile(Vector3Int position)
    {
        OffSpringTile tile = ScriptableObject.CreateInstance<OffSpringTile>();
        tile.tilePos = position;
        _tilemap.SetTile(position, tile);
    }

    /// <summary>
    /// Sets the offsprings on random positions within given range.
    /// </summary>
    /// <param name="minX">Left border.</param>
    /// <param name="minY">Bottom border.</param>
    /// <param name="maxX">Right border.</param>
    /// <param name="maxY">Top border.</param>
    /// <param name="numberOfOffsprings"> How many offspring tiles should be created.</param>
    private void SetOffspringRange(int minX, int minY, int maxX, int maxY, int numberOfOffsprings)
    {
        for (int i = 0; i < numberOfOffsprings; i++)
        {
            int x = _random.Next(minX, maxX);
            int y = _random.Next(minY, maxY);
            SetOffspringTile(new Vector3Int(x, y, 0));
        }
    }

    /// <summary>
    /// Deletes and removes living tiles, then generates new offsprings.
    /// </summary>
    private void RegenerateTiles()
    {
        LivingTile[] livers = FindObjectsOfType<LivingTile>();

        foreach (var tile in livers)
        {
            _tilemap.SetTile(tile.tilePos, null);
            tile.Die();
            DestroyImmediate(tile);
        }

        SetOffspringRange(-Border, -Border, Border, Border, RegenCount);
    }

    /// <summary>
    /// Calls the Turn() function of all Offspring tiles.
    /// </summary>
    private void TurnOffspringTiles()
    {
        OffSpringTile[] offsprings = FindObjectsOfType<OffSpringTile>();

        foreach (var tile in offsprings)
            tile.Turn();
    }
}
