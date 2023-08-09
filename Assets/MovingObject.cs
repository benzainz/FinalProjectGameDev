using System.Collections;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float startDelay = 3f;  // Tiempo de espera antes de empezar a mover el objeto
    public float moveDuration = 3f; // Duración del movimiento hacia abajo
    public Vector3 targetPosition = new Vector3(0f, 4f, 0f); // Posición objetivo hacia donde el objeto se moverá

    [SerializeField] public float horizontalSpeed = 3f; // Velocidad de movimiento horizontal
    public float horizontalRange = 6f; // Rango horizontal de movimiento

    public float startHorizontalDelay = 5f; // Tiempo en segundos antes de iniciar el movimiento horizontal

    private void Start()
    {
        StartCoroutine(MoveDown());

        StartCoroutine(StartHorizontal());
    }

    private IEnumerator MoveDown()
    {
        yield return new WaitForSeconds(startDelay);

        Vector3 initialPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que el objeto esté exactamente en la posición final
        transform.position = targetPosition;
    }

    private IEnumerator StartHorizontal()
    {
        yield return new WaitForSeconds(startHorizontalDelay);

        StartCoroutine(MoveHorizontal());
    }

    private IEnumerator MoveHorizontal()
    {
        float currentX = transform.position.x;
        float targetX = currentX;

        while (true)
        {
            targetX = Mathf.PingPong(Time.time * horizontalSpeed, horizontalRange) - horizontalRange / 2f;
            Vector3 newPosition = new Vector3(targetX, transform.position.y, transform.position.z);
            transform.position = newPosition;
            yield return null;
        }
    }
}
