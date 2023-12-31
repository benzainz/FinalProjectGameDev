using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    public int pointsPerKill = 10;
    public float speed = 5f;
    int myScore = 0;
    //ScoreManager scoreManager;

    AnimationStateChanger animationStateChanger;
    AudioSource audioSource;
    // Start is called before the first frame update}
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animationStateChanger = GetComponent<AnimationStateChanger>();
        //scoreManager = GetComponent<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    /*En resumen, este código se utiliza para mover un objeto
     * hacia arriba en el eje Y a una velocidad determinada 
     * (speed). Es importante tener en cuenta que este código
     * debe colocarse en el método Update() para que se 
     * ejecute en cada frame y así lograr un movimiento continuo.
     */
    void Move()
    {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1") ||
            collision.gameObject.CompareTag("Sand") ||
            collision.gameObject.CompareTag("Earth"))
        {
            GameManager.score += pointsPerKill;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("BigR"))
        {
            // Debug.Log("¡Boom!");
            animationStateChanger.ChangeAnimationState("Destroy", 0.01f);
            Destroy(gameObject, 0.02f);
            audioSource.Play();

            //Destroy(gameObject);

        }

    }//Oncollision


}//class

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerLaser : MonoBehaviour
//{
//    public int pointsPerKill = 10;
//    public float speed = 5f;
//    int myScore = 0;

//    // Contador de tiempo para controlar la generación de láseres
//    float laserSpawnTimer = 0f;
//    // Intervalo de tiempo deseado para generar el láser
//    float laserSpawnInterval = 0.5f; // Cambia este valor para ajustar la velocidad


//    AnimationStateChanger animationStateChanger;
//    AudioSource audioSource;



//    // Start is called before the first frame update}
//    void Start()
//    {
//        audioSource = GetComponent<AudioSource>();
//        animationStateChanger = GetComponent<AnimationStateChanger>();


//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Move();

//        // Incrementar el contador de tiempo
//        laserSpawnTimer += Time.deltaTime;

//        // Si el contador de tiempo supera el intervalo deseado, generar un láser
//        if (laserSpawnTimer >= laserSpawnInterval)
//        {
//            GenerateLaser();
//            // Reiniciar el contador de tiempo
//            laserSpawnTimer = 0f;
//        }



//    }

//    void Move()
//    {
//        Vector3 temp = transform.position;
//        temp.y += speed * Time.deltaTime;
//        transform.position = temp;
//    }


//    void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Enemy1") ||
//            collision.gameObject.CompareTag("Sand") ||
//            collision.gameObject.CompareTag("Earth"))
//        {
//            GameManager.score += pointsPerKill;
//            Destroy(gameObject);
//        }
//        if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("BigR"))
//        {
//            // Debug.Log("¡Boom!");
//            animationStateChanger.ChangeAnimationState("Destroy", 0.01f);
//            Destroy(gameObject, 0.02f);
//            audioSource.Play();

//            //Destroy(gameObject);

//        }

//    }//Oncollision


//}//class

