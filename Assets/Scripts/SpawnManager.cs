using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject[] powerups;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //spawn game objects every 5 seconds
    //crreate a coroutine of type IEnumerator -- Yield Events
    //while loop

    IEnumerator SpawnEnemyRoutine ()
    {
        //while loop (infinite loop)
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
        //Instantiate enemy prefab
            //yield wait for 5 seconds
    }

    IEnumerator SpawnPowerupRoutine()
    {
        //every 3-7 seconds, spawn in powerup
        while (_stopSpawning == false)
        {
            Vector3 placeToSpawn = new Vector3(Random.Range(-8f,8f),7,0);
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerups[randomPowerUp], placeToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3,8));
        }


    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

}
