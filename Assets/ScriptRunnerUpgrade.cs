

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRunnerUpgrade : MonoBehaviour
{

    public List<MonoBehaviour> scripts = new List<MonoBehaviour>(); // Lista pública de scripts
    public float tiempoDeCadaScripts = 10f;

    private void Start()
    {
        StartCoroutine(RunScripts());
    }

    private IEnumerator RunScripts()
    {
        foreach (MonoBehaviour script in scripts)
        {
            yield return new WaitForSeconds(tiempoDeCadaScripts);
            // Activar el script actual
            script.enabled = true;

            // Esperar el tiempo entre scripts
            yield return new WaitForSeconds(tiempoDeCadaScripts);

            // Desactivar el script actual
            script.enabled = false;
        }
    }
}
