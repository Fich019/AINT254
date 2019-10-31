using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Soundmanager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer m_audioMixer;

    [SerializeField]
    private AudioMixerSnapshot m_gameMode;

    [SerializeField]
    private AudioMixerSnapshot m_menuMode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicVolume(float volume)
    {
        m_audioMixer.SetFloat("AmbianceVol", volume);
    }

    public void SetMusicVolume(Slider slider)
    {
        m_audioMixer.SetFloat("AmbianceVol", slider.value);
    }

    public void GameModeOn()
    {
        m_gameMode.TransitionTo(0.3f);
    }

    public void MenuModeOn()
    {
        m_menuMode.TransitionTo(0.3f);
    }
}
