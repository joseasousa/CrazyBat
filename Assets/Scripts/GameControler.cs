using UnityEngine;
using System.Collections;

public enum GameStates{
	START,
	WAITGAME,
	INGAME,
	GAMEOVER,
	RANKING
}

public class GameControler : MonoBehaviour {

	public Transform player;

	private Vector3 startPositionPlayer;
	 
	private GameStates currentState = GameStates.START;

	public TextMesh numberScore;
	public TextMesh shadowScore;

	private int score;


	void Start () {
		startPositionPlayer = player.position;	
	}


	void Update () {
		switch(currentState){
			 
			case(GameStates.START):{
				player.position = startPositionPlayer;	
				currentState = GameStates.WAITGAME;
				score = 0;
			}
			break;

			case(GameStates.WAITGAME):{
				player.position =startPositionPlayer;
			}
			break;

			case(GameStates.INGAME):{
				numberScore.text = score.ToString();
				shadowScore.text = score.ToString();
			}
			break;

			case(GameStates.GAMEOVER):{
				currentState = GameStates.RANKING; 
			}
			break;

			case(GameStates.RANKING):{
				player.position = startPositionPlayer;
			}
			break;		
		}	
	}

	public void StartGame(){
		currentState = GameStates.INGAME;
		numberScore.renderer.enabled=true;
		shadowScore.renderer.enabled=true;
	}

	public GameStates getCurentState(){
		return currentState;
	}

	public void GameOver(){
		currentState=GameStates.GAMEOVER;
		RestartGame();
	}

	private void RestartGame(){
		player.position =startPositionPlayer;

		ObstaclesBehaviour[] pipes =FindObjectsOfType(typeof(ObstaclesBehaviour))as ObstaclesBehaviour[];
		foreach(ObstaclesBehaviour o in pipes){
			o.gameObject.SetActive( false);
		}
	}

	public void addScore(){
		score++;
	}
}
