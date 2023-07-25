using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour
{
    //public AudioClip explotionSFX;
    AnimationStateChanger animationStateChanger;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
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

            GetComponent<MakeSound>().PlaySound();

            animationStateChanger.ChangeAnimationState("Destroy", 0.04f);

            Destroy(gameObject, 0.05f);
           
           // Destroy(collision.gameObject);
            //back to main menu funct
           // backToMainMenu.BackToMain();

        }

    }//onCollisonEnter2D



}
