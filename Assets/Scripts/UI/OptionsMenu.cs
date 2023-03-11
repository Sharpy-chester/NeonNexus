using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMP_Dropdown resolutionDropdown, graphicsDropdown;
    [SerializeField] Toggle fullscreenToggle;
    
    Resolution[] resolutions;

    void Start()
    {
        InitResolutions();
        InitQuality();
        InitFullscreen();
    }

    void Update()
    {
        
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ToggleFullscreen(bool isFullscreen)
    {
        fullscreenToggle.isOn = isFullscreen;
        Screen.fullScreenMode = isFullscreen ? FullScreenMode.MaximizedWindow : FullScreenMode.Windowed;
        Screen.fullScreen = isFullscreen;
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    void InitFullscreen()
    {
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    void InitQuality()
    {
        graphicsDropdown.ClearOptions();
        graphicsDropdown.AddOptions(QualitySettings.names.ToList());
        graphicsDropdown.value = QualitySettings.GetQualityLevel();
        graphicsDropdown.RefreshShownValue();
    }
    
    void InitResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
}
