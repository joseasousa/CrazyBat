using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour
{

    private Material currentMaterial;
    public float speed;
    private float offset;
    GameController gameControler;

    void Start()
    {
        currentMaterial = GetComponent<Renderer>().material;
        gameControler = FindObjectOfType(typeof(GameController)) as GameController;
    }

    void Update()
    {
        if ((gameControler.getCurentState() != GameStates.INGAME && 
            gameControler.getCurentState() != GameStates.MENU &&
            gameControler.getCurentState() != GameStates.TUTORIAL)|| 
            Time.timeScale != 1)
            return;

        offset += 0.001f;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
    }
}
