using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        Cop = false; protestA = false; protestB = false; injuredP = false; politician = false;

        canPass = false; bottleActive = false; bottleGiven = false;

        scandal = false; millpockets = false; violence = false; benefits = false; taxes = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
