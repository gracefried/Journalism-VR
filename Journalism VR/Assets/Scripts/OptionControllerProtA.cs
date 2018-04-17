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
        if(branch == 0)
        {
            talk = "Say NO to Ammendment 41!!!";
            OptionA = "Why are you here?";
            OptionB = "Why is this issue important?";
            OptionC = "What do you want changed?";
        }
    }

    public void choiceA()
    {
        delay = 2;
        if (branch == 0) //Response: Hi
        {
            talk = "How are you?";
            OptionA = "Great!";
            OptionB = "Ok";
            OptionC = "Not good...";
            branch = 1;
        }
        else if (branch == 1) //Response: Great!
        {
            talk = "I'm glad to hear!";
            OptionA = "";
            OptionB = "";
            OptionC = "";
            branch = -1;
        }
        else if (branch == 2) //Response: Thank You!
        {
            talk = "You're Welcome!!";
            OptionA = "";
            OptionB = "";
            OptionC = "";
            branch = -1;
        }
    }

    public void choiceB()
    {
        delay = 2;
        if (branch == 0)//Response: Nice
        {
            talk = "Thank you?";
            OptionA = "";
            OptionB = "";
            OptionC = "";
            branch = -1;
        }
        else if (branch == 1) //Response: Ok
        {
            talk = "I'm sure it'll get better!";
            OptionA = "";
            OptionB = "";
            OptionC = "";
            branch = -1;
        }
        else if (branch == 2) //Response: You too!
        {
            talk = "Thank you!";
            OptionA = "";
            OptionB = "";
            OptionC = "";
            branch = -1;
        } 
    }

    public void choiceC()
    {
        delay = 2;
        if (branch == 0) //Response: Goodbye
        {
            talk = "Have a good one!";
            OptionA = "Thank you";
            OptionB = "You too";
            OptionC = "I won't";
            branch = 2;
        }
        else if (branch == 1) //Response: Not good!
        {
            talk = "Aw, keep your head up it gets better!";
            OptionA = "";
            OptionB = "";
            OptionC = "";
            branch = -1;
        }
        else if (branch == 2) //Response: I won't
        {
            talk = "Ok...?";
            OptionA = "";
            OptionB = "";
            OptionC = "";
            branch = -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            NPCText.gameObject.SetActive(true);
            branch = 0;
            delay = 0;
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

}
