using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public MyButton playButton ;
    public MyButton settingsButton;
    void Start()
    {
        playButton.signalOnClick.AddListener(this.onPlay);
    }
    void onPlay()
    {
        SceneManager.LoadScene("LevelChoice");
    }
}