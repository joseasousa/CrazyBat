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
                    instance.audio.PlayOneShot(instance.soundFly);
                    break;
                }
            case soundsGame.THEME_ON:
                {
                    instance.audio.enabled=true;
                    instance.audio.loop=true;
                    instance.audio.Play();
                    break;
                }
            case soundsGame.THEME_OF:
                {
                    instance.audio.enabled = false;
                    instance.audio.loop = false;
                    instance.audio.Stop();
                    break;
                }
        }
    }

    void Start() { 
        instance = this;
    }
}
