using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public GameObject[] tilePrefab;
    public float tileSize;
    public CameraMovement camMovement;
    public Dictionary<Point, Tile> tiles;
    private Point homeSpawn;
    private Point destSpawn;
    public GameObject bluePortal;
    public GameObject redPortal;

    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateLevel()
    {
        tiles = new Dictionary<Point, Tile>();

        string[] map = ReadLevelText();

        int mapY = map.Length;
        int mapX = map[0].ToCharArray().Length;

        tileSize = tilePrefab[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        Vector3 screenPoint = new Vector3(0, Screen.height);
        Vector3 worldStart = Camera.main.ScreenToWorldPoint(screenPoint);
        
        Vector3 lastTilePosition = new Vector3();
        for (int y = 0; y < mapY; y++)
        {
            char[] newTiles = map[y].ToCharArray();
            for (int x = 0; x < mapX; x++)
            {
                lastTilePosition = PlaceTile(x, y, worldStart, newTiles[x].ToString());
            }
        }

        Vector3 lastTileBottomRight = new Vector3(lastTilePosition.x + tileSize, lastTilePosition.y - tileSize);
        camMovement.SetLimits(lastTileBottomRight);

        SpawnPortals();
    }

    private string[] ReadLevelText()
    {
        TextAsset textFile = Resources.Load("Level") as TextAsset;
        string data = textFile.text.Replace(Environment.NewLine, string.Empty);

        return data.Split('-');
    }

    private Vector3 PlaceTile(int x, int y, Vector3 start, string tileType)
    {
        int tileIndex = int.Parse(tileType); // "3" => 3 

        GameObject newTile = Instantiate(tilePrefab[tileIndex]);
        Tile newTileScript = newTile.GetComponent<Tile>();

        Vector3 newWorldPos = new Vector3(start.x + (tileSize * x), start.y - (tileSize * y));

        Point newPoint = new Point(x, y);
        newTileScript.Setup(newPoint, newWorldPos);

        tiles.Add(newPoint, newTileScript);

        return newTile.transform.position;
    }

    private void SpawnPortals() 
    {
        homeSpawn = new Point(0, 0);
        GameObject newHomePortal = Instantiate(bluePortal);
        newHomePortal.transform.position = tiles[homeSpawn].transform.position;
    }
}
