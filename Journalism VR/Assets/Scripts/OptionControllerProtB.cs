using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionControllerProtB : MonoBehaviour
{

    public string talk;
    public string OptionA;
    public string OptionB;
    public string OptionC;
    public int branch;
    TextMesh NPCText;
    float delay;

    // Use this for initialization
    void Start()
    {
        /*OptionA = "Option A";
        OptionB = "Option B";
        OptionC = "Option C";*/
        NPCText = transform.parent.Find("NPCText").gameObject.GetComponent<TextMesh>();
        branch = 0;
        delay = 0;
        NPCText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        NPCText.text = talk;
        if (delay > 0) {delay -= Time.deltaTime;}
    }

    public void choiceA()
    {
        //delay = 2;
        switch (branch)
        {
            case 1:
                LoadBranch2();
                break;
            case 2:
                LoadBranch4();
                break;
            case 3:
                LoadBranch5();
                break;
            case 4:
                LoadBranch5();
                break;
        }
    }

    public void choiceB()
    {
        //delay = 2;
        switch (branch)
        {
            case 1:
                LoadBranch3();
                break;
            case 2:
                LoadBranch3();
                break;
            case 3:
                LoadBranch6();
                break;
            case 4:
                LoadBranch6();
                break;
        }

    }

    public void choiceC()
    {
        //delay = 2;
        switch (branch)
        {
            case 1:
                LoadBranch4();
                break;
            case 2:
                LoadBranch5();
                break;
            case 3:
                LoadBranch4();
                break;
            case 4:
                LoadBranch6();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            NPCText.gameObject.SetActive(true);
            //branch = 0;
            LoadBranch1();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject tablet = other.transform.Find("Tablet").gameObject;
            tablet.transform.Find("OptionA").GetComponent<TextMesh>().text = OptionA;
            tablet.transform.Find("OptionB").GetComponent<TextMesh>().text = OptionB;
            tablet.transform.Find("OptionC").GetComponent<TextMesh>().text = OptionC;
            if (Input.GetKeyDown("z") && delay <= 0) { choiceA(); }
            if (Input.GetKeyDown("x") && delay <= 0) { choiceB(); }
            if (Input.GetKeyDown("c") && delay <= 0) { choiceC(); }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            branch = 0;
            NPCText.gameObject.SetActive(false);
            delay = 0;
        }
    }

    public void LoadBranch1()
    {
        delay = 2;
		transform.Find ("ProtestBD1").GetComponent<AudioSource> ().Play ();
        talk = "Vote for Amendment 41!!!";
        OptionA = "Why are you here?";
        OptionB = "Why is this issue important to you?";
        OptionC = "Is there anything you would change?";
        branch = 1;
    }

    public void LoadBranch2()
    {
        delay = 2;
		transform.Find ("ProtestBD2").GetComponent<AudioSource> ().Play ();
        talk = "I came out here to support Amendment 41!";
        OptionA = "Would you change it in any way?";
        OptionB = "Why is this important to you?";
        OptionC = "Thank you for your time.";
        branch = 2;
    }

    public void LoadBranch3()
    {
        delay = 2;
		transform.Find ("ProtestBD3").GetComponent<AudioSource> ().Play ();
        talk = "The benefits that the Amendment offer will do so much to help my family! We need this!";
        OptionA = "Thank you for your time.";
        OptionB = "How much does your family make?";
        OptionC = "Is there anything you would change?";
        branch = 3;
    }

    public void LoadBranch4()
    {
        delay = 2;
		transform.Find ("ProtestBD4").GetComponent<AudioSource> ().Play ();
        talk = "If anything I would extend the benefits to help more families, but the tax increase is already so high that I wouldn’t risk that now.";
        OptionA = "Thank you for your time.";
        OptionB = "Don’t you think it’s selfish to put this strain on those who can’t benefit?";
        OptionC = "Is this service really necessary?";
        branch = 4;
    }

    public void LoadBranch5()
    {
        delay = 2;
		transform.Find ("ProtestBD5").GetComponent<AudioSource> ().Play ();
        talk = "Spread the word about the Amendment we need any vote we can!";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = 5;
    }

    public void LoadBranch6()
    {
        delay = 2;
		transform.Find ("ProtestBD6").GetComponent<AudioSource> ().Play ();
        talk = "I’m not comfortable with that question, I think we’re done talking here.";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = 6;
    }

    public void LoadBranchB1()
    {
        delay = 2;
		transform.Find ("ProtestBD7").GetComponent<AudioSource> ().Play ();
        talk = "She’s doing her best to raise awareness and support the Amendment! I have nothing but admiration for her.";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = -1;
    }

    public void LoadBranchB2()
    {
        delay = 2;
		transform.Find ("ProtestBD8").GetComponent<AudioSource> ().Play ();
        talk = "He was attacking a girl from across the barricade so we started throwing things at him. The poor girl looked pretty banged up before she left, I hope she’s ok.";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = -2;
    }

    public void LoadBranchB3()
    {
        delay = 2;
		transform.Find ("ProtestBD9").GetComponent<AudioSource> ().Play ();
        talk = "I can understand why they’re against it, but I just think it’s selfish to go against a program that’ll do so much for our community.";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = -3;
    }
}
