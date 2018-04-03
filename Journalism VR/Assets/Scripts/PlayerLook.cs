using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity;
    public Camera mainCam;
    GameObject tablet;
    Transform OptionA;
    Transform OptionB;
    Transform OptionC;

    float xAxisClamp = 0.0f;
    float yAxisClamp = 0.0f;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        tablet = transform.parent.Find("TestTablet").gameObject;
        OptionA = tablet.transform.Find("OptionA");
        OptionB = tablet.transform.Find("OptionB");
        OptionC = tablet.transform.Find("OptionC");
    }

    void FixedUpdate()
    {
        RotateCamera();
        //raycaster();
        if (Input.GetKey("escape")) { Application.Quit(); }
    }

    void raycaster()
    {
        Vector3 rayOrigin = mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, mainCam.transform.forward, out hit))
        {
            Debug.Log("Something hit: " + hit.collider.tag);

            /*if (hit.collider.tag == "OptionA") {
                OptionA.position = new Vector3(0.0f, OptionA.position.y, -2.0f);
                OptionA.localScale = new Vector3(1.5f, 1.5f, 1.0f);
                OptionA.gameObject.GetComponent<TextMesh>().color = new Vector4(0, 0, 0, 1);
                if (Input.GetButtonDown("Fire1")) { }
            }
            if (hit.collider.tag == "OptionB")
            {
                OptionB.position = new Vector3(0.0f, OptionB.position.y, -2.0f);
                OptionB.localScale = new Vector3(1.5f, 1.5f, 1.0f);
                OptionB.gameObject.GetComponent<TextMesh>().color = new Vector4(0, 0, 0, 1);
                if (Input.GetButtonDown("Fire1")) { }
            }
            if (hit.collider.tag == "OptionC")
            {
                OptionC.position = new Vector3(0.0f, OptionC.position.y, -2.0f);
                OptionC.localScale = new Vector3(1.5f, 1.5f, 1.0f);
                OptionC.gameObject.GetComponent<TextMesh>().color = new Vector4(0, 0, 0, 1);
                if (Input.GetButtonDown("Fire1")) { }
            }
            else
            {
                OptionA.position = new Vector3(0.0f, OptionA.position.y, -1.0f);
                OptionA.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                OptionA.gameObject.GetComponent<TextMesh>().color = new Vector4(1, 1, 1, 1);

                OptionB.position = new Vector3(0.0f, OptionB.position.y, -1.0f);
                OptionB.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                OptionB.gameObject.GetComponent<TextMesh>().color = new Vector4(1, 1, 1, 1);

                OptionC.position = new Vector3(0.0f, OptionC.position.y, -1.0f);
                OptionC.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                OptionC.gameObject.GetComponent<TextMesh>().color = new Vector4(1, 1, 1, 1);

            }*/
        }
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountX2 = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        xAxisClamp -= rotAmountY;
        yAxisClamp -= rotAmountX;

        Vector3 targetRotCam = transform.rotation.eulerAngles;
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;

        targetRotCam.x -= rotAmountY;
        targetRotCam.z = 0;
        targetRotCam.y += rotAmountX;
        targetRotBody.y += rotAmountX;

        if(xAxisClamp > 90)
        {
            xAxisClamp = 90;
            targetRotCam.x = 90;
        }
        else if(xAxisClamp < -90)
        {
            xAxisClamp = -90;
            targetRotCam.x = 270;
        }

        if (yAxisClamp > 35)
        {
            yAxisClamp = 35;
            //targetRotCam.y = -45;
            playerBody.rotation = Quaternion.Euler(targetRotBody);
        }
        else if (yAxisClamp < -35)
        {
            yAxisClamp = -35;
            //targetRotCam.y = 45;
            playerBody.rotation = Quaternion.Euler(targetRotBody);
        }

        //print(mouseY);


        transform.rotation = Quaternion.Euler(targetRotCam);
        //playerBody.rotation = Quaternion.Euler(targetRotBody);


    }



}
