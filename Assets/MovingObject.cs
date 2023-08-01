
//using System.Collections;
//using UnityEngine;

//public class MovingObject : MonoBehaviour
//{
//    public GameObject prefab; // Prefab del objeto a mover

//    private bool isMovingDown = false;
//    private bool hasGeneratedPrefab = false;

//    private void Start()
//    {
//        // Invocar el método para generar el prefab después de 5 segundos
//        Invoke("GeneratePrefab", 5f);
//    }

//    private void GeneratePrefab()
//    {
//        // Verificar si ya se generó el prefab para evitar generar más de uno
//        if (hasGeneratedPrefab)
//            return;

//        // Instanciar el prefab en las coordenadas x=0, y=7
//        GameObject newObject = Instantiate(prefab, new Vector3(0f, 7f, 0f), Quaternion.identity);
//        StartCoroutine(MovePrefab(newObject));

//        hasGeneratedPrefab = true;
//    }

//    private IEnumerator MovePrefab(GameObject obj)
//    {
//        float timePassed = 0f;
//        Vector3 targetPosition = new Vector3(0f, 4f, 0f);
//        Vector3 initialPosition = obj.transform.position;

//        while (timePassed < 2f)
//        {
//            // Mover el objeto hacia abajo hasta y=4 en 2 segundos
//            obj.transform.position = Vector3.Lerp(initialPosition, targetPosition, timePassed / 2f);
//            timePassed += Time.deltaTime;
//            yield return null;
//        }

//        // Asegurarse de que el objeto no pase de y=4
//        obj.transform.position = targetPosition;

//        while (true)
//        {
//            // Mover el objeto horizontalmente entre x=-5 y x=5 en 3 segundos, repetidamente
//            float horizontalTimePassed = 0f;
//            Vector3 startPosition = obj.transform.position;
//            Vector3 targetXPosition = new Vector3(Random.Range(-5f, 5f), obj.transform.position.y, 0f);

//            while (horizontalTimePassed < 3f)
//            {
//                obj.transform.position = Vector3.Lerp(startPosition, targetXPosition, horizontalTimePassed / 3f);
//                horizontalTimePassed += Time.deltaTime;
//                yield return null;
//            }
//        }
//    }
//}

using System.Collections;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public GameObject prefab; // Prefab del objeto a mover
    public float verticalSpeed = 3f; // Velocidad vertical del movimiento
    public float horizontalSpeed = 5f; // Velocidad horizontal del movimiento

    private bool isMovingDown = false;
    private bool hasGeneratedPrefab = false;

    private void Start()
    {
        // Invocar el método para generar el prefab después de 5 segundos
        Invoke("GeneratePrefab", 5f);
    }

    private void GeneratePrefab()
    {
        // Verificar si ya se generó el prefab para evitar generar más de uno
        if (hasGeneratedPrefab)
            return;

        // Instanciar el prefab en las coordenadas x=0, y=7
        GameObject newObject = Instantiate(prefab, new Vector3(0f, 7f, 0f), Quaternion.identity);
        StartCoroutine(MovePrefab(newObject));

        hasGeneratedPrefab = true;
    }

    private IEnumerator MovePrefab(GameObject obj)
    {
        float timePassed = 0f;
        Vector3 targetPosition = new Vector3(0f, 4f, 0f);
        Vector3 initialPosition = obj.transform.position;

        while (timePassed < 2f)
        {
            // Mover el objeto hacia abajo hasta y=4 en 2 segundos con la velocidad vertical especificada
            obj.transform.position = Vector3.Lerp(initialPosition, targetPosition, timePassed / 2f) + Vector3.down * verticalSpeed * Time.deltaTime;
            timePassed += Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que el objeto no pase de y=4
        obj.transform.position = targetPosition;

        while (true)
        {
            // Mover el objeto horizontalmente entre x=-5 y x=5 en 3 segundos, repetidamente
            float horizontalTimePassed = 0f;
            Vector3 startPosition = obj.transform.position;
            Vector3 targetXPosition = new Vector3(Random.Range(-5f, 5f), obj.transform.position.y, 0f);

            while (horizontalTimePassed < 3f)
            {
                // Mover el objeto horizontalmente con la velocidad horizontal especificada
                obj.transform.position = Vector3.Lerp(startPosition, targetXPosition, horizontalTimePassed / 3f);
                horizontalTimePassed += Time.deltaTime * horizontalSpeed; // Multiplicamos por la velocidad horizontal
                yield return null;
            }
        }
    }
}
