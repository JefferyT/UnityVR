using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raycasting : MonoBehaviour
{
    public GameObject cam;
    public Image pointer;
    float timeElapsed;

    public Transform DoorEnterPos;
    public Transform TVPos;
    public Transform BathRoomPos;
    public GameObject TVScreen;
    public GameObject Shower;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        reticle();
    }

    void reticle()
    {
        RaycastHit hit;
        Vector3 forward = cam.transform.TransformDirection(Vector3.forward * 1000);
        if (Physics.Raycast(cam.transform.position, forward, out hit))
        {
            if (hit.transform.tag == "Door")
            {
                pointer.fillAmount = timeElapsed / 3;
                timeElapsed = timeElapsed + Time.deltaTime;
                if (timeElapsed >= 3)
                {
                    StartCoroutine(moveToPosition());
                    timeElapsed = 3;
                    Debug.Log("DoorHIT");
                }
            }

            else if (hit.transform.tag == "TV")
            {
                pointer.fillAmount = timeElapsed / 3;
                timeElapsed = timeElapsed + Time.deltaTime;

                if (timeElapsed >= 3)
                {
                    StartCoroutine(moveToTV());
                    TVScreen.SetActive(true);
                    timeElapsed = 3;
                }
                
            }

            else if (hit.transform.tag == "BathRoom")
            {
                pointer.fillAmount = timeElapsed / 3;
                timeElapsed = timeElapsed + Time.deltaTime;

                if (timeElapsed >= 3)
                {
                    StartCoroutine(moveToBathRoom());
                    timeElapsed = 3;
                }

            }

            else if (hit.transform.tag == "Tap")
            {
                pointer.fillAmount = timeElapsed / 3;
                timeElapsed = timeElapsed + Time.deltaTime;

                if (timeElapsed >= 3)
                {
                    Shower.SetActive(true);
                    timeElapsed = 3;
                }

            }

            else
            {
                pointer.fillAmount = timeElapsed / 3;
                timeElapsed = timeElapsed - Time.deltaTime;
                if (timeElapsed <= 0)
                {
                    timeElapsed = 0;
                }
            }
        }

        Debug.DrawRay(cam.transform.position, forward, Color.red);
    }
    IEnumerator moveToPosition()
    {
        while (transform.position != DoorEnterPos.position)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, DoorEnterPos.position, Time.deltaTime);

            yield return null;
        }
    }
    IEnumerator moveToTV()
    {
        while (transform.position != TVPos.position)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, TVPos.position, Time.deltaTime);

            yield return null;
        }
    }
    IEnumerator moveToBathRoom()
    {
        while (transform.position != BathRoomPos.position)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, BathRoomPos.position, Time.deltaTime);

            yield return null;
        }
    }

}