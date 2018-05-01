using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {
    public string nextScene;
    public GameObject black;
    public float delay;
    public float gameTimer;
    bool end;

	// Use this for initialization
	void Start () {
        end = false;
        gameTimer = 120;
	}
	
	// Update is called once per frame
	void Update () {
		if(end == true) { delay -= Time.deltaTime; }
        if(SceneManager.GetActiveScene().name == "Start") { if (Input.anyKeyDown) { transition(); } }
        if (SceneManager.GetActiveScene().name == "End") { if (Input.anyKeyDown) { Application.Quit(); } }
        if(SceneManager.GetActiveScene().name == "ProtestScene1")
        {
            if(gameTimer > 0) { gameTimer -= Time.deltaTime; }
            else { transition(); }
        }
        if(delay <= 0){SceneManager.LoadScene(nextScene);}
    }

    public void transition()
    {
        end = true;
        black.GetComponent<Animator>().SetTrigger("fade");
        Debug.Log("end");
    }
}
