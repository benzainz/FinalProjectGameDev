using UnityEngine;

public class StartSpriteController : MonoBehaviour
{
    public float displayTime = 2f; // Tiempo en segundos para mostrar el sprite
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtener el componente SpriteRenderer
        Invoke("HideStartSprite", displayTime); // Llamar a HideStartSprite después del tiempo de displayTime
    }

    private void HideStartSprite()
    {
        spriteRenderer.enabled = false; // Desactivar la visualización del sprite
    }
}
