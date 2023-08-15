using System.Collections;
using UnityEngine;

public class VerificarDestruccion : MonoBehaviour
{
    public CollisionFinalBoss collisionFinalBoss;
    public CanvasGroup canvasGroup;
    BackToMainMenu backToMainMenu;

    private void Awake()
    {
        backToMainMenu = GetComponent<BackToMainMenu>();
    }
    private void Update()
    {

        if (collisionFinalBoss != null && collisionFinalBoss.estaDestruido)
        {


            ShowFinalMessage();
            PlayerController.speed = 8;
            PlayerController.tiempoGeneracionDeLaser = 0.5f;
           // Debug.Log("El objeto ha sido destruido.");
        }
    }
    public void ShowFinalMessage()
    {

        StartCoroutine(EsperarYMostrar());
        IEnumerator EsperarYMostrar()
        {
           // Debug.Log("se esta llamano a la corutina");
            yield return new WaitForSeconds(3f); // Esperar 3 segundos
            canvasGroup.alpha = 1f; // Hace visible el texto y la imagen

            yield return new WaitForSeconds(10f);
            Debug.Log("seras enviado al menu principal");
            backToMainMenu.BackToMain();
            GameManager.score = 0;



        }


    }
}
