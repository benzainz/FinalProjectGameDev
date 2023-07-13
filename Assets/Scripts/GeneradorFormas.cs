using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorFormas : MonoBehaviour
{
    public GameObject[] formaPrefabs;//Array of prefabs to spawn forms
    public int cantidadFormas = 10; //number of forms to generate
    public float tiempoEntreGeneraciones = 2f; //Time elapsed each time a shape is created"
    public float rangoX = 4f;
    public float tiempoVidaFormas = 8f; // Time passed before destroy each form
    public float alturaDeSpawn = 3f;

    private Camera mainCamera;
    private GameObject[] formasGeneradas;

    private void Start()
    {
        mainCamera = Camera.main;
        formasGeneradas = new GameObject[cantidadFormas];

        //  Start corountine to generate forms 
        StartCoroutine(GenerarFormasPeriodicamente());
    }

    private System.Collections.IEnumerator GenerarFormasPeriodicamente()
    {
        while (true)
        {
            GenerarFormas();
            yield return new WaitForSeconds(tiempoEntreGeneraciones);
        }
    }

    private void GenerarFormas()
    {
        for (int i = 0; i < cantidadFormas; i++)
        {
            //select a random form to be create
            GameObject formaPrefab = formaPrefabs[Random.Range(0, formaPrefabs.Length)];

            // Generate a random position on top of camera 
            //  Vector3 posicionAleatoria = new Vector3(Random.Range(-rangoX, rangoX), mainCamera.transform.position.y + mainCamera.orthographicSize, 0f);
            Vector3 posicionAleatoria = new Vector3(Random.Range(-rangoX, rangoX), mainCamera.transform.position.y + mainCamera.orthographicSize + alturaDeSpawn, 0f);

            //instantiate a new form on the random position
            formasGeneradas[i] = Instantiate(formaPrefab, posicionAleatoria, Quaternion.identity);


            StartCoroutine(DestruirForma(formasGeneradas[i]));
        }
    }


    private System.Collections.IEnumerator DestruirForma(GameObject forma)
    {
        yield return new WaitForSeconds(tiempoVidaFormas);
        Destroy(forma);
    }

}

