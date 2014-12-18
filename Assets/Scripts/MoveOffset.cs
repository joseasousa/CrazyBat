using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour
{

    private Material currentMaterial;
    public float speed;
    private float offset;
    GameControler gameControler;

    void Start()
    {
        currentMaterial = renderer.material;
        gameControler = FindObjectOfType(typeof(GameControler)) as GameControler;
    }

    void Update()
    {
        if (gameControler.getCurentState() != GameStates.INGAME && 
            gameControler.getCurentState() != GameStates.MENU &&
            gameControler.getCurentState() != GameStates.TUTORIAL)
            return;

        offset += 0.001f;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
    }
}
