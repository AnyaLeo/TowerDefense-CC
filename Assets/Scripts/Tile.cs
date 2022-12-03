using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Point gridPosition;

    public void Setup(Point newGridPos, Vector3 newWorldPos) 
    {
        gridPosition = newGridPos;
        transform.position = newWorldPos;
    }
}
