using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController charControl;
    public float walkSpeed;
    GameObject tablet;
    TextMesh OptionA;
    TextMesh OptionB;
    TextMesh OptionC;

    void Awake()
    {
        charControl = GetComponent<CharacterController>();
        tablet = transform.Find("TestTablet").gameObject;
        OptionA = tablet.transform.Find("OptionA").GetComponent<TextMesh>();
        OptionB = tablet.transform.Find("OptionB").GetComponent<TextMesh>();
        OptionC = tablet.transform.Find("OptionC").GetComponent<TextMesh>();
        OptionA.text = ""; OptionB.text = ""; OptionC.text = "";
    }

    void Update()
    {
        MovePlayer();
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Trigger");
        if (other.tag == "NPC")
        {
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
        }
    }
}
