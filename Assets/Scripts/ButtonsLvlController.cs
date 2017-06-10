using UnityEngine;
using System.Collections;

public class ButtonsLvlController : MonoBehaviour
{
    public MyButton closeButton;
    public MyButton backgroundButton;
    public MyButton musicButton;
    public MyButton soundButton;
    public Sprite musicOffSprite;
    public Sprite musicOnSprite;
    public Sprite soundOffSprite;
    public Sprite soundOnSprite;
    public GameObject soundBtnObj;
    public GameObject musicBtnObj;
    void Start()
    {
       
        closeButton.signalOnClick.AddListener(this.onClose);
        backgroundButton.signalOnClick.AddListener(this.onClose);
         musicButton.signalOnClick.AddListener(this.onMusic);
        soundButton.signalOnClick.AddListener(this.onSound);
     
    }
    void onClose()
    {
        GameObject h;
        h = GameObject.Find("settingsPopUp");
        Destroy(h);
    }
    void onMusic()
    {
       bool current= SoundManager.Instance.isMusicOn();
        
        SoundManager.Instance.setMusicOn(!current);
        if (current)

            musicBtnObj.GetComponent<UI2DSprite>().sprite2D = musicOnSprite;
        else
            musicBtnObj.GetComponent<UI2DSprite>().sprite2D = musicOffSprite;
    }
    void onSound()
    {

        bool current = SoundManager.Instance.isSoundOn();

        SoundManager.Instance.setSoundOn(!current);
        if (current)

            soundBtnObj.GetComponent<UI2DSprite>().sprite2D = soundOnSprite;
        else
            soundBtnObj.GetComponent<UI2DSprite>().sprite2D = soundOffSprite;
    }
    void onPause()
    {

    }
}
