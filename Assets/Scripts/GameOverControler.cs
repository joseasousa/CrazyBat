using UnityEngine;
using System.Collections;

public class GameOverControler : MonoBehaviour {

	public TextMesh score;
	public TextMesh bestScore;
	public Renderer[] medals;

	public GameObject content;
	public GameObject title;

	void Start () {
		HideGameOver();
	}
	

	void Update () {
	
	}

	public void SetGameOver(int scoreIngame){

		if(scoreIngame>PlayerPrefs.GetInt("Score")){
			PlayerPrefs.SetInt("Score",scoreIngame);
		}

		score.text = scoreIngame.ToString();
		bestScore.text = PlayerPrefs.GetInt("Score").ToString();

		if(scoreIngame >50){
			medals[0].enabled = true;
		}else if(scoreIngame > 35 ){
			medals[1].enabled = true;
		}else if(scoreIngame > 25){
			medals[2].enabled = true;
		}else{
			medals[3].enabled = true;
		}
		content.SetActive(true);
		title.SetActive(true);
	}

	public void HideGameOver(){
		content.SetActive(false);
		title.SetActive(false);
		foreach(Renderer m in medals){
			m.enabled=false;
		}
	}
}
