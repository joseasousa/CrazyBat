using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnControler : MonoBehaviour {

	public float maxHeigth;
	public float minHeigth;

	public float rateSpawn;
	private float currentRateSpawn;

	public GameObject tubePrefab;

	public int maxSpawnTubes;

	public List<GameObject>tubes;

	private GameControler gameControler;

	// Use this for initialization
	void Start () {

		for(int i=0; i<maxSpawnTubes; i++){
			GameObject tempTube = Instantiate(tubePrefab) as GameObject;
			tubes.Add(tempTube);
			tempTube.SetActive(false);
		}
		
		currentRateSpawn = rateSpawn;
		gameControler = FindObjectOfType(typeof(GameControler))as GameControler;       
	}
	
	// Update is called once per frame
	void Update () {
		if(gameControler.getCurentState() != GameStates.INGAME){
			return;
		}
		currentRateSpawn += Time.deltaTime;
		if(currentRateSpawn > rateSpawn){
			currentRateSpawn = 0;
			Spawn();
		}
	}

	private void Spawn(){
		float randHeight = Random.Range(minHeigth, maxHeigth);
		
		GameObject tempTube = null;
		
		for(int i=0; i<maxSpawnTubes; i++){
			if(tubes[i].activeSelf == false){
				tempTube = tubes[i];
				break;
			}
		}
		
		if(tempTube != null){
			tempTube.transform.position = new Vector3(transform.position.x, randHeight, transform.position.z);
			tempTube.SetActive(true);
		}

	}
}
