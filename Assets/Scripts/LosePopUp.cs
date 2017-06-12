using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LosePopUp : MonoBehaviour
{
     
    public MyButton closeButton;
    public MyButton nextButton;
    public MyButton againButton;
    public MyButton backgroundButton;
    public GameObject crystalRed;
    public GameObject crystalGreen;
    public GameObject crystalBlue;
    
    void Start()
    {
        closeButton.signalOnClick.AddListener(this.onNext);
        backgroundButton.signalOnClick.AddListener(this.onNext);
        againButton.signalOnClick.AddListener(this.onAgain);
        nextButton.signalOnClick.AddListener(this.onNext);
        crystalRed.GetComponent<UI2DSprite>().sprite2D = CrystalController.current.redObj.sprite2D;
        crystalGreen.GetComponent<UI2DSprite>().sprite2D = CrystalController.current.greenObj.sprite2D;
        crystalBlue.GetComponent<UI2DSprite>().sprite2D = CrystalController.current.blueObj.sprite2D;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void onAgain()
    {

        Scene scene = SceneManager.GetActiveScene();
        Time.timeScale = 1f;
        print(scene.name);
        SceneManager.LoadScene(scene.name);
    }
    void onNext()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelChoice");

    }
}
