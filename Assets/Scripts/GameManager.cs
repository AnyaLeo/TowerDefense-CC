using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject towerPrefab;
    public GameObject monsterPrefab;

    public void StartWave() 
    {
        GameObject newMonster = Instantiate(monsterPrefab);
        newMonster.transform.position = LevelManager.Instance.tiles[LevelManager.Instance.homeSpawn].worldPosition;
    }
}
