using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRangeX = 7f;
    public float spawnHeight = 6f;
    public float destroyedAfter = 9f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Generar una posición aleatoria dentro del rango especificado
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f);

            // Instanciar el objeto enemy1 en la posición generada
            GameObject newObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            Destroy(newObject, destroyedAfter);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

