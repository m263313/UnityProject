using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject settingsPrefab;
    public MyButton playButton ;
    public MyButton settingsButton;
    
    void Start()
    {
        if(playButton!=null)
        playButton.signalOnClick.AddListener(this.onPlay);
        settingsButton.signalOnClick.AddListener(this.onSettings);
    }
    void onPlay()
    {
        SceneManager.LoadScene("LevelChoice");
    }
    void onSettings()
    {
         
            //Знайти батьківський елемент
            GameObject parent = UICamera.first.transform.parent.gameObject;
            //Створити Prefab
            GameObject obj = NGUITools.AddChild(parent, settingsPrefab);
            
            
     
   



    }
}