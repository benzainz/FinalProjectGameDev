using System.Collections;
using UnityEngine;

public class VerificarDestruccion : MonoBehaviour
{
    public CollisionFinalBoss collisionFinalBoss;
    public CanvasGroup canvasGroup;

    private void Update()
    {
        if (collisionFinalBoss != null && collisionFinalBoss.estaDestruido)
        {


            ShowFinalMessage();
            Debug.Log("El objeto ha sido destruido.");
        }
    }
    public void ShowFinalMessage()
    {

        StartCoroutine(EsperarYMostrar());
        IEnumerator EsperarYMostrar()
        {
            Debug.Log("se esta llamano a la corutina");
            yield return new WaitForSeconds(3f); // Esperar 3 segundos
            canvasGroup.alpha = 1f; // Hace visible el texto y la imagen
            Debug.Log("Corutina terminada después de 3 segundos.");
        }


    }
}
