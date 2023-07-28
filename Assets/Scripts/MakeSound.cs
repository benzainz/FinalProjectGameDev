using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSound : MonoBehaviour
{
    public AudioClip audioClip;
  
    public void PlaySound()
    {
        SFXHandler.singleton.PlaySound(audioClip);
    }

}
