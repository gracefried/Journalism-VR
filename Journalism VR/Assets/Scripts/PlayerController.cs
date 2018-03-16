using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Animator anim;
    Animator audAnim;
    Animator bulAnim;
    GameObject clown;
    Animator clownAnim;
    int clownState;
    Camera mainCam;
    bool IsWalking;
    CharacterController charControl;
    public float walkSpeed;

    void Start()
    {
        anim = GetComponent<Animator>();
        //clown = GameObject.Find("Clown");
        //audAnim = GameObject.FindGameObjectWithTag("Audience").GetComponent<Animator>();
        //bulAnim = GameObject.FindGameObjectWithTag("Bully").GetComponent<Animator>();
        //clownAnim = clown.GetComponent<Animator>();
        mainCam = GetComponentInChildren<Camera>();
        //audAnim.SetInteger("Emotion", 1);
        //audAnim.SetBool("SitTime", true);
        charControl = GetComponent<CharacterController>();

    }

    void Update()
    {
        //clownState = clown.GetComponent<ClownBehavior>().currentState;
        MovePlayer();
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("click");
            Vector3 rayOrigin = mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, mainCam.transform.forward, out hit, 100f))
            {
                Debug.Log("Something hit: " + hit.collider.tag);
                /*if (hit.collider.tag == "Clap") { Clap(); }
                if (hit.collider.tag == "Boo") { Boo(); }
                if (hit.collider.tag == "Laugh") { Laugh(); }
                if (hit.collider.tag == "Wander") { Wander(); }*/
            }
        }
        if (Input.GetKey("escape")) { Application.Quit(); }
        /*
                if (Input.GetKey("up"))
                {
                    if (Time.timeScale != 0f) { Time.timeScale = 0f; }
                    if (Time.timeScale == 0f) { Time.timeScale = 1f; }
                }
                    if (Input.GetKey("down")) { SceneManager.LoadScene("MainScene"); }*/
    }
    /*
    void Clap()
    {
        anim.SetTrigger("Clap");
        Debug.Log("Clap");
        if (clownState == 3)
        {
            audAnim.SetInteger("Emotion", 1);
            bulAnim.SetTrigger("Lose");
            clownState = 5;

        }
    }

    void Boo()
    {
        anim.SetTrigger("Boo");
        if (clownState == 1 || clownState == 2) { audAnim.SetInteger("Emotion", 3); }
    }

    void Laugh()
    {
        anim.SetTrigger("Laugh");
        if (clownState == 1 || clownState == 2) { audAnim.SetInteger("Emotion", 2); }
    }

    void Wander()
    {
        anim.SetBool("IsWalking", !anim.GetBool("IsWalking"));
    }

    void Approach()
    {
        if (clownState < 5) { clownAnim.SetTrigger("Run"); }
    }*/

    void MovePlayer()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        //Vector3 moveDirSide = transform.right * horiz * walkSpeed;
        Vector3 moveDirForward = transform.forward * walkSpeed;

        //charControl.SimpleMove(moveDirSide);
        charControl.SimpleMove(moveDirForward);

    }
}

