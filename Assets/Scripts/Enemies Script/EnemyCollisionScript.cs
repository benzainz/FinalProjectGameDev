using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
//clase de colision,  el playerLaser destruye al enemy1
//y termina con una animacion
public class EnemyCollisionScript : MonoBehaviour
{
  
    AnimationStateChanger animationStateChanger;
    MakeSound makeSound;
    //AudioSource audioSource;


    void Awake() {
        //animator = GetComponent<Animator>();
        animationStateChanger = GetComponent<AnimationStateChanger>();
        makeSound = GetComponent<MakeSound>();

    // Start is called before the first frame update
    }

    void Start()
    {
       // audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLaser"))
        {
            //audioSource.Play();
             makeSound.PlaySound();
            //gameObject.GetComponent<MakeSound>().PlaySound();
            
            
            
            animationStateChanger.ChangeAnimationState("Destroy",0.07f);
            Destroy(gameObject,0.08f);

        }

    }
}
