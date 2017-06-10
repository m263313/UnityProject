using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinPopUp : MonoBehaviour
{
    public GameObject winPopUpPrefab;
   public MyButton closeButton;
    public MyButton nextButton;
    public MyButton againButton;
    public MyButton backgroundButton;
    
    void Start()
    {
        closeButton.signalOnClick.AddListener(this.onNext);
        backgroundButton.signalOnClick.AddListener(this.onNext);
        againButton.signalOnClick.AddListener(this.onAgain);
        nextButton.signalOnClick.AddListener(this.onNext);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void onAgain()
    {
        
        Scene scene = SceneManager.GetActiveScene();
        print(scene.name);
        SceneManager.LoadScene(scene.name);
    }
    void onNext()
    {
       
        SceneManager.LoadScene("LevelChoice");
        
    }
}
