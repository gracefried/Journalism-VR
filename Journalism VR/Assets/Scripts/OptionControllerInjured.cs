using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionControllerInjured : MonoBehaviour
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
                LoadBranch6();
                break;
            case 3:
                LoadBranch2();
                break;
            case 5:
                LoadBranch8();
                break;
            case 7:
                LoadBranch3();
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
                LoadBranch5();
                break;
            case 3:
                LoadBranch5();
                break;
            case 5:
                LoadBranch4();
                break;
            case 7:
                LoadBranch4();
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
                LoadBranch8();
                break;
            case 3:
                LoadBranch4();
                break;
            case 5:
                LoadBranch2();
                break;
            case 7:
                LoadBranch8();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            NPCText.gameObject.SetActive(true);
            LoadBranch1();
            //delay = 0;
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
		transform.Find ("InjuredD1").GetComponent<AudioSource> ().Play ();
        talk = "Ugh, my head";
        OptionA = "Do you need help?";
        OptionB = "What happened to you?";
        OptionC = "Why are you here?";
        branch = 1;
    }

    public void LoadBranch2()
    {
        delay = 2;
		transform.Find ("InjuredD2").GetComponent<AudioSource> ().Play ();
        talk = "I should be alright, just need some water or something";
        OptionA = "Wait here I’ll get you a bottle";
        OptionB = "What happened?";
        OptionC = "Do you want me to contact the authorities?";
        branch = 2;
    }



    public void LoadBranch3()
    {
        delay = 2;
		transform.Find ("InjuredD3").GetComponent<AudioSource> ().Play ();
        talk = "I got hit with a bottle that was thrown about 20 minutes ago";
        OptionA = "Do you need help?";
        OptionB = "Do you know who threw the bottle?";
        OptionC = "Why are you here?";
        branch = 3;
    }

    public void LoadBranch4()
    {
        delay = 2;
		transform.Find ("InjuredD4").GetComponent<AudioSource> ().Play ();
        talk = "I came out to protest that bogus amendment! Amendment 41 is just a scam to line millionaire pockets. We can’t let that thing pass or people like me are gonna end up suffering for it!";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = 4;
    }

    public void LoadBranch5()
    {
        delay = 2;
		transform.Find ("InjuredD5").GetComponent<AudioSource> ().Play ();
        talk = "It was some loser from the other side, I didn’t see who";
        OptionA = "Do you want me to contact authorities?";
        OptionB = "Why are you here?";
        OptionC = "Do you need help?";
        branch = 5;
    }

    public void LoadBranch6()
    {
        delay = 2;
		transform.Find ("InjuredD6").GetComponent<AudioSource> ().Play ();
        talk = "Be careful out there, don’t end up like me";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = 6;
    }

    public void LoadBranch7()
    {
        delay = 2;
		transform.Find ("InjuredD7").GetComponent<AudioSource> ().Play ();
        talk = "Thanks man, at least there are some decent people out here";
        OptionA = "What happened to you?";
        OptionB = "Why are you here?";
        OptionC = "Do you want me to get help?";
        branch = 7;
    }

    public void LoadBranch8()
    {
        delay = 2;
		transform.Find ("InjuredD8").GetComponent<AudioSource> ().Play ();
        talk = "Yeah, that’d be great, thanks";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = 8;
    }

    public void LoadBranchB1()
    {
        delay = 2;
		transform.Find ("InjuredD9").GetComponent<AudioSource> ().Play ();
        talk = "She’s some snooty jerk just looking to make bank, don’t believe a word she says!";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = -1;
    }

    public void LoadBranchB2()
    {
        delay = 2;
		transform.Find ("InjuredD10").GetComponent<AudioSource> ().Play ();
        talk = "So what? Those losers were getting too uppity and their stupid Amendment is gonna do nothing but make things worse! Sure I pulled some chick’s hair but she didn’t get a bottle to the face!";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = -2;
    }

}
