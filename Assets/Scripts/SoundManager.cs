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
        //Instance = new SoundManager();  
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = music;
        musicSource.loop = true;
      //  musicSource.Play();

        is_sound_on = PlayerPrefs.GetInt("sound", 1) == 1;
        is_music_on= PlayerPrefs.GetInt("music", 1) == 1;
       if(is_sound_on)
            musicSource.Play();
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
        if(val)
         PlayerPrefs.SetInt("sound", 1) ;
        else
            PlayerPrefs.SetInt("sound",0);
        if (!is_sound_on)
            musicSource.Pause();
        else
        {
            musicSource.Play();
        }
        //  PlayerPrefs.SetInt("sound", this.is_sound_on ? 1 : 0);
             PlayerPrefs.Save();
    }
    public bool isMusicOn()
    {
        return this.is_music_on;
    }
    public void setMusicOn(bool val)
    {
        if (val)
            PlayerPrefs.SetInt("music", 1);
        else
            PlayerPrefs.SetInt("music", 0);
        this.is_music_on = val;
       
        //   PlayerPrefs.SetInt("music", this.is_music_on ? 1 : 0);
         PlayerPrefs.Save();
    }
    SoundManager()
    {
        //is_sound_on = PlayerPrefs.GetInt("sound", 1) == 1;
    }
       public static SoundManager Instance ;
  //  public static SoundManager Instance = gameObject.AddComponent<SoundManager>(); 
}
