using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadlineController : MonoBehaviour {
    public GameObject newsReport;
    public ShopScrollList getHeadline;
    public Text Headline;
    public ShopScrollList comments;
    public bool done;


	// Use this for initialization
	void Start () {
        newsReport.SetActive(false);
        done = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(done == true && Input.GetKeyDown("z")) { FindObjectOfType<SceneControl>().transition(); Debug.Log("Finished"); }
	}

    public void activateHeadline()
    {
        newsReport.SetActive(true);
        getHeadline.canUse = false;
        
        Headline.text = FindObjectOfType<InfoTriggers>().headline;
        comments.itemList = FindObjectOfType<InfoTriggers>().getComments();
        comments.RefreshDisplay();
        comments.canUse = true;
        done = true;
    }
}
