using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_Manager : MonoBehaviour
{
    // Singleton instance
    public static Audio_Manager Instance;
    public AudioMixer Audio_Mixer;
    [SerializeField]
    public AudioSource sfxSource;



    private void Awake()
    {
        // Asegura que solo haya una instancia del AudioManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

      
    }
    //llamamos a este audio cuando sea true en teoria cuando el personaje toca la moneda
    public void PlaySFX(AudioClip clip)
    {
        
        if (clip == true)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}