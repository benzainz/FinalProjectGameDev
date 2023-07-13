using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour
{
    AnimationStateChanger animationStateChanger;
    // Start is called before the first frame update
    void Start()
    {
        animationStateChanger = GetComponent<AnimationStateChanger>();
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
            //audioSource.Play();
            //Debug.Log("¡Boom!");

            // Aquí puedes mostrar el mensaje en la pantalla o realizar cualquier otra acción deseada
            //Debug.Log("Collision with Laser detectedEARTH");

            animationStateChanger.ChangeAnimationState("Destroy", 0.05f);

            Destroy(gameObject, 0.06f);
           // Destroy(collision.gameObject);
            //back to main menu funct
           // backToMainMenu.BackToMain();

        }

    }//onCollisonEnter2D



}
