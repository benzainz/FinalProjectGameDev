using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{

    public void OpenOptionMenu()
    {
        GetComponent<Canvas>().enabled = true;
    }


    public void CloseOptionMenu()
    {
        GetComponent<Canvas>().enabled = false;
    }

}
