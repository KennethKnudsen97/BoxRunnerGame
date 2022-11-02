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


    private void Start()
    {
        audio = audioObject.GetComponent<AudioSource>();
        slider.value = 1;
    }

    private void Update()
    {
        sliderValue.text = (slider.value * 100).ToString("0");
        audio.volume = slider.value;
    }



    public void buttonChanged(Toggle btn)
    {
        Debug.Log(btn.tag);
    }
}
