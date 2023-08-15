using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpeedScript : MonoBehaviour
{
    //public AudioClip explotionSFX;
    //AnimationStateChanger animationStateChanger;
    AudioSource audioSource;
    //PlayerController playerController;







    // Start is called before the first frame update
    void Awake()
    {
       // animationStateChanger = GetComponent<AnimationStateChanger>();
        audioSource = GetComponent<AudioSource>();
        //playerController = GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            GetComponent<MakeSound>().PlaySound();
            PlayerController.speed = 12;

           // animationStateChanger.ChangeAnimationState("Destroy", 0.04f);

            Destroy(gameObject);

            // Destroy(collision.gameObject);
            //back to main menu funct
            // backToMainMenu.BackToMain();

        }

    }//onCollisonEnter2D

}
