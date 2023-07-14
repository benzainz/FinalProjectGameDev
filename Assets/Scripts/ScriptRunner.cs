using System.Collections;
using UnityEngine;

public class ScriptRunner : MonoBehaviour
{
    public MonoBehaviour script1;
    public MonoBehaviour script2;
    public float tiempoEntreScripts = 10f;

    private void Start()
    {
        StartCoroutine(RunScripts());
    }

    private IEnumerator RunScripts()
    {
        while (true)
        {
            // Ejecutar el primer script durante 10 segundos
            script1.enabled = true;
            yield return new WaitForSeconds(tiempoEntreScripts);
            script1.enabled = false;

            // Ejecutar el segundo script durante 10 segundos
            script2.enabled = true;
            yield return new WaitForSeconds(tiempoEntreScripts);
            script2.enabled = false;
        }
    }
}
