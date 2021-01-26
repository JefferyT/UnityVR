using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Interactions : MonoBehaviour
{
    public GameObject CabinetOpenMessage;
    public GameObject Cabinet;
    public bool isCabinet;

    public GameObject Cabinet2OpenMessage;
    public GameObject Cabinet2;
    bool isCabinet2;
    bool isGetkey;

    public GameObject CorpseDrawerMessage;
    public GameObject CorpseDrawerMessage2;
    public GameObject CorpseDrawer;
    bool isCorpseDrawer;
    bool isCardkey;

    public GameObject FinalDoorMessage;
    public GameObject FinalDoorMessage2;
    public GameObject FinalDoor;
    bool isFinalDoor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire0")==true)
        {
            if (isCabinet)
            {
                CabinetOpenMessage.SetActive(true);
                Cabinet.GetComponent<Animator>().SetBool("isOpen", true);
            }
            else if (isCabinet2)
            {
                Cabinet2OpenMessage.SetActive(true);
                Cabinet2.GetComponent<Animator>().SetBool("isOpen", true);
                isGetkey = true;
            }
            else if (isCorpseDrawer)
            {
                if (isGetkey)
                {
                    CorpseDrawer.GetComponent<Animator>().SetBool("isOpen", true);
                    CorpseDrawerMessage.SetActive(true);
                    isCardkey = true;
                }
                else
                {
                    CorpseDrawerMessage2.SetActive(true);
                }
            }
            else if (FinalDoor)
            {
                if (isCardkey)
                {
                    FinalDoor.GetComponent<Animator>().SetBool("isOpen", true);
                    FinalDoorMessage.SetActive(true);
                }
                else
                {
                    FinalDoorMessage2.SetActive(true);
                }
            }
        }

        if (CrossPlatformInputManager.GetButtonDown("Fire2") == true)
        {
            CabinetOpenMessage.SetActive(false);
            Cabinet.GetComponent<Animator>().SetBool("isOpen", false);

            Cabinet2OpenMessage.SetActive(false);
            Cabinet2.GetComponent<Animator>().SetBool("isOpen", false);

            CorpseDrawerMessage.SetActive(false);
            CorpseDrawerMessage2.SetActive(false);

            FinalDoorMessage.SetActive(false);
            FinalDoorMessage2.SetActive(false);
        }

    }

    public void CabinetOpen()
    {
        isCabinet = true;
    }

    public void CabinetClose()
    {
        isCabinet = false;
    }
    public void Cabinet2Open()
    {
        isCabinet2 = true;
    }

    public void Cabinet2Close()
    {
        isCabinet2 = false;
    }
    public void DrawerOpen()
    {
        isCorpseDrawer = true;
    }
    public void DrawerClose()
    {
        isCorpseDrawer = false;
    }
    public void FinalDoorOpen()
    {
        isFinalDoor = true;
    }
    public void FinalDoorClose()
    {
        isFinalDoor = false;
    }
}
