using System.Collections;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float verticalSpeed = 3f; // Velocidad vertical del movimiento
    public float horizontalSpeed = 5f; // Velocidad horizontal del movimiento
    public float showAfter = 2f;

    private bool isMovingDown = false;
    private bool hasGeneratedPrefab = false;
    private bool shouldMovePrefab = true;

    private void Start()
    {
        // Invocar el método para generar el prefab después de 5 segundos
        Invoke("GeneratePrefab", showAfter);
    }

    private void GeneratePrefab()
    {
        // Verificar si ya se generó el prefab para evitar generar más de uno
        if (hasGeneratedPrefab)
            return;

        // Instanciar el prefab en las coordenadas x=0, y=7
        GameObject newObject = Instantiate(gameObject, new Vector3(0f, 7f, 0f), Quaternion.identity);
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
            if (obj != null)
            {
                // Mover el objeto hacia abajo hasta y=4 en 2 segundos con la velocidad vertical especificada
                obj.transform.position = Vector3.Lerp(initialPosition, targetPosition, timePassed / 2f) + Vector3.down * verticalSpeed * Time.deltaTime;
                timePassed += Time.deltaTime;
            }
            yield return null;

        }
        if (obj != null) // Verificar nuevamente antes de usarlo
        {
            obj.transform.position = targetPosition;
        }

        while (true)
        {
            // Mover el objeto horizontalmente entre x=-5 y x=5 en 3 segundos, repetidamente
            float horizontalTimePassed = 0f;
            Vector3 startPosition = obj.transform.position;
            Vector3 targetXPosition = new Vector3(Random.Range(-5f, 5f), obj.transform.position.y, 0f);

            while (horizontalTimePassed < 3f)
            {
                if (obj != null)
                {
                    // Mover el objeto horizontalmente con la velocidad horizontal especificada
                    obj.transform.position = Vector3.Lerp(startPosition, targetXPosition, horizontalTimePassed / 3f);
                    horizontalTimePassed += Time.deltaTime * horizontalSpeed; // Multiplicamos por la velocidad horizontal
                }
                yield return null;
            }
        }
    }

    // Método para detener el movimiento del prefab desde fuera de la clase
    public void StopMovePrefab()
    {
        shouldMovePrefab = false;
    }
}
