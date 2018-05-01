using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionControllerPoliti : MonoBehaviour
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
                LoadBranch4();
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
                LoadBranch6();
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
		transform.Find ("PoliticianD1").GetComponent<AudioSource> ().Play ();
        talk = "And I assure you, Amendment 41 will help change our community under my watch!";
        OptionA = "What is your stance?";
        OptionB = "Why is this issue important to you?";
        OptionC = "Why is there so much security and police involvement?";
        branch = 1;
    }

    public void LoadBranch2()
    {
        delay = 2;
		transform.Find ("PoliticianD2").GetComponent<AudioSource> ().Play ();
        talk = "I am in firm support of Amendment 41!";
        OptionA = "What do you have to gain from this bill?";
        OptionB = "Is the security necessary?";
        OptionC = "Thank you for your time.";
        branch = 2;
    }

    public void LoadBranch3()
    {
        delay = 2;
		transform.Find ("PoliticianD3").GetComponent<AudioSource> ().Play ();
        talk = "I made a promise as your councilwoman to improve the lives of all citizens, and this Amendment will offer benefits that will uplift so many of our friends and neighbors! ";
        OptionA = "Thank you for your time.";
        OptionB = "Is the security necessary?";
        OptionC = "Do you gain anything from this bill?";
        branch = 3;
    }

    public void LoadBranch4()
    {
        delay = 2;
		transform.Find ("PoliticianD4").GetComponent<AudioSource> ().Play ();
        talk = "It’s simply a matter of security. Tensions have flared over the Amendment and our dedicated protectors are here to make sure that everyone has a safe time. ";
        OptionA = "Thank you for your time.";
        OptionB = "Do you think the bill might be too polarizing?";
        OptionC = "Is this service really necessary?";
        branch = 4;
    }

    public void LoadBranch5()
    {
        delay = 2;
		transform.Find ("PoliticianD5").GetComponent<AudioSource> ().Play ();
        talk = "Thank you for your time, and remember to vote YES on Ammendment 41 in the coming election!";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = 5;
    }

    public void LoadBranch6()
    {
        delay = 2;
		transform.Find ("PoliticianD6").GetComponent<AudioSource> ().Play ();
        talk = "No more questions, please. There are others I need to attend to.";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = 6;
    }

    public void LoadBranchB1()
    {
        delay = 2;
		transform.Find ("PoliticianD8").GetComponent<AudioSource> ().Play ();
        talk = "All I have to gain from this bill is the contentment in seeing this city flourish! My financially matters are not of concern right now.";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = -1;
    }

    public void LoadBranchB2()
    {
        delay = 2;
		transform.Find ("PoliticianD7").GetComponent<AudioSource> ().Play ();
        talk = "My personal matters are not the subject of the evening. We’re here today to stand in support of this great Amendment, and I would appreciate if questions were limited to that subject.";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = -2;
    }
}
