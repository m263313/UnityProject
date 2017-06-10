using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioClip music = null;
    AudioSource musicSource = null;
    bool is_sound_on = true;
    bool is_music_on = true;
     void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.Play();
            is_sound_on = PlayerPrefs.GetInt("sound", 1) == 1;
        Instance = this;
    }
    void Update()
    {
       
    }
    public bool isSoundOn()
    {
        return this.is_sound_on;
    }
    public void setSoundOn(bool val)
    {
        this.is_sound_on = val;
        if (!is_sound_on)
            musicSource.Pause();
        else
        {
            musicSource.UnPause();
        }
        //  PlayerPrefs.SetInt("sound", this.is_sound_on ? 1 : 0);
        // PlayerPrefs.Save();
    }
    public bool isMusicOn()
    {
        return this.is_music_on;
    }
    public void setMusicOn(bool val)
    {
        this.is_music_on = val;
        if (!is_music_on)
            musicSource.Pause();
        else
        {
            musicSource.UnPause();
        }
        //   PlayerPrefs.SetInt("music", this.is_music_on ? 1 : 0);
        //   PlayerPrefs.Save();
    }
    SoundManager()
    {
        //is_sound_on = PlayerPrefs.GetInt("sound", 1) == 1;
    }
       public static SoundManager Instance ;
  //  public static SoundManager Instance = gameObject.AddComponent<SoundManager>(); 
}
