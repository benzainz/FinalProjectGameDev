using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    //se declara las variables , se reserva espacio en memoria. aqui regresa null sino se asigna la variable a un valor
    private Resolution[] resolutionsArray;
    private List<Resolution> filteredResolutionsList;

    private float currentRefreshRate;
    private int currentResolutionIndex = 0;


    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        //se crea la variable, se llena espacio en memoria
        resolutionsArray = Screen.resolutions;
        filteredResolutionsList = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;
        //add currentRefreshRate to the list
        for (int i = 0; i < resolutionsArray.Length; i++)
        {
            if (resolutionsArray[i].refreshRate == currentRefreshRate)
            {
                filteredResolutionsList.Add(resolutionsArray[i]);
            }
        }
        //pass filtered resolution to the dropdown

        List<string> options = new List<string>();

        for (int i =0; i < filteredResolutionsList.Count; i++)
        {
            string resolutionOption = filteredResolutionsList[i].width + "x" + filteredResolutionsList[i].height + " " + filteredResolutionsList[i].refreshRate + "Hz";
            options.Add(resolutionOption);
            if (filteredResolutionsList[i].width == Screen.width && filteredResolutionsList[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

   public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutionsList[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
}
