

using System.Collections.Generic;
using UnityEngine;

public class CreateFinalBossLaser : MonoBehaviour
{
    public GameObject laserPrefab; // Prefab del primer tipo de láser
    public GameObject laserPrefab2; // Prefab del segundo tipo de láser
    public float velocidadLaser = 5f; // Velocidad del láser
    public float TiempoGeneracionDeLaser = 3f; // Tiempo entre generaciones de láser

    public Transform EnemyAtackPoint;
    public Transform EnemyAtackPoint1;
    public Transform EnemyAtackPoint2;
    public Transform EnemyAtackPoint3;
    public Transform EnemyAtackPoint4; // Nuevo punto de ataque

    private void Start()
    {
        // Invocar repetidamente el método Disparar cada cierto tiempo
        InvokeRepeating("Disparar", TiempoGeneracionDeLaser, TiempoGeneracionDeLaser);
    }

    private void Disparar()
    {
        // Instanciar láser desde las 5 posiciones diferentes
        InstanciarLaser(EnemyAtackPoint.position, laserPrefab);
        InstanciarLaser(EnemyAtackPoint1.position, laserPrefab);
        InstanciarLaser(EnemyAtackPoint2.position, laserPrefab);
        InstanciarLaser(EnemyAtackPoint3.position, laserPrefab);
        InstanciarLaser(EnemyAtackPoint4.position, laserPrefab2); // Nuevo tipo de láser
    }

    private void InstanciarLaser(Vector3 spawnPosition, GameObject prefab)
    {
        // Obtener la altura del objeto "Enemy1"
        float enemyHeight = GetComponent<SpriteRenderer>().bounds.size.y;

        // Calcular la posición de instancia del láser en la parte inferior del objeto "Enemy1"
        Vector3 laserSpawnPosition = spawnPosition - new Vector3(0f, enemyHeight / 2f, 0f);

        // Instanciar el láser en la posición calculada
        GameObject laser = Instantiate(prefab, laserSpawnPosition, Quaternion.identity);

        // Obtener el componente Rigidbody2D del láser
        Rigidbody2D rbLaser = laser.GetComponent<Rigidbody2D>();

        // Establecer la velocidad del láser hacia abajo (eje negativo de 'y')
        rbLaser.velocity = Vector2.down * velocidadLaser;
    }
}
