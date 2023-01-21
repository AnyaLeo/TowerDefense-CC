using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Point gridPosition;
    // The center of our tile
    public Vector3 worldPosition;
    public bool isFree;

    void Awake() 
    {
        isFree = true;
    }

    public void Setup(Point newGridPos, Vector3 newWorldPos, Transform parent) 
    {
        gridPosition = newGridPos;
        transform.position = newWorldPos;

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        // Calculate the center world position for our tile
        worldPosition = new Vector3(
            transform.position.x + sprite.bounds.size.x / 2,
            transform.position.y - sprite.bounds.size.y / 2
            );
        
        LevelManager.Instance.tiles.Add(gridPosition, this);

        transform.SetParent(parent);
    }

    private void OnMouseOver() 
    {
        bool canPlaceTower = Input.GetMouseButtonDown(0) & isFree;
        if (canPlaceTower) 
        {
            PlaceTower();
        }
    }

    void PlaceTower() 
    {
        GameObject tower = Instantiate(GameManager.Instance.towerPrefab);
        tower.transform.position = transform.position;

        isFree = false;

        SpriteRenderer sprite = tower.GetComponent<SpriteRenderer>();
        // Fix the glitching when towers appear on top of each other
        sprite.sortingOrder = gridPosition.y + 1;
    }
}
