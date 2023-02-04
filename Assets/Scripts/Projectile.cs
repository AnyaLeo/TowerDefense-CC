using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Monster target;
    private float speed;

    void OnEnable() 
    {
        speed = GameManager.Instance.projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        bool didCollideWithMonster = col.gameObject.CompareTag("Monster");
        if (didCollideWithMonster) 
        {
            Monster monster = col.gameObject.GetComponent<Monster>();
            monster.SubtractHealth(GameManager.Instance.projectileDamage);
            Destroy(gameObject);
        }
    }
}
