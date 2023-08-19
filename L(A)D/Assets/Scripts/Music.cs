using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource music;

    private void Start()
    {
        music = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!PlayerPrefs.HasKey("Volume"))
            PlayerPrefs.SetFloat("Volume", 1);
        else
            music.volume = PlayerPrefs.GetFloat("Volume");
    }
}
