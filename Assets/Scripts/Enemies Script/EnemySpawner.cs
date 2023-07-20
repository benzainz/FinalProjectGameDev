//using System.Collections;
//using UnityEngine;

//public class EnemySpawner : MonoBehaviour
//{
//    public GameObject enemyPrefab;
//    public float spawnInterval = 2f;
//    public float spawnRangeX = 7f;
//    public float spawnHeight = 6f;
//    public float destroyedAfter = 9f;

//    private void Start()
//    {
//        StartCoroutine(SpawnEnemies());
//    }

//    private IEnumerator SpawnEnemies()
//    {
//        while (true)
//        {
//            // Generar una posición aleatoria dentro del rango especificado
//            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
//            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f);

//            // Instanciar el objeto enemy1 en la posición generada
//            GameObject newObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

//            Destroy(newObject, destroyedAfter);
//            yield return new WaitForSeconds(spawnInterval);
//        }
//    }
//}

using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array de prefabs de enemigos
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
            // Seleccionar aleatoriamente un prefab de enemigo del array
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyPrefab = enemyPrefabs[randomIndex];

            // Generar una posición aleatoria dentro del rango especificado
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f);

            // Instanciar el prefab de enemigo seleccionado en la posición generada
            GameObject newObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            Destroy(newObject, destroyedAfter);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

//using System.Collections;
//using UnityEngine;

//public class EnemySpawner : MonoBehaviour
//{
//    public GameObject[] enemyPrefabs; // Array de prefabs de enemigos
//    public int numberOfEnemies = 5; // Cantidad de enemigos a generar
//    public float spawnInterval = 2f;
//    public float spawnRangeX = 7f;
//    public float spawnHeight = 6f;
//    public float destroyedAfter = 9f;
//    public float spawnRadius = 2f; // Radio del círculo para evitar superposición

//    private void Start()
//    {
//        StartCoroutine(SpawnEnemies());
//    }

//    private IEnumerator SpawnEnemies()
//    {
//        for (int i = 0; i < numberOfEnemies; i++)
//        {
//            // Seleccionar aleatoriamente un prefab de enemigo del array
//            int randomIndex = Random.Range(0, enemyPrefabs.Length);
//            GameObject enemyPrefab = enemyPrefabs[randomIndex];

//            // Generar una posición aleatoria dentro del rango especificado
//            Vector2 randomPosition = GetRandomSpawnPosition();

//            // Instanciar el prefab de enemigo seleccionado en la posición generada
//            GameObject newObject = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

//            Destroy(newObject, destroyedAfter);
//            yield return new WaitForSeconds(spawnInterval);
//        }
//    }

//    private Vector2 GetRandomSpawnPosition()
//    {
//        Vector2 randomPosition = Vector2.zero;
//        bool isOverlapping = true;

//        // Intentar generar una posición que no se superponga con otros objetos
//        while (isOverlapping)
//        {
//            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
//            randomPosition = new Vector2(randomX, spawnHeight);

//            // Verificar si hay colisiones en un círculo alrededor de la posición generada
//            Collider2D[] colliders = Physics2D.OverlapCircleAll(randomPosition, spawnRadius);

//            // Si no hay colisiones, la posición es válida y se puede salir del bucle
//            if (colliders.Length == 0)
//            {
//                isOverlapping = false;
//            }
//        }

//        return randomPosition;
//    }
//}


