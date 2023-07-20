using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float limiteIzquierdo;
    public float limiteDerecho, speed;
    public GameObject Player_Laser;
    public Transform attack_Point;
    public AudioClip explotionSFX;
    AudioSource audioSource;
    
    //public AudioSource audioSourceExplotion;


    private float tiempoUltimaCreacion = 0f; // Tiempo en el que se creó el último láser

    AnimationStateChanger animationStateChanger;
    BackToMainMenu backToMainMenu;
  
    void Start()
    {
        animationStateChanger = GetComponent<AnimationStateChanger>();
        backToMainMenu = GetComponent<BackToMainMenu>();
        //audioSourceExplotion = GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        MaxMovePlayer();

        // Verificar si se presionó la tecla 'k' y ha pasado al menos 1 segundo desde la última creación de láser
        if (Input.GetKeyDown(KeyCode.K) && Time.time - tiempoUltimaCreacion >= 0.5f)
        {
            CrearLaser();
            tiempoUltimaCreacion = Time.time; // Actualizar el tiempo de la última creación de láser
            
        }
    }

    void MaxMovePlayer()
    {
        //Código para el movimiento del jugador
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

    void CrearLaser()
    {
        GameObject newObject = Instantiate(Player_Laser, attack_Point.position, Quaternion.identity);
        Destroy(newObject, 2);
        audioSource.Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Código para las colisiones
        if (collision.gameObject.CompareTag("EnemyLaser")   ||
            collision.gameObject.CompareTag("Earth")        ||
            collision.gameObject.CompareTag("Rock")         ||
            collision.gameObject.CompareTag("Sand")         ||
            collision.gameObject.CompareTag("Enemy1")        )
        {
            //call function to play audio on collision
            //audioSourceExplotion.Play();
            audioSource.PlayOneShot(explotionSFX);

            animationStateChanger.ChangeAnimationState("Destroy", 0.4f);

            Destroy(gameObject, 0.5f);
            Destroy(collision.gameObject);
            
            //back to main menu funct
            //backToMainMenu.BackToMain();

        }
    }
}
