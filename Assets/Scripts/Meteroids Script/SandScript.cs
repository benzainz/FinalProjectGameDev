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
            audioSource.Play();
            animationStateChanger.ChangeAnimationState("Destroy", 0.02f);

            Destroy(gameObject, 0.03f);

            // Destroy(collision.gameObject);
            //back to main menu funct
            // backToMainMenu.BackToMain();

        }

    }//onCollisonEnter2D
     //void OnCollisionEnter2D(Collision2D collision)
     //{
     //    if (collision.gameObject.CompareTag("PlayerLaser"))
     //    {
     //        //call function to play audio on collision
     //        GetComponent<AudioSource>().Play();

    //        StartCoroutine(DestroyWithDelay(0.5f));


    //        //StartCoroutine(DestroyWithDelay(0.3f));
    //    }
    //}


    //IEnumerator DestroyWithDelay(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    animationStateChanger.ChangeAnimationState("Destroy", 0.02f);
    //    Destroy(gameObject, 0.03f);
    //}
    //public AudioSource audioSource; // Referencia al componente AudioSource que reproduce el sonido
    //public float soundDuration = 0.5f; // Duración del sonido en segundos

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("PlayerLaser"))
    //    {
    //        // Reproducir el sonido con un objeto auxiliar
    //        GameObject audioObject = new GameObject("AudioObject");
    //        AudioSource audioAux = audioObject.AddComponent<AudioSource>();
    //        audioAux.clip = audioSource.clip;
    //        audioAux.Play();

    //        // Iniciar la corrutina para destruir el objeto principal después de 0.03 segundos

    //        //        StartCoroutine(DestroyWithDelay(0.3f));
    //        animationStateChanger.ChangeAnimationState("Destroy", 0.02f);
    //        StartCoroutine(DestroyWithDelay(0.03f));
    //    }
    //}

    //IEnumerator DestroyWithDelay(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    Destroy(gameObject); // Destruir el objeto principal
    //}



}

