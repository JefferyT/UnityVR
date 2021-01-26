using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleTest : MonoBehaviour
{
    public void pointerEnter()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void pointerExit()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
