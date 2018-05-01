using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletTimer : MonoBehaviour {
    float gameTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameTime = FindObjectOfType<SceneControl>().gameTimer;
        if (gameTime > 0) { transform.GetComponent<TextMesh>().text = FindObjectOfType<SceneControl>().gameTimer.ToString(); }
        else { transform.GetComponent<TextMesh>().text = "Time's Up!"; }
	}
}
