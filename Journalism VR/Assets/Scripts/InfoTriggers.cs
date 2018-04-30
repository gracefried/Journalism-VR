using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoTriggers : MonoBehaviour {

    public bool Cop;
    public bool protestA;
    public bool protestB;
    public bool injuredP;
    public bool politician;

    public bool canPass;
    public bool bottleActive;
    public bool bottleGiven;

    public bool scandal;
    public bool millpockets;
    public bool violence;
    public bool benefits;
    public bool taxes;

    bool check;
    public string headline;

    //public 


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        Cop = true; protestA = false; protestB = false; injuredP = false; politician = false;

        canPass = false; bottleActive = false; bottleGiven = false;

        scandal = false; millpockets = false; violence = false; benefits = false; taxes = false;
        check = false;
        headline = "";
	}
	
	// Update is called once per frame
	void Update () {
		//if(SceneManager.GetActiveScene().name == "HeadlineScene" && check == false) { getHeadlines(); }
	}

    public List<string> getHeadlines()
    {
        List<string> posHeadLine = new List<string>();
        if(Cop == true)
        {
            posHeadLine.Add("The Silence of Free Speech: Officers and Media Suppression");
            posHeadLine.Add("Violent Protest Leads to Police Intervention");
        }

        if (protestA == true)
        {
            posHeadLine.Add("Local Community Stands Against Amendment 41");
            posHeadLine.Add("Amendment 41: Your Money vs Their Comfort");
            posHeadLine.Add("We're All Running Out of Dough, 41 Has Got to Go!!");
        }

        if (protestB == true)
        {
            posHeadLine.Add("Local Community Stands With Amendment 41");
            posHeadLine.Add("Amendment 41: How Our Community Will Benefit");
            posHeadLine.Add("Love Us, Hate Us, but 41 Will Save Us!");
        }

        if (injuredP == true)
        {
            posHeadLine.Add("Local Protest Devolves into Violence");
        }

        if (politician == true)
        {
            posHeadLine.Add("Councilwoman Rallies Support for Amendment 41");
        }

        if (scandal == true)
        {
            posHeadLine.Add("Is the Councilwoman using the Amendment to Distract Us from her Scandal?");
        }

        if (millpockets == true)
        {
            posHeadLine.Add("Who's really benefitting from Amendment 41?");
        }

        posHeadLine.Add("Local Protest: Happens!");
        posHeadLine.Add("Conflict Over Amendment 41");

        check = true;
        return posHeadLine;
    }
}
