using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // GOAL: target a monster inside the tower radius
    Queue<Monster> monsters;
    Monster target;
    // Timer variables
    float currentTime;
    float timeBetweenProjectiles;

    void OnEnable() 
    {
        timeBetweenProjectiles = GameManager.Instance.projectileFrequencyRate;
        currentTime = timeBetweenProjectiles;

        monsters = new Queue<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack() 
    {
        currentTime += Time.deltaTime;
        // Check if we have any monsters in the queue (our monster lineup)
        bool shouldGrabMonsterFromQueue = (target == null) && (monsters.Count > 0);
        if (shouldGrabMonsterFromQueue) 
        {
            target = monsters.Dequeue();
        }

        // if we have a monster target
        // we want to throw projectiles at them
        if (target != null && currentTime >= timeBetweenProjectiles) 
        {
            // Create a projectile
            GameObject newProjectile = Instantiate(GameManager.Instance.projectilePrefab);
            newProjectile.transform.position = transform.position;

            // Set the target for the projectile so it can move towards it
            Projectile projScript = newProjectile.GetComponent<Projectile>();
            projScript.target = target;

            // Reset the timer 
            currentTime = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        Monster newMonster = col.gameObject.GetComponent<Monster>();
        if (newMonster != null) 
        {
            monsters.Enqueue(newMonster);
        }
    }

    void OnTriggerExit2D(Collider2D col) 
    {
        target = null;
        print("No longer tracking a monster");
    }
}
