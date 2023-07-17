using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenToggle : MonoBehaviour
{


    public void FullScene(bool is_fullScene) {
        Screen.fullScreen = is_fullScene;
        Debug.Log("FullScreen is " + is_fullScene);
    }

}
