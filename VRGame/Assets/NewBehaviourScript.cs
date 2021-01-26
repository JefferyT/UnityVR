using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Head;
    public GameObject Cam;
    public GameObject Spaceship;

    float CurrRot;
    float PrevRot;
    float DeltRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Head.transform.Translate(Cam.transform.forward * Time.deltaTime*5f);
        Tilt();
    }

    void Tilt()
    {
        CurrRot = Cam.transform.eulerAngles.y;
        DeltRot = CurrRot - PrevRot;
        PrevRot = CurrRot;

        if(DeltRot > 0)
        {
            Spaceship.transform.localRotation = Quaternion.Lerp(Spaceship.transform.localRotation,
            Quaternion.Euler(Spaceship.transform.localRotation.x, Spaceship.transform.localRotation.y, -45),
            Time.deltaTime
            );
        }

        if (DeltRot < 0)
        {
            Spaceship.transform.localRotation = Quaternion.Lerp(Spaceship.transform.localRotation,
            Quaternion.Euler(Spaceship.transform.localRotation.x, Spaceship.transform.localRotation.y, 45),
            Time.deltaTime
            );
        }

        if (DeltRot == 0)
        {
            Spaceship.transform.localRotation = Quaternion.Lerp(Spaceship.transform.localRotation,
            Quaternion.Euler(Spaceship.transform.localRotation.x, Spaceship.transform.localRotation.y, 0),
            Time.deltaTime
            );
        }
    }
}
