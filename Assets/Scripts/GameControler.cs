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

public class GameControler : MonoBehaviour
{
    public Transform player;

    private Vector3 startPositionPlayer;

    private GameStates currentState = GameStates.START;

    public TextMesh numberScore;
    public TextMesh shadowScore;

    private float currentTimeToREstart;
    public float timetoRestart;

    private int score;

    private GameOverControler gameOverControler;

    public GameObject mainMenu;

    public GameObject mainTutorial;

    void Start()
    {
        startPositionPlayer = player.position;
        gameOverControler = FindObjectOfType(typeof(GameOverControler)) as GameOverControler;
    }


    void Update()
    {
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
                }
                break;

            case (GameStates.GAMEOVER):
                {
                    currentTimeToREstart += Time.deltaTime;
                    if (currentTimeToREstart > timetoRestart)
                    {
                        currentTimeToREstart = 0;
                        currentState = GameStates.RANKING;
                        numberScore.renderer.enabled = false;
                        shadowScore.renderer.enabled = false;
                        numberScore.text = score.ToString();
                        shadowScore.text = score.ToString();
                        gameOverControler.SetGameOver(score);
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
                    numberScore.renderer.enabled = false;
                    shadowScore.renderer.enabled = false;
                }
                break;
        }
    }

    public void StartGame()
    {
        
        currentState = GameStates.INGAME;
        numberScore.renderer.enabled = true;
        shadowScore.renderer.enabled = true;
        score = 0;
        gameOverControler.HideGameOver();
    }

    public GameStates getCurentState()
    {
        return currentState;
    }

    public void CallGameOver()
    {
        currentState = GameStates.GAMEOVER;
    }

    public void CallTutorial()
    {
        player.gameObject.SetActive(true);
        currentState = GameStates.TUTORIAL;
        mainMenu.SetActive(false);
        mainTutorial.SetActive(true);
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