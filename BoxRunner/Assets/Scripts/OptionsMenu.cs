using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider slider;
    public Text sliderValue;

    private new AudioSource audio;
    public GameObject audioObject;

    private Options options;

    private float oldVolume;

    private void Start()
    {
        audio = audioObject.GetComponent<AudioSource>();
        slider.value = 0.1f;
        oldVolume = 0;
        options = new Options();
    }

    private void Update()
    {
        sliderValue.text = (slider.value * 100).ToString("0");
        audio.volume = slider.value;
        
        if (options.volume != audio.volume)
        {
            options.volume = audio.volume;
            SaveOptions();
        }
    }

    public void SaveOptions()
    {
        FileManager<Options>.WriteToFile(Application.dataPath + "/options.txt", options);
    }
}

[System.Serializable]
public class Options
{
    public float volume;

    public Options()
    {
        volume = 0.1f;
    }
}