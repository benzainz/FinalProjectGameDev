using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public string nextScene; // Nombre de la segunda escena a cargar
    public float timeToSwitch = 60f; // Tiempo en segundos antes de cambiar a la segunda escena

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        // Si el tiempo ha pasado el límite, cargar la segunda escena
        if (timer >= timeToSwitch)
        {
            SwitchToSecondScene();
        }
    }

    private void SwitchToSecondScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
