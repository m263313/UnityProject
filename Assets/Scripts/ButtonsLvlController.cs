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
        Time.timeScale = 1f;
    }
    void onMusic()
    {
       bool current= SoundManager.Instance.isMusicOn();
        
        SoundManager.Instance.setMusicOn(!current);
        if (!current)
        {
            musicBtnObj.GetComponent<UIButton>().disabledSprite2D = musicOnSprite;
            musicBtnObj.GetComponent<UIButton>().hoverSprite2D = musicOnSprite;
            musicBtnObj.GetComponent<UIButton>().normalSprite2D = musicOnSprite;
            musicBtnObj.GetComponent<UIButton>().pressedSprite2D = musicOnSprite;
        }
        else
        {
            
            musicBtnObj.GetComponent<UIButton>().disabledSprite2D = musicOffSprite;
            musicBtnObj.GetComponent<UIButton>().hoverSprite2D = musicOffSprite;
            musicBtnObj.GetComponent<UIButton>().normalSprite2D = musicOffSprite;
            musicBtnObj.GetComponent<UIButton>().pressedSprite2D = musicOffSprite;

        }
        }

    void onSound()
    {

        bool current = SoundManager.Instance.isSoundOn();
        SoundManager s = SoundManager.Instance;
        SoundManager.Instance.setSoundOn(!current);
        if (!current)
        {
            soundBtnObj.GetComponent<UIButton>().disabledSprite2D = soundOnSprite;
            soundBtnObj.GetComponent<UIButton>().hoverSprite2D = soundOnSprite;
            soundBtnObj.GetComponent<UIButton>().normalSprite2D = soundOnSprite;
            soundBtnObj.GetComponent<UIButton>().pressedSprite2D = soundOnSprite;
        }
        else
        {
            soundBtnObj.GetComponent<UIButton>().disabledSprite2D = soundOffSprite;
            soundBtnObj.GetComponent<UIButton>().hoverSprite2D = soundOffSprite;
            soundBtnObj.GetComponent<UIButton>().normalSprite2D = soundOffSprite;
            soundBtnObj.GetComponent<UIButton>().pressedSprite2D = soundOffSprite;
            
        }
    }
    void onPause()
    {

    }
}
