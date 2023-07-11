using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class BackToMenu : MonoBehaviour
{
    public string sceneName; // scene name 
   
     void OnTriggerEnter2D(Collider2D collision)
    {
        // Compare the object tag 
        if (collision.gameObject.CompareTag("ObjetoAumentaPuntaje")) 
        {
           
            SceneManager.LoadScene(sceneName);

        }
    }
}
