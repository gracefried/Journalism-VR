using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionControllerProtA : MonoBehaviour
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
        talk = "Down with Amendment 41!!!";
        OptionA = "Why are you here?";
        OptionB = "Why is this issue important to you?";
        OptionC = "What do you want to see changed?";
        branch = 1;
    }

    public void LoadBranch2()
    {
        delay = 2;
        talk = "I’m here to protest Amendment 41";
        OptionA = "What’s wrong with the Amendment?";
        OptionB = "Why is this important to you?";
        OptionC = "Thank you for your time.";
        branch = 2;
    }

    public void LoadBranch3()
    {
        delay = 2;
        talk = "My family is struggling as is, the last thing I need is these money grubbing politicians taking more of our hard earned money!";
        OptionA = "Thank you for your time.";
        OptionB = "How much does your family make?";
        OptionC = "What would you change about it?";
        branch = 3;
    }

    public void LoadBranch4()
    {
        delay = 2;
        talk = "They either need to make the service worth something or stop trying to raise my taxes. I’ve worked too hard for my money!";
        OptionA = "Thank you for your time.";
        OptionB = "Do you see the other side’s point of view?";
        OptionC = "Shouldn’t you think about others?";
        branch = 4;
    }

    public void LoadBranch5()
    {
        delay = 2;
        talk = "Make sure everyone knows our city isn’t gonna sit by why these politicians milk us dry!";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = 5;
    }

    public void LoadBranch6()
    {
        delay = 2;
        talk = "That’s a rude question to ask, how about you find someone else to bother";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = 6;
    }

    public void LoadBranchB1()
    {
        delay = 2;
        talk = "She’s just saving face to rally her supporters and get eyes off her scandal. At the end of the day she’s just in it for the cash.";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = -1;
    }

    public void LoadBranchB2()
    {
        delay = 2;
        talk = "Not really, there was some struggle earlier but it was just one guy who ended up getting smacked. Not sure what happened, but I feel like he deserved it.";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = -2;
    }

    public void LoadBranchB3()
    {
        delay = 2;
        talk = "They’re just looking for charity. They don’t give a damn about the people who actually work for their money.";
        OptionA = "";
        OptionB = "";
        OptionC = "";
        branch = -3;
    }
}
