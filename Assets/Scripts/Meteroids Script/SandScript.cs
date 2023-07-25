using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandScript : MonoBehaviour
{
    AnimationStateChanger animationStateChanger;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        animationStateChanger = GetComponent<AnimationStateChanger>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLaser"))
        {
            //call function to play audio on collision
            //audioSource.Play();
            //Debug.Log("¡Boom!");

            // Aquí puedes mostrar el mensaje en la pantalla o realizar cualquier otra acción deseada
            //  Debug.Log("Collision with Laser detectedEARTH");
            GetComponent<MakeSound>().PlaySound();
            animationStateChanger.ChangeAnimationState("Destroy", 0.01f);

            Destroy(gameObject, 0.02f);

            // Destroy(collision.gameObject);
            //back to main menu funct
            // backToMainMenu.BackToMain();

        }

    }
  
}

