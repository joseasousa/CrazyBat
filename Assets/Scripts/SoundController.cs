using UnityEngine;
using System.Collections;

public enum soundsGame
{
    FLY,
    THEME_ON,
    THEME_OF
}

public class SoundController : MonoBehaviour
{
    public AudioClip soundFly;
    public AudioSource soundTheme;

    public static SoundController instance;
    
    public static void PlaySound(soundsGame currentSound)
    {
        switch (currentSound)
        {
            case soundsGame.FLY:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundFly);
                    break;
                }
            case soundsGame.THEME_ON:
                {
                    instance.GetComponent<AudioSource>().enabled=true;
                    instance.GetComponent<AudioSource>().loop=true;
                    instance.GetComponent<AudioSource>().Play();
                    break;
                }
            case soundsGame.THEME_OF:
                {
                    instance.GetComponent<AudioSource>().enabled = false;
                    instance.GetComponent<AudioSource>().loop = false;
                    instance.GetComponent<AudioSource>().Stop();
                    break;
                }
        }
    }

    void Start() { 
        instance = this;
    }
}
