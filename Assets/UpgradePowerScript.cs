using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Clase q da al jugador mas poder en el laser 
public class UpgradePowerScript : MonoBehaviour
{
    
    AudioSource audioSource;

  
    // Start is called before the first frame update
    void Awake()
    {        
        audioSource = GetComponent<AudioSource>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            GetComponent<MakeSound>().PlaySound();
            PlayerController.tiempoGeneracionDeLaser = .25f;

            Destroy(gameObject);

            // Destroy(collision.gameObject);
            //back to main menu funct
            // backToMainMenu.BackToMain();

        }

    }//onCollisonEnter2D

}

