using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    AnimationStateChanger animationStateChanger;
    MakeSound makeSound;
    // Start is called before the first frame update
    void Start()
    {
        animationStateChanger = GetComponent<AnimationStateChanger>();
        makeSound = GetComponent<MakeSound>();

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLaser"))
        {
            //call function to play audio on collision
            makeSound.PlaySound();
            //Debug.Log("¡Boom!");
        }

    }//onCollisonEnter2D



}

