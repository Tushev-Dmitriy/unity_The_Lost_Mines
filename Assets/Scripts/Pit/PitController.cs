using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitController : MonoBehaviour
{
    public bool canUse = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canUse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canUse = false;
        }
    }
}
