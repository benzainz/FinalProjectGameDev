using UnityEngine;
using UnityEngine.UI;

public class UIScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    private void Update()
    {
        // Actualizar el texto con el puntaje actual
        scoreText.text = " " + GameManager.score.ToString();
    }
}

