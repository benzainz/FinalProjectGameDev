using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//singleton pattern class , pass one audioclip at a time
public class SFXHandler : MonoBehaviour
{
    public static SFXHandler singleton;

    void Awake()
    {
        if (singleton != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            singleton = this;
        }
    }

   public void PlaySound(AudioClip audioClip) {
        GetComponent<AudioSource>().PlayOneShot(audioClip);
    }
}
