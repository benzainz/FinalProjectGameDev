using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
//clase de colision,  el playerLaser destruye al enemy1
//y termina con una animacion
public class Enemy1Controller: MonoBehaviour
{
    //Animator animator;
    AnimationStateChanger animationStateChanger;
    // Start is called before the first frame update
    void Awake() {
        //animator = GetComponent<Animator>();
        animationStateChanger = GetComponent<AnimationStateChanger>();


    }
    void Start()
    {

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
            //Debug.Log("Collision with Laser detected001");
            animationStateChanger.ChangeAnimationState("Destroy",0.4f);
            Destroy(gameObject,0.5f);

        }

    }
}
