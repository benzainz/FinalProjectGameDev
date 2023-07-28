//using System.Collections;
//using UnityEngine;

//public class ScriptRunner : MonoBehaviour
//{
//    public MonoBehaviour script1;
//    public MonoBehaviour script2;
//    public MonoBehaviour script3;
//    public float tiempoEntreScripts = 10f;

//    private void Start()
//    {
//        StartCoroutine(RunScripts());
//    }

//    private IEnumerator RunScripts()
//    {
//        while (true)
//        {
//            // Ejecutar el primer script durante 10 segundos
//            script1.enabled = true;
//            yield return new WaitForSeconds(tiempoEntreScripts);
//            script1.enabled = false;

//            // Ejecutar el segundo script durante 10 segundos
//            script2.enabled = true;
//            yield return new WaitForSeconds(tiempoEntreScripts);
//            script2.enabled = false;
//            // Ejecutar el segundo script durante 10 segundos
//            script3.enabled = true;
//            yield return new WaitForSeconds(tiempoEntreScripts);
//            script3.enabled = false;
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRunner : MonoBehaviour
{
    public List<MonoBehaviour> scripts = new List<MonoBehaviour>(); // Lista pública de scripts
    public float tiempoEntreScripts = 10f;

    private void Start()
    {
        StartCoroutine(RunScripts());
    }

    private IEnumerator RunScripts()
    {
        foreach (MonoBehaviour script in scripts)
        {
            // Activar el script actual
            script.enabled = true;

            // Esperar el tiempo entre scripts
            yield return new WaitForSeconds(tiempoEntreScripts);

            // Desactivar el script actual
            script.enabled = false;
        }
    }
}
