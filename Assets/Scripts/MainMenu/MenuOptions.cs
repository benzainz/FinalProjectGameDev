using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private Resolution[] resolutions;

    private void Start()
    {
        // Obtener las resoluciones disponibles en el sistema
        resolutions = Screen.resolutions;

        // Limpiar las opciones del dropdown de resoluciones
        resolutionDropdown.ClearOptions();

        // Crear una lista de opciones de resolución en formato "Ancho x Alto"
        List<string> resolutionOptions = new List<string>();

        int currentResolutionIndex = 0;

        // Recorrer las resoluciones disponibles y agregarlas como opciones al dropdown
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionOptions.Add(option);

            // Verificar si esta es la resolución actual y almacenar su índice
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Establecer las opciones del dropdown y seleccionar la resolución actual
        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Establecer el estado del toggle de pantalla completa/ventana
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        // Obtener la resolución seleccionada del dropdown
        Resolution resolution = resolutions[resolutionIndex];

        // Establecer la resolución del juego
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        // Establecer el modo de pantalla completa/ventana
        Screen.fullScreen = isFullscreen;
    }
}
