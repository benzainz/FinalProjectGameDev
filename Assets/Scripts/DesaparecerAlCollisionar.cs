using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesaparecerAlCollisionar : MonoBehaviour
{

     void OnTriggerEnter2D(Collider2D collision)
    {
        // Compare the tag 
        if (collision.gameObject.CompareTag("ObjetoAumentaPuntaje")) 
        {
           
            Destroy(this.gameObject);

        }
      
    }
    
}
