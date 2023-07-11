using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//clase q que permite mover al jugador de izq a der y q tiene
//un metodo q al apretar una tecla dispara
public class PlayerController : MonoBehaviour
{
    public float limiteIzquierdo;
    public float limiteDerecho, speed;
    public GameObject Player_Laser;
    public Transform attack_Point;

    //Animator animator;
    AnimationStateChanger animationStateChanger;
    // Start is called before the first frame update
    void Awake()
    {
        // animator = GetComponent<Animator>();
        animationStateChanger = GetComponent<AnimationStateChanger>();


    }

    private void Update()
    {

        MaxMovePlayer();
        Attack();

    }
    void MaxMovePlayer() {

            // Obtener el input horizontal (eje X)
            float movimientoHorizontal = Input.GetAxis("Horizontal");

            // Calcular el desplazamiento en el eje X teniendo en cuenta la velocidad de movimiento y el tiempo
            float desplazamientoX = movimientoHorizontal * speed * Time.deltaTime;

            // Calcular la nueva posición en el eje X
            float nuevaPosicionX = transform.position.x + desplazamientoX;

            // Limitar la nueva posición dentro de los límites establecidos
            nuevaPosicionX = Mathf.Clamp(nuevaPosicionX, limiteIzquierdo, limiteDerecho);

            // Crear una nueva posición con la coordenada X limitada y la coordenada Y y Z sin cambios
            Vector3 nuevaPosicion = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);

            // Actualizar la posición de la nave espacial suavemente con Lerp
            transform.position = Vector3.Lerp(transform.position, nuevaPosicion, 0.8f);


    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.K)) {

            GameObject newObject = Instantiate(Player_Laser, attack_Point.position, Quaternion.identity);
            Destroy(newObject, 2);

        }

    }//attack

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyLaser") || collision.gameObject.CompareTag("Meteroids") || collision.gameObject.CompareTag("Enemy1"))
        {
            //call function to play audio on collision
            //audioSource.Play();
            //Debug.Log("¡Boom!");

            // Aquí puedes mostrar el mensaje en la pantalla o realizar cualquier otra acción deseada
            // Debug.Log("Collision with Laser detected");

            animationStateChanger.ChangeAnimationState("Destroy", 0.4f);

            Destroy(gameObject,0.5f);
            Destroy(collision.gameObject);


        }

    }//onCollisonEnter2D


}//class
