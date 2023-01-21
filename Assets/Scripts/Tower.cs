using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // GOAL: target a monster inside the tower radius
    Monster target;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        target = col.gameObject.GetComponent<Monster>();
    }
}
