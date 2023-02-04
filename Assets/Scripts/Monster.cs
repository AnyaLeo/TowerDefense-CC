using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // GOAL: move the monster to the destination portal
    private Vector3 destination;
    private float speed;
    private int health;

    void OnEnable() 
    {
        destination = LevelManager.Instance.tiles[LevelManager.Instance.destSpawn].worldPosition;

        speed = GameManager.Instance.monsterSpeed;

        health = GameManager.Instance.monsterHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }

    public void SubtractHealth(int changeAmount) 
    {
        health = health - changeAmount;
        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
