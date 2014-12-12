using UnityEngine;
using System.Collections;

public class ObstaclesBehaviour : MonoBehaviour {

	public float speed;

	private GameControler gameControler;

	private bool passed;

	// Use this for initialization
	void Start () {
		gameControler = FindObjectOfType(typeof(GameControler))as GameControler;   
	}	

	void OnEnable(){
		passed=false;
	}
	// Update is called once per frame
	void Update () {
		if(gameControler.getCurentState() != GameStates.INGAME)
			return;
		
		transform.position += new Vector3(speed,0,0)*Time.deltaTime;
		if(transform.position.x < -18){
			gameObject.SetActive (true);
		}
		if(transform.position.x < gameControler.player.position.x && !passed){
			passed = true;
			gameControler.addScore();
		}
	}

}
