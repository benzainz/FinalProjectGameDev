using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandScript : MonoBehaviour
{
    AnimationStateChanger animationStateChanger;
    MakeSound makeSound;



    // Start is called before the first frame update
    void Awake()
    {
        animationStateChanger = GetComponent<AnimationStateChanger>();
        makeSound = GetComponent<MakeSound>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLaser"))
        {

            // GetComponent<MakeSound>().PlaySound();
            makeSound.PlaySound();
            animationStateChanger.ChangeAnimationState("Destroy", 0.01f);

            Destroy(gameObject, 0.02f);

        }

    }
  
}

