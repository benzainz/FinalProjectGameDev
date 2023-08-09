using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public ImageFader imageFader;
    // Start is called before the first frame update
    public void ChangeScene(string sceneName)
    {
        StartCoroutine(ChangeSceneCoroutine());
        IEnumerator ChangeSceneCoroutine() {
            imageFader.FadeToBlack();
            yield return new WaitForSeconds(imageFader.fadeTime);
            SceneManager.LoadScene(sceneName);
            yield return null;
        }
        
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
