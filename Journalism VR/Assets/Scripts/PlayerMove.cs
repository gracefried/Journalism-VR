using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{
    CharacterController charControl;
    public float walkSpeed;
    GameObject tablet;
    TextMesh OptionA;
    TextMesh OptionB;
    TextMesh OptionC;
    GameObject NPCText;
    Camera mainCam;

    void Awake()
    {
        charControl = GetComponent<CharacterController>();
        tablet = transform.Find("Tablet").gameObject;
        OptionA = tablet.transform.Find("OptionA").GetComponent<TextMesh>();
        OptionB = tablet.transform.Find("OptionB").GetComponent<TextMesh>();
        OptionC = tablet.transform.Find("OptionC").GetComponent<TextMesh>();
        OptionA.text = ""; OptionB.text = ""; OptionC.text = "";
        mainCam = transform.Find("Main Camera").GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        MovePlayer();
        Vector3 rayOrigin = mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, mainCam.transform.forward, out hit, 100f))
        {
            Debug.Log("Something hit: " + hit.collider.tag);
        }
    }

    void MovePlayer()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 moveDirSide = transform.right * horiz * walkSpeed;
        Vector3 moveDirForward = transform.forward * vert * walkSpeed;

        charControl.SimpleMove(moveDirSide);
        charControl.SimpleMove(moveDirForward);

    }
/*
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Trigger");
        if (other.tag == "NPC")
        {
            other.gameObject.GetComponent<OptionController>().branch = 0;
            OptionA.text = other.gameObject.GetComponent<OptionController>().OptionA;
            OptionB.text = other.gameObject.GetComponent<OptionController>().OptionB;
            OptionC.text = other.gameObject.GetComponent<OptionController>().OptionC;
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "NPC")
        {
            OptionController OC = other.gameObject.GetComponent<OptionController>();
            if (Input.GetKeyDown("z")) { OC.choiceA(); }
            if (Input.GetKeyDown("x")) { OC.choiceB(); Debug.Log("Option B picked"); }
            if (Input.GetKeyDown("c")) { OC.choiceC(); }
            OptionA.text = other.gameObject.GetComponent<OptionController>().OptionA;
            OptionB.text = other.gameObject.GetComponent<OptionController>().OptionB;
            OptionC.text = other.gameObject.GetComponent<OptionController>().OptionC;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            Debug.Log("Exited Trigger");
            OptionA.text = "";
            OptionB.text = "";
            OptionC.text = "";
            other.gameObject.GetComponent<OptionController>().branch = 0;
        }
    }*/
}
