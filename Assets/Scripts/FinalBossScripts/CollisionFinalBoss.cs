

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFinalBoss : MonoBehaviour
{
    AnimationStateChanger animationStateChanger;
    AudioSource audioSource;
    List<Transform> childObjects = new List<Transform>();
    MovingObject movingObject;
    CreateFinalBossLaser createFinalBossLaser;
    Renderer r;

    public AudioClip explotion;
    public bool estaDestruido = false;
    public int points = 20;
    int collisionsCount = 0;
    int maxCollisions = 50;

    Color originalColor;
   
    bool changingColor = false;

    void Awake()
    {
        animationStateChanger = GetComponent<AnimationStateChanger>();
        foreach (Transform child in transform)
        {
            childObjects.Add(child);
        }

        r = GetComponent<Renderer>();
        originalColor = r.material.color;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        movingObject = GetComponent<MovingObject>();
        createFinalBossLaser = GetComponent<CreateFinalBossLaser>();

        // createFinalBossLaser1 = GetComponent<CreateFinalBossLaser>();


        //audioSource1 = GetComponent<AudioClip>();
    }

    void Update()
    {
        if (changingColor)
        {
            // Cambiar el color a rojo.
            r.material.color = Color.red;
            changingColor = false;

            // Iniciar la restauración del color después de medio segundo.
            StartCoroutine(RestoreColor());
        }
    }

    IEnumerator RestoreColor()
    {
        yield return new WaitForSeconds(0.5f);
        // Restaurar el color original.
        r.material.color = originalColor;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLaser"))
        {
            // Incrementar el contador de colisiones.
            collisionsCount++;


            // Cambiar el color a rojo.
            changingColor = true;

            audioSource.PlayOneShot(explotion);

            GameManager.score += points;

            // Comprobar si se alcanzó el límite de colisiones.
            if (collisionsCount == 10)
            {

                // Debug.Log("Cambiar la velocidad horizontal de bigboss");
                //BigbossMovement.GetComponent<MovingObject>().horizontalSpeed = 15;

                movingObject.horizontalSpeed = 6;
                createFinalBossLaser.velocidadLaser = 5;
                //createFinalBossLaser1.TiempoGeneracionDeLaser = 1;

               // Debug.Log("se ha cambiado la velocidad horizontal de bigboss a 10");
                GameManager.score += 100;
            }
            if (collisionsCount == 20)
            {

               // Debug.Log("se ha cambiado la velocidad horizontal de bigboss a 20");
                //BigbossMovement.GetComponent<MovingObject>().horizontalSpeed = 15;

                movingObject.horizontalSpeed = 9;
                createFinalBossLaser.velocidadLaser = 7;
                // createFinalBossLaser1.TiempoGeneracionDeLaser = .5f;


                
                GameManager.score += 500;
            }
            // Comprobar si se alcanzó el límite de colisiones.
            if (collisionsCount >= maxCollisions)
            {

                GameManager.score += 1000;
                audioSource.Play();
                animationStateChanger.ChangeAnimationState("Destroy", 1f);

                //ShowFinalMessage();
                estaDestruido = true;
                Destroy(gameObject, 1.1f);

               



            }

        }
    }
}
