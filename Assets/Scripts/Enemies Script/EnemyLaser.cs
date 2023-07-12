using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public GameObject laserPrefab; // Prefab del láser
    public float velocidadLaser = 5f; // Velocidad del láser

    private void Start()
    {
        // Invocar repetidamente el método Disparar cada 1 segundo
        InvokeRepeating("Disparar", 1.3f, 1.3f);
    }

    private void Disparar()
    {
        // Obtener la altura del objeto "Enemy1"
        float enemyHeight = GetComponent<SpriteRenderer>().bounds.size.y;

        // Calcular la posición de instancia del láser en la parte inferior del objeto "Enemy1"
        Vector3 laserSpawnPosition = transform.position - new Vector3(0f, enemyHeight / 2f, 0f);

        // Instanciar el láser en la posición calculada
        GameObject laser = Instantiate(laserPrefab, laserSpawnPosition, Quaternion.identity);
        Destroy(laser, 3);

        // Obtener el componente Rigidbody2D del láser
        Rigidbody2D rbLaser = laser.GetComponent<Rigidbody2D>();

        // Establecer la velocidad del láser hacia abajo (eje negativo de 'y')
        rbLaser.velocity = Vector2.down * velocidadLaser;
    }
}




