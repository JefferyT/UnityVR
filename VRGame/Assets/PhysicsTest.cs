using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CollisionEnter");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("CollisionExit");
    }
}
