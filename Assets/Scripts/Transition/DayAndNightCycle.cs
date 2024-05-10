using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNightCycle : MonoBehaviour
{
    private Vector3 rot = Vector3.zero;
    private float degpersec = 0.5f;

    public bool isNight = false;

    private void Update()
    {
        rot.x = degpersec * Time.deltaTime;
        transform.Rotate(rot, Space.World);
        CheckTime();
    }

    private void CheckTime()
    {
        if (gameObject.transform.eulerAngles.x > 180)
        {
            isNight = true;
        } else if (gameObject.transform.eulerAngles.x > 0)
        {
            isNight = false;
        }
    }
}
