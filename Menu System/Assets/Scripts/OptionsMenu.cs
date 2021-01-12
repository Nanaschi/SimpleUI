using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class OptionsMenu : MonoBehaviour
{
    public Toggle fullscreenTog, vsyncTog; 
    public ResItem[] resolutions;
    public int selectedResolution;
    public Text resolutionLabel;
    public AudioMixer theMixer;
    public Slider mastSlider, musicSlider, sfxSlider;
    public Text mastLabel, musicLabel, sfxLabel;
    public AudioSource sfxLoop; 
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVol")){
            theMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
            mastSlider.value = PlayerPrefs.GetFloat("MasterVol");
           
        }
        if (PlayerPrefs.HasKey("MasterVol"))
        {
            theMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
            musicSlider.value = PlayerPrefs.GetFloat("MusicVol");
         
        }

        if (PlayerPrefs.HasKey("Vol"))
        {
            theMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVol");
        
        }
        mastLabel.text = (mastSlider.value + 80).ToString();
        musicLabel.text = (musicSlider.value + 80).ToString();
        sfxLabel.text = (sfxSlider.value + 80).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResLeft()
    {
        selectedResolution--;
        if (selectedResolution < 0)
        {
            selectedResolution = 0;
        }
    }
    public void ResRight()
    {
        selectedResolution++;
        if (selectedResolution > resolutions.Length-1)
        {
            selectedResolution = resolutions.Length - 1;
        }
        UpdateResLabel();
    }
    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }
  
    public void ApplyGraphics(){
//apply full screen
Screen.fullScreen = fullscreenTog.isOn;
if (vsyncTog.isOn){
    QualitySettings.vSyncCount = 1;
} else {
    QualitySettings.vSyncCount=0;
}
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenTog.isOn);
    }
    public void SetMasterVol()
    {
        mastLabel.text = (mastSlider.value + 80).ToString();
        theMixer.SetFloat("MasterVol", mastSlider.value);
        PlayerPrefs.SetFloat("MasterVol", mastSlider.value);
    }
    public void SetMusicVol()
    {
        musicLabel.text = (musicSlider.value + 80).ToString();
        theMixer.SetFloat("MusicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }
    public void SetSFXVol()
    {
        sfxLabel.text = (sfxSlider.value + 80).ToString();
        theMixer.SetFloat("SFXVol", sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
    public void PlaySFXLoop()
    {
        sfxLoop.Play(); 
    }
    public void StopSFXLoop()
    {
        sfxLoop.Stop();
    }
}
[System.Serializable] // makes it possible to actually see the resolutions in Unity 
public class ResItem
{
    public int horizontal, vertical;
}