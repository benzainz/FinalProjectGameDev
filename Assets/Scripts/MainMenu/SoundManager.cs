//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;
//using UnityEngine;

//public class SoundManager : MonoBehaviour
//{
//    [SerializeField] Slider volumeSlider;
//    // Start is called before the first frame update
//    void Start()
//    {
//        if (!PlayerPrefs.HasKey("musicVolume")) {

//            PlayerPrefs.SetFloat("musicVolume", 1);
//            Load();
//        }
//        else
//        {
//            Load();

//        }
//    }

//    public void ChangeVolume()
//    {
//        AudioListener.volume = volumeSlider.value;
//        Save();

//    }

//    private void Load()
//    {
//        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
//    }

//    private void Save()
//    {
//        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
//    }

//}//class
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider soundEffectsSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {

            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();

        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();

    }

    public void ChangeSoundEffectsVolume()
    {
        // Cambiar el volumen de los efectos de sonido
        // AudioListener.volume se utiliza para el volumen maestro, pero aquí necesitamos controlar solo los efectos de sonido.
        // Puedes usar el componente de Audio de Unity específico para los efectos de sonido.
        // Aquí, simplemente usaremos un valor entre 0 y 1, donde 0 es sin sonido y 1 es el volumen máximo.
        float soundEffectsVolume = soundEffectsSlider.value;
        // Asignar el volumen a los efectos de sonido aquí (utiliza el componente de Audio correspondiente).
        // Por ejemplo:
        // audioSourceSoundEffects.volume = soundEffectsVolume;

        // Guardar el valor del volumen de los efectos de sonido
        PlayerPrefs.SetFloat("soundEffectsVolume", soundEffectsVolume);
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        soundEffectsSlider.value = PlayerPrefs.GetFloat("soundEffectsVolume", 1f);
    }


    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        PlayerPrefs.SetFloat("soundEffectsVolume", soundEffectsSlider.value);
    }


}//class
