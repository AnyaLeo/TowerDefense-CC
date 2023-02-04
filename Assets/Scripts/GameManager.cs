using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject towerPrefab;
    public GameObject monsterPrefab;
    public GameObject projectilePrefab;
    public float projectileFrequencyRate;
    public float projectileSpeed;
    public float monsterSpeed;
    public int monsterHealth;
    public int projectileDamage;

    public void StartWave() 
    {
        GameObject newMonster = Instantiate(monsterPrefab);
        newMonster.transform.position = LevelManager.Instance.tiles[LevelManager.Instance.homeSpawn].worldPosition;
    }
}
