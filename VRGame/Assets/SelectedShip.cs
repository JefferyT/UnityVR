using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedShip : MonoBehaviour
{

    public GameObject ship01;
    public GameObject ship02;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("ShipType") == 1)
        {
            ship01.SetActive(true);
        }
        if (PlayerPrefs.GetInt("ShipType") == 2)
        {
            ship02.SetActive(true);
        }
    }
}
