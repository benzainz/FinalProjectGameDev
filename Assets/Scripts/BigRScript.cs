using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRScript : MonoBehaviour
{
    AnimationStateChanger animationStateChanger;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        animationStateChanger = GetComponent<AnimationStateChanger>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLaser"))
        {
            //call function to play audio on collision
            audioSource.Play();
            //Debug.Log("¡Boom!");

            // Aquí puedes mostrar el mensaje en la pantalla o realizar cualquier otra acción deseada
            // Debug.Log("Collision with Laser detectedEARTH");

            //animationStateChanger.ChangeAnimationState("Destroy", 0.01f);

            //Destroy(gameObject, 0.02f);
            // Destroy(collision.gameObject);
            //back to main menu funct
            // backToMainMenu.BackToMain();

        }

    }//onCollisonEnter2D



}

