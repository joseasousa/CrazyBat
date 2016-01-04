using UnityEngine;
using System.Collections;

public class PauseControler : MonoBehaviour
{

    public Texture2D pauseImage;
    public Texture2D playImage;

    private GameController gameControler;

    public float sizeButton;

    private bool isPaused;



    void Start()
    {
        gameControler = FindObjectOfType(typeof(GameController)) as GameController;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (gameControler.getCurentState() == GameStates.INGAME)
        {
            if (!isPaused)
            {
                if (GUI.Button(new Rect(0, 0, Screen.width/sizeButton, Screen.width/sizeButton), pauseImage,GUIStyle.none))
                {
                    isPaused = true;
                    Time.timeScale = 0;
                }
            }
            else
            {
				if (GUI.Button(new Rect(0, 0, Screen.width/sizeButton, Screen.width/sizeButton), playImage, GUIStyle.none))
                {
                    isPaused = false;
                    Time.timeScale = 1;
                }
            }
        }
    }

    public bool IsPaused() {
        return isPaused;
    } 
}
