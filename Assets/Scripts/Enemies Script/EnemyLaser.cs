using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public GameObject laserPrefab; // Prefab del láser
    public float velocidadLaser = 5f; // Velocidad del láser
    public float TiempoGeneracionDeLaser = 3f; // Velocidad del láser




    private void Start()
    {
        // Invocar repetidamente el método Disparar cada 1 segundo
        InvokeRepeating("Disparar", TiempoGeneracionDeLaser, TiempoGeneracionDeLaser);
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

//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyLaser : MonoBehaviour
//{
//    public GameObject laserPrefab; // Prefab del láser
//    public float velocidadLaser = 5f; // Velocidad del láser
//    public float TiempoGeneracionDeLaser = 3f; // Tiempo entre generación de láseres
//    public string playerTag = "Player"; // Etiqueta del jugador

//    private void Start()
//    {
//        // Invocar repetidamente el método Disparar cada TiempoGeneracionDeLaser segundos
//        InvokeRepeating("Disparar", TiempoGeneracionDeLaser, TiempoGeneracionDeLaser);
//    }

//    private void Disparar()
//    {
//        // Buscar el objeto del jugador por su etiqueta
//        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

//        if (player != null)
//        {
//            // Calcular la dirección desde el objeto EnemyLaser hacia el objeto del jugador
//            Vector3 direction = player.transform.position - transform.position;

//            // Calcular la rotación para apuntar hacia el jugador
//            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

//            // Instanciar el láser en la posición del EnemyLaser con la rotación hacia el jugador
//            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.Euler(0f, 0f, angle));
//            Destroy(laser, 3);

//            // Obtener el componente Rigidbody2D del láser
//            Rigidbody2D rbLaser = laser.GetComponent<Rigidbody2D>();

//            // Establecer la velocidad del láser en la dirección hacia el jugador
//            rbLaser.velocity = direction.normalized * velocidadLaser;
//        }
//    }
//}
