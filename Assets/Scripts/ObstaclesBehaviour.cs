using UnityEngine;
using System.Collections;

public class ObstaclesBehaviour : MonoBehaviour
{

    public float speed;

    private GameController gameControler;

    private bool passed;

    // Use this for initialization
    void Start()
    {
        gameControler = FindObjectOfType(typeof(GameController)) as GameController;
    }

    void OnEnable()
    {
        passed = false;
    }

    void Update()
    {
        if (gameControler.getCurentState() != GameStates.INGAME)
        {
            return;
        }

        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

        if (transform.position.x < -13)
        {
            gameObject.SetActive(false);
        }
        if (transform.position.x < gameControler.player.position.x && !passed)
        {
            passed = true;
            gameControler.addScore();
        }
    }

}
