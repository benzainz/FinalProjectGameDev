

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFinalBoss : MonoBehaviour
{
    AnimationStateChanger animationStateChanger;
    AudioSource audioSource;
    List<Transform> childObjects = new List<Transform>();

    public AudioClip explotion;

    public int points = 20;
    int collisionsCount = 0;
    int maxCollisions = 3;

    Color originalColor;
    Renderer renderer;
    bool changingColor = false;

    void Awake()
    {
        animationStateChanger = GetComponent<AnimationStateChanger>();
        foreach (Transform child in transform)
        {
            childObjects.Add(child);
        }

        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource1 = GetComponent<AudioClip>();
    }

    void Update()
    {
        if (changingColor)
        {
            // Cambiar el color a rojo.
            renderer.material.color = Color.red;
            changingColor = false;

            // Iniciar la restauración del color después de medio segundo.
            StartCoroutine(RestoreColor());
        }
    }

    IEnumerator RestoreColor()
    {
        yield return new WaitForSeconds(0.5f);
        // Restaurar el color original.
        renderer.material.color = originalColor;
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
            if (collisionsCount >= maxCollisions)
            {
                audioSource.Play();
                animationStateChanger.ChangeAnimationState("Destroy", 1.3f);
                // Si se alcanzó el límite, destruir el objeto principal.
                Destroy(gameObject, 1.4f);
                GameManager.score += 100;
            }
        }
    }
}
