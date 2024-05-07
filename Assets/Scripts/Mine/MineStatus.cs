using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineStatus : MonoBehaviour
{
    public enum Status { AVAILABALE, INACCESSIBLE, COLLAPSE, PART_DEPLETED, DEPLETED };
    public Status status = Status.AVAILABALE;

    public void SetStatus(Status newStatus)
    {
        status = newStatus;
    }

    public Status GetStatus()
    {
        return status;
    }
}
