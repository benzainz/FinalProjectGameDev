using System.Collections;
using UnityEngine;

public class EnemySpawner4 : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array de prefabs de enemigos
    public float spawnInterval = 2f;
    public float spawnRangeX = 7f;
    public float spawnHeight = 6f;
    public float destroyedAfter = 9f;
    public float tiempoTotalGeneracion = 10f; // Tiempo total de generación en segundos

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        float elapsedTime = 0f; // Tiempo transcurrido
        while (elapsedTime < tiempoTotalGeneracion)
        {
            // Seleccionar aleatoriamente un prefab de enemigo del array
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyPrefab = enemyPrefabs[randomIndex];

            // Generar una posición aleatoria dentro del rango especificado
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f);

            // Comprobar si hay objetos cerca de la posición generada
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 1f);
            bool positionOccupied = colliders.Length > 0;

            // Si la posición está ocupada, encontrar una nueva posición
            while (positionOccupied)
            {
                randomX = Random.Range(-spawnRangeX, spawnRangeX);
                spawnPosition = new Vector3(randomX, spawnHeight, 0f);
                colliders = Physics2D.OverlapCircleAll(spawnPosition, 1f);
                positionOccupied = colliders.Length > 0;
            }

            // Instanciar el prefab de enemigo seleccionado en la posición generada
            GameObject newObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            Destroy(newObject, destroyedAfter);
            elapsedTime += spawnInterval; // Incrementar el tiempo transcurrido
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dibujar un gizmo para mostrar el área donde se pueden generar objetos
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(0f, spawnHeight, 0f), new Vector3(spawnRangeX * 2, 1f, 1f));
    }
}



