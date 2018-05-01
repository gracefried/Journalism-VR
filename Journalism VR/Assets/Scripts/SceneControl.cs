using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {
    public string nextScene;
    public GameObject black;
    public float delay;
    bool end;

	// Use this for initialization
	void Start () {
        end = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(end == true) { delay -= Time.deltaTime; }
	}

    public void transition()
    {
        end = true;
        black.GetComponent<Animator>().SetTrigger("fade");
    }
}
