using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float limiteIzquierdo;
    public float limiteDerecho;
    public static float speed = 9f;
    public static float tiempoGeneracionDeLaser = .5f;




    public GameObject Player_Laser;
    public GameObject statusBar;
    public Transform attack_Point;
    public AudioClip explotionSFX;
    

    AudioSource audioSource;
    AnimationStateChanger animationStateChanger;
    BackToMainMenu backToMainMenu;
    Renderer renderer;

    //public AudioSource audioSourceExplotion;
    private float tiempoUltimaCreacion = 0f; // Tiempo en el que se creó el último láser

    //Cinema variables

    public float time4Cinema2Start = 60f;
    bool cinematicaIniciada = false;
    float tiempoCinematica = 0f;
    Vector3 posicionInicial;

    private Color colorOriginal;
    

    private void Awake()
    {
        
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animationStateChanger = GetComponent<AnimationStateChanger>();
        backToMainMenu = GetComponent<BackToMainMenu>();

        // Obtener el componente Renderer del objeto
        renderer = GetComponent<Renderer>();

        // Almacenar el color original del objeto
        colorOriginal = renderer.material.color;

        // Invocar el método para comenzar la cinemática después de 60 segundos (1 minuto)
        Invoke("IniciarCinematica", time4Cinema2Start);

    }

    void Update()
    {
        
        EndSceneCinematic();

        // Verificar si NO está en cinemática y se presionó la tecla 'k' y ha pasado al menos 1 segundo desde la última creación de láser
        if (!cinematicaIniciada && Input.GetKeyDown(KeyCode.K) && Time.time - tiempoUltimaCreacion >= tiempoGeneracionDeLaser)
        {
            CrearLaser();
            tiempoUltimaCreacion = Time.time; // Actualizar el tiempo de la última creación de láser
        }



    }
    void IniciarCinematica()
    {
        cinematicaIniciada = true;
        tiempoCinematica = 0f;
        posicionInicial = transform.position;
     


    }

    void EndSceneCinematic()
    {
        if (cinematicaIniciada)
        {
            // Incrementar el tiempo de la cinemática
            tiempoCinematica += Time.deltaTime;

            if (tiempoCinematica <= 2f)
            {
                // Llevar la nave del jugador a la posición (0, -4) en 2 segundos
                transform.position = Vector3.Lerp(posicionInicial, new Vector3(0f, -4f, 0f), tiempoCinematica / 2f);
            }
            else
            {
                // Hacer que la nave desaparezca de la escena
                transform.position += Vector3.up * 20f * Time.deltaTime;
                Destroy(gameObject, time4Cinema2Start + 2f);
            }
        }
        else
        {
           // Player_Laser.SetActive(true);
            MaxMovePlayer();
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


    int maxCollisions = 2;
    int collisionsCount = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Código para las colisiones
        if (collision.gameObject.CompareTag("EnemyLaser") ||
            collision.gameObject.CompareTag("Earth") ||
            collision.gameObject.CompareTag("Rock") ||
            collision.gameObject.CompareTag("Sand") ||
            collision.gameObject.CompareTag("Fire") ||
            collision.gameObject.CompareTag("Enemy1"))
            {
            collisionsCount++;

                if (collisionsCount == 1)
                {

                statusBar.GetComponent<StatusBar>().ChangeStatusBar(0.5f);
                Destroy(collision.gameObject);

                // Cambiar el color del objeto a rojo
                renderer.material.color = Color.red;

                // Iniciar la corutina para restablecer el color original después de medio segundo
                StartCoroutine(RestablecerColor());
                // Cambiar el color del objeto a rojo
       

            }
                if (collisionsCount >= maxCollisions) {
                //call function to play audio on collision
                //audioSourceExplotion.Play();
                audioSource.PlayOneShot(explotionSFX);
                Destroy(collision.gameObject);
                animationStateChanger.ChangeAnimationState("Destroy", 0.4f);
                //Destroy(gameObject);
                // Desactivar el componente PlayerController en lugar de destruir el objeto
                // Esto permitirá que la corutina se ejecute antes de que el objeto sea destruido.

                statusBar.GetComponent<StatusBar>().ChangeStatusBar(0f);
                enabled = false;


                //back to main menu coroutine
                StartCoroutine(WaitAndBackToMain());



            }


            }
        else if (collision.gameObject.CompareTag("BigR"))
            {
            audioSource.PlayOneShot(explotionSFX);
            //Destroy(collision.gameObject);
            animationStateChanger.ChangeAnimationState("Destroy", 0.4f);

            // Desactivar el componente PlayerController en lugar de destruir el objeto
            // Esto permitirá que la corutina se ejecute antes de que el objeto sea destruido.
            enabled = false;

            //back to main menu coroutine
            StartCoroutine(WaitAndBackToMain());


        }
    }//OnCollisionEnter2D

    IEnumerator WaitAndBackToMain()
    {
        yield return new WaitForSeconds(0.7f);


        // Llamar a la función BackToMain del componente BackToMainMenu
        // Esto se hará después de que la corutina se haya completado.
        GameManager.score = 0;
        backToMainMenu.BackToMain();
    }

    IEnumerator RestablecerColor()
    {
        // Esperar medio segundo
        yield return new WaitForSeconds(0.15f);

        // Restablecer el color original del objeto
        renderer.material.color = colorOriginal;

        yield return new WaitForSeconds(0.15f);

        renderer.material.color = Color.red;

        // Esperar medio segundo
        yield return new WaitForSeconds(0.15f);

        // Restablecer el color original del objeto
        renderer.material.color = colorOriginal;
    }

}
