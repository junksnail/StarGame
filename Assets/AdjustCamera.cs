using UnityEngine;

public class AdjustCamera : MonoBehaviour
{
    public float speed;
    public Quaternion target;
    public Quaternion current;
    public Quaternion reset;

    GameObject camArm;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CameraArm")
        {
            
                camArm = other.gameObject;
            
            current = target;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "CameraArm")
        {
            current = reset;
        }
    }

    void FixedUpdate()
    {
        if (camArm != null)
        {
            float singleStep = speed * Time.deltaTime;
            camArm.transform.rotation = Quaternion.RotateTowards(camArm.transform.rotation, current, singleStep);

        }
    }
}
