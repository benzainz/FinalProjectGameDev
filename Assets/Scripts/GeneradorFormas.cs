//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GeneradorFormas : MonoBehaviour
//{
//    public GameObject[] formaPrefabs;//Array of prefabs to spawn forms
//    public int cantidadFormas = 10; //number of forms to generate
//    public float tiempoEntreGeneraciones = 2f; //Time elapsed each time a shape is created"
//    public float rangoX = 4f;
//    public float tiempoVidaFormas = 8f; // Time passed before destroy each form
//    public float alturaDeSpawn = 3f;

//    private Camera mainCamera;
//    private GameObject[] formasGeneradas;

//    private void Start()
//    {
//        mainCamera = Camera.main;
//        formasGeneradas = new GameObject[cantidadFormas];

//        //  Start corountine to generate forms 
//        StartCoroutine(GenerarFormasPeriodicamente());
//    }

//    private System.Collections.IEnumerator GenerarFormasPeriodicamente()
//    {
//        while (true)
//        {
//            GenerarFormas();
//            yield return new WaitForSeconds(tiempoEntreGeneraciones);
//        }
//    }

//    //private void GenerarFormas()
//    //{
//    //    for (int i = 0; i < cantidadFormas; i++)
//    //    {
//    //        //select a random form to be create
//    //        GameObject formaPrefab = formaPrefabs[Random.Range(0, formaPrefabs.Length)];

//    //        // Generate a random position on top of camera 
//    //        //  Vector3 posicionAleatoria = new Vector3(Random.Range(-rangoX, rangoX), mainCamera.transform.position.y + mainCamera.orthographicSize, 0f);
//    //        Vector3 posicionAleatoria = new Vector3(Random.Range(-rangoX, rangoX), mainCamera.transform.position.y + mainCamera.orthographicSize + alturaDeSpawn, 0f);

//    //        //instantiate a new form on the random position
//    //        formasGeneradas[i] = Instantiate(formaPrefab, posicionAleatoria, Quaternion.identity);


//    //        StartCoroutine(DestruirForma(formasGeneradas[i]));
//    //    }
//    //}
//    private void GenerarFormas()
//    {
//        for (int i = 0; i < cantidadFormas; i++)
//        {
//            // Select a random form to be created
//            GameObject formaPrefab = formaPrefabs[Random.Range(0, formaPrefabs.Length)];

//            // Generate a random position on top of the camera
//            Vector3 posicionAleatoria = new Vector3(Random.Range(-rangoX, rangoX), mainCamera.transform.position.y + mainCamera.orthographicSize + alturaDeSpawn, 0f);

//            // Check for collision with existing forms
//            Collider2D[] colliders = Physics2D.OverlapCircleAll(posicionAleatoria, 1f);
//            bool collidesWithOtherForm = colliders.Length > 0;

//            // If collision detected, find a new position
//            while (collidesWithOtherForm)
//            {
//                posicionAleatoria = new Vector3(Random.Range(-rangoX, rangoX), mainCamera.transform.position.y + mainCamera.orthographicSize + alturaDeSpawn, 0f);
//                colliders = Physics2D.OverlapCircleAll(posicionAleatoria, 1f);
//                collidesWithOtherForm = colliders.Length > 0;
//            }

//            // Instantiate a new form on the random position
//            formasGeneradas[i] = Instantiate(formaPrefab, posicionAleatoria, Quaternion.identity);

//            StartCoroutine(DestruirForma(formasGeneradas[i]));
//        }
//    }



//    private System.Collections.IEnumerator DestruirForma(GameObject forma)
//    {
//        yield return new WaitForSeconds(tiempoVidaFormas);
//        Destroy(forma);
//    }

//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorFormas : MonoBehaviour
{
    public GameObject[] formaPrefabs;
    public int cantidadFormas = 2;
    public float tiempoEntreGeneraciones = 2f;
    public float rangoX = 4f;
    public float tiempoVidaFormas = 8f;
    public float alturaDeSpawn = 3f;
    public float tiempoTotalGeneracion = 10f; // Tiempo total de generación en segundos

    private Camera mainCamera;
    private GameObject[] formasGeneradas;
    private bool generacionActiva = true; // Bandera para controlar la generación

    private void Start()
    {
        mainCamera = Camera.main;
        formasGeneradas = new GameObject[cantidadFormas];

        StartCoroutine(GenerarFormasPeriodicamente());
        StartCoroutine(DetenerGeneracion());
    }

    private IEnumerator GenerarFormasPeriodicamente()
    {
        while (generacionActiva)
        {
            GenerarFormas();
            yield return new WaitForSeconds(tiempoEntreGeneraciones);
        }
    }

    private IEnumerator DetenerGeneracion()
    {
        yield return new WaitForSeconds(tiempoTotalGeneracion);
        generacionActiva = false;
    }

    private void GenerarFormas()
    {
        for (int i = 0; i < cantidadFormas; i++)
        {
            if (!generacionActiva)
                break;

            GameObject formaPrefab = formaPrefabs[Random.Range(0, formaPrefabs.Length)];

            Vector3 posicionAleatoria = new Vector3(Random.Range(-rangoX, rangoX), mainCamera.transform.position.y + mainCamera.orthographicSize + alturaDeSpawn, 0f);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(posicionAleatoria, 1f);
            bool collidesWithOtherForm = colliders.Length > 0;

            while (collidesWithOtherForm)
            {
                posicionAleatoria = new Vector3(Random.Range(-rangoX, rangoX), mainCamera.transform.position.y + mainCamera.orthographicSize + alturaDeSpawn, 0f);
                colliders = Physics2D.OverlapCircleAll(posicionAleatoria, 1f);
                collidesWithOtherForm = colliders.Length > 0;
            }

            formasGeneradas[i] = Instantiate(formaPrefab, posicionAleatoria, Quaternion.identity);

            StartCoroutine(DestruirForma(formasGeneradas[i]));
        }
    }

    private IEnumerator DestruirForma(GameObject forma)
    {
        yield return new WaitForSeconds(tiempoVidaFormas);
        Destroy(forma);
    }
}


