using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // GOAL: move the monster to the destination portal
    private Vector3 destination;

    void OnEnable() 
    {
        destination = LevelManager.Instance.tiles[LevelManager.Instance.destSpawn].worldPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, 1 * Time.deltaTime);
    }
}
