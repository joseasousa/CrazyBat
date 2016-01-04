using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour
{

    public Transform mesh;
    public float forceFly;
    private Animator animatorPlayer;

    private float timeToAnime;
    private bool inAnin;

    private GameController gameControler;

    private PauseControler pauseControler;

    void Start()
    {
        animatorPlayer = mesh.GetComponent<Animator>();
        gameControler = FindObjectOfType(typeof(GameController)) as GameController;
        pauseControler = FindObjectOfType(typeof(PauseControler)) as PauseControler;
        inAnin = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameControler.getCurentState() == GameStates.INGAME
            && gameControler.getCurentState() != GameStates.GAMEOVER && !pauseControler.IsPaused())
        {
            animatorPlayer.SetBool("CallFly", true);
            inAnin = true;
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(new Vector2(0, 1) * forceFly);

            SoundController.PlaySound(soundsGame.FLY);
        }
        else if (Input.GetMouseButtonDown(0) && gameControler.getCurentState() == GameStates.TUTORIAL)
        {
            Restart();
        }

        animatorPlayer.SetBool("CallFly", inAnin);


        Vector3 curentPosition = transform.position;
        if (curentPosition.y > 5)
        {
            curentPosition.y = 5;
            transform.position = curentPosition;
        }
        if (gameControler.getCurentState() != GameStates.INGAME &&
           gameControler.getCurentState() != GameStates.GAMEOVER)
        {
            rigidbody2D.gravityScale = 0;
            return;
        }
        else
        {
            rigidbody2D.gravityScale = 1;
        }

        if (inAnin && gameControler.getCurentState() != GameStates.TUTORIAL)
        {
            timeToAnime += Time.deltaTime;
            if (timeToAnime > 0.4f)
            {
                timeToAnime = 0;
                inAnin = false;
            }
        }
        animatorPlayer.SetBool("CallFly", inAnin);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        gameControler.CallGameOver();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        gameControler.CallGameOver();
    }

    public void Restart()
    {
        if (gameControler.getCurentState() != GameStates.GAMEOVER)
        {
            gameControler.RestartGame();
            gameControler.StartGame();
        }
    }
}
