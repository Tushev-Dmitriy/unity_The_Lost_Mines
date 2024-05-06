using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    private float posY = 2.3f; 
    private float posZ = -1.82f; 
    private float rotX = 22f;

    void Update()
    {
        Vector3 forward = target.forward.normalized;
        Vector3 targetPosition = target.position - forward * posY - Vector3.up * posZ;
        transform.position = targetPosition;
        transform.LookAt(target);
        transform.rotation = Quaternion.Euler(rotX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
