using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    
    public GameObject coin;

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 4f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            SpawnCoin();
        }
    }

    void SpawnCoin()
    {
        int spawnPointX = Random.Range(-7, 1);
        int spawnPointY = Random.Range(0, 1);
        int spawnPointZ = Random.Range(-7, 1);

        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

        GameObject newCoin = Instantiate(coin, spawnPosition, coin.transform.rotation);
        Destroy(newCoin, 10f);
    }
}
