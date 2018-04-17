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
            talk = "This is a restricted area";
            OptionA = "I am a reporter";
            OptionB = "This is public property";
            OptionC = "What is happening here?";
        }
    }

    public void choiceA()
    {
        delay = 2;
        if (branch == 0) //Response: I am a reporter
        {
            talk = "Show me your credentials";
            OptionA = "Present credentials";
            OptionB = "Refuse";
            OptionC = "Why?";
            branch = 1;
        }
        else if (branch == 1) //Response: Show me your credentials
        {
            talk = "Your credentials check out, I’ll let you through.";
            OptionA = "";
            OptionB = "";
            OptionC = "";
            branch = -1;
        }
        else if (branch == 2) //Response: Thank You!
        {
            talk = "If you’re not going to cooperate don’t waste my time. Get out of here!";
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
            talk = "No, This Area is Off-Limits";
            OptionA = "Try to stop me";
            OptionB = "Where's your supervisor";
            OptionC = "I just want to know what's going on";
            branch = 2;
        }
        else if (branch == 1) //Response: Ok
        {
            talk = "If you’re not going to cooperate don’t waste my time. Get out of here!";
            OptionA = "";
            OptionB = "";
            OptionC = "";
            branch = -1;
        }
        else if (branch == 2) //Response: You too!
        {
            talk = "If you’re not going to cooperate don’t waste my time. Get out of here!";
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
            talk = "It’s a protest over Amendment 41, we sectioned off this zone to keep the sides in line. Only people with clearance are allowed past this point. Now keep moving.";
            OptionA = "";
            OptionB = "";
            OptionC = "";
            branch = -1;
        }
        else if (branch == 1) //Response: Not good!
        {
            talk = "If you’re not going to cooperate don’t waste my time. Get out of here!";
            OptionA = "";
            OptionB = "";
            OptionC = "";
            branch = -1;
        }
        else if (branch == 2) //Response: I won't
        {
            talk = "It’s a protest over Amendment 41, we sectioned off this zone to keep the sides in line. Only people with clearance are allowed past this point. Now keep moving.";
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
