using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionControllerCop : MonoBehaviour
{

    public string talk;
    public string OptionA;
    public string OptionB;
    public string OptionC;
    public int branch;
    TextMesh NPCText;
    public float delay;

    // Use this for initialization
    void Start()
    {
        /*OptionA = "Option A";
        OptionB = "Option B";
        OptionC = "Option C";*/
        NPCText = transform.parent.Find("NPCText").gameObject.GetComponent<TextMesh>();
        branch = 1;
        delay = 0;
        //NPCText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //NPCText.text = talk;
        if (delay > 0) {delay -= Time.deltaTime;}
        //if(branch == 1){LoadBranch1();}
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
                LoadBranch5();
                break;
            case 3:
                LoadBranch5();
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
		transform.Find ("CopD1").GetComponent<AudioSource> ().Play ();
        talk = "This is a restricted area";
        OptionA = "I am a reporter";
        OptionB = "This is public property";
        OptionC = "What is happening here?";
        branch = 1;
        FindObjectOfType<InfoTriggers>().Cop = true;
    }

    public void LoadBranch2(){
        delay = 2;
		transform.Find ("CopD2").GetComponent<AudioSource> ().Play ();
        talk = "Show me your credentials";
        OptionA = "Present credentials";
        OptionB = "Refuse";
        OptionC = "Why?";
        branch = 2;
    }

    public void LoadBranch3()
    {
        delay = 2;
		transform.Find ("CopD3").GetComponent<AudioSource> ().Play ();
        talk = "No, This Area is Off-Limits";
        OptionA = "Try to stop me";
        OptionB = "Where's your supervisor";
        OptionC = "I just want to know what's going on";
        branch = 3;
    }

    public void LoadBranch4()
    {
        delay = 2;
		transform.Find ("CopD4").GetComponent<AudioSource> ().Play ();
        talk = "We sectioned off this zone to keep the sides in line. Only people with clearance are allowed past this point. Show me your credentials";
        OptionA = "Present credentials";
        OptionB = "Refuse";
        OptionC = "Why?";
        branch = 4;
    }

    public void LoadBranch5()
    {
        delay = 2;
		transform.Find ("CopD5").GetComponent<AudioSource> ().Play ();
        talk = "If you’re not going to cooperate don’t waste my time. Move along now.";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = 5;
    }

    public void LoadBranch6()
    {
        delay = 2;
		transform.Find ("CopD6").GetComponent<AudioSource> ().Play ();
        talk = "Your credentials check out, I’ll let you through.";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = 6;
        FindObjectOfType<InfoTriggers>().canPass = true;
    }

    public void LoadBranchB1()
    {
        delay = 2;
		transform.Find ("CopD7").GetComponent<AudioSource> ().Play ();
        talk = "What? Where? Thanks for the tip, we’ll get help there. Everybody, clear out! ";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = -1;
    }
}
