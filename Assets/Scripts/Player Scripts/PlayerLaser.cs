using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{

    public float speed = 5f;
    AnimationStateChanger animationStateChanger;

    // Start is called before the first frame update
    void Start()
    {
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1") ||
            collision.gameObject.CompareTag("Sand") ||
            collision.gameObject.CompareTag("Earth"))
        {
            //call function to play audio on collision
            //audioSource.Play();
            //Debug.Log("¡Boom!");

            // Aquí puedes mostrar el mensaje en la pantalla o realizar cualquier otra acción deseada

            // animator.Play("Destroy");
            Destroy(gameObject);
            //Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("Rock")) {
            Debug.Log("¡Boom!");
           animationStateChanger.ChangeAnimationState("Destroy", 0.01f);
           Destroy(gameObject, 0.02f);

            //Destroy(gameObject);

        }

    }//Oncollision


}//class
