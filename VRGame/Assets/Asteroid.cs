using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject ExpObj;

    private void OnTriggerEnter(Collider other)
    {
        ExpObj.SetActive(true);
        transform.GetComponent<MeshRenderer>().enabled = false;
        Invoke("DestObj", 2);
    }

    void DestObj()
    {
        Destroy(this.gameObject);
    }
}
