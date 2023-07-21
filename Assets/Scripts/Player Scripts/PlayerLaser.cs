using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{

    public float speed = 5f;
    AnimationStateChanger animationStateChanger;
    AudioSource audioSource;
    // Start is called before the first frame update}
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animationStateChanger = GetComponent<AnimationStateChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    /*En resumen, este código se utiliza para mover un objeto
     * hacia arriba en el eje Y a una velocidad determinada 
     * (speed). Es importante tener en cuenta que este código
     * debe colocarse en el método Update() para que se 
     * ejecute en cada frame y así lograr un movimiento continuo.
     */
    void Move() {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1")   ||
            collision.gameObject.CompareTag("Sand")     ||
            collision.gameObject.CompareTag("Earth")    )
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("BigR")) {
           // Debug.Log("¡Boom!");
           animationStateChanger.ChangeAnimationState("Destroy", 0.01f);
           Destroy(gameObject, 0.02f);
           audioSource.Play();

            //Destroy(gameObject);

        }

    }//Oncollision


}//class
