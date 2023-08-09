using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
    Image image;
    public float fadeTime = 1;
   
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start() {
        image = GetComponent<Image>();
        FadeFromBlack();
        //FadeToBlack();


    }
    //StartCoroutine(FadeFromBlack());
    public void FadeFromBlack() {
        StartCoroutine(FadeFromBlackCoroutine());

        IEnumerator FadeFromBlackCoroutine()
        {
            float timer = 0;
            while (timer < fadeTime)
            {
                timer += Time.deltaTime;
                image.color = new Color(0, 0, 0, 1 - (timer / fadeTime));
                yield return null;
            }
            image.color = Color.clear;

            yield return null;
        }//IEnumerator
    }
    public void FadeToBlack()
    {
        StartCoroutine(FadeToBlackCoroutine());

        IEnumerator FadeToBlackCoroutine()
        {
            float timer = 0;
            while (timer < fadeTime)
            {
                timer += Time.deltaTime;
                image.color = new Color(0, 0, 0,(timer / fadeTime));
                yield return null;
            }
            image.color = Color.black;

            yield return null;
        }//IEnumerator
    }

}//class
