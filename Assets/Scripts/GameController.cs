using UnityEngine;
using System.Collections;

public enum GameStates
{
    START,
    WAITGAME,
    INGAME,
    GAMEOVER,
    RANKING,
    MENU,
    TUTORIAL
}

public class GameController : MonoBehaviour
{
    public Transform player;

    private Vector3 startPositionPlayer;

    private GameStates currentState = GameStates.START;

    public TextMesh numberScore;
    public TextMesh shadowScore;

    private float currentTimeToREstart;
    public float timetoRestart;

    private int score;

    private GameOverControler gameOverController;

    public GameObject mainMenu;

    public GameObject mainTutorial;

    private bool playSond;

    private int countProp;
    

    void Start()
    {
        startPositionPlayer = player.position;
        gameOverController = FindObjectOfType(typeof(GameOverControler)) as GameOverControler;
        
        playSond = true;
        countProp = 0;   
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        switch (currentState)
        {
            case (GameStates.START):
                {
                    player.position = startPositionPlayer;
                    currentState = GameStates.WAITGAME;
                    score = 0;
                    mainMenu.SetActive(true);
                    player.gameObject.SetActive(false);
                }
                break;

            case (GameStates.WAITGAME):
                {
                    player.position = startPositionPlayer;
                }
                break;

            case (GameStates.INGAME):
                {
                    numberScore.text = score.ToString();
                    shadowScore.text = score.ToString();
                    if (playSond) {
                        playSond = false;
                        SoundController.PlaySound(soundsGame.THEME_ON);
                    }
                }
                break;

            case (GameStates.GAMEOVER):
                {                   
                    currentTimeToREstart += Time.deltaTime;
                    if (currentTimeToREstart > timetoRestart)
                    {
                        currentTimeToREstart = 0;
                        currentState = GameStates.RANKING;
                        numberScore.GetComponent<Renderer>().enabled = false;
                        shadowScore.GetComponent<Renderer>().enabled = false;
                        numberScore.text = score.ToString();
                        shadowScore.text = score.ToString();
                        gameOverController.SetGameOver(score);
                        SoundController.PlaySound(soundsGame.THEME_OF);
                        playSond = true;
                        RestartGame();
                    }

                }
                break;

            case (GameStates.MENU):
                {
                    player.position = startPositionPlayer;
                    mainMenu.SetActive(true);

                }
                break;

            case (GameStates.TUTORIAL):
                {
                    player.position = startPositionPlayer;
                }
                break;

            case (GameStates.RANKING):
                {
                    player.position = startPositionPlayer;
                    numberScore.GetComponent<Renderer>().enabled = false;
                    shadowScore.GetComponent<Renderer>().enabled = false;
                }
                break;
        }
    }

    public void StartGame()
    {
        currentState = GameStates.INGAME;
        numberScore.GetComponent<Renderer>().enabled = true;
        shadowScore.GetComponent<Renderer>().enabled = true;
        score = 0;
        gameOverController.HideGameOver();
        mainTutorial.SetActive(false);
    }

    public GameStates getCurentState()
    {
        return currentState;
    }

    public void CallGameOver()
    {
        currentState = GameStates.GAMEOVER;
        countProp++;
        
    }

    public void CallTutorial()
    {
        player.gameObject.SetActive(true);
        currentState = GameStates.TUTORIAL;
        mainMenu.SetActive(false);
        mainTutorial.SetActive(true);
    }

    public void CallMenu()
    {
        mainMenu.SetActive(true);
        mainTutorial.SetActive(false);
        player.gameObject.SetActive(false);
        gameOverController.HideGameOver();
    }

    public void RestartGame()
    {
        player.position = startPositionPlayer;

        ObstaclesBehaviour[] obstacles = FindObjectsOfType(typeof(ObstaclesBehaviour)) as ObstaclesBehaviour[];

        foreach (ObstaclesBehaviour o in obstacles)
        {
            o.gameObject.SetActive(false);
        }
    }

    public void addScore()
    {
        score++;
    }
}