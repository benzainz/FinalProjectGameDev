using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
   
    public Transform bar;

    public void ChangeStatusBar(float life)
    {
        // life = Mathf.Clamp(life, 0, 1);
        if (life > 1) life = 1;
        else if (life < 0) life = 0;

        bar.transform.localScale = new Vector3(life, 1, 1);


    }


}
