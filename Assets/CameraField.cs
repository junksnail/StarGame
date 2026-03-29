using UnityEngine;

public class CameraField : MonoBehaviour
{
    [SerializeField] GameObject cameraRoot;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject cameraPos;
    [SerializeField] int cameraID;
    [SerializeField] int managerID;
    [SerializeField] int speed;

    Vector3 targetPos;

    bool occupied;
    public bool lerping;
    GameObject playerRef;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && cameraRoot != null)
        {
            playerRef = other.gameObject;
            managerID = CameraManager.instance.staticCameraID;

            if (!occupied && cameraID != managerID)
            {
                CameraManager.instance.staticCameraID = cameraID;
                CameraManager.instance.didChange = true;

                occupied = true;
                targetPos = cameraPos.transform.position;

                lerping = true;
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && cameraRoot != null)
        {
            occupied = false;
            managerID = CameraManager.instance.staticCameraID;
            lerping = false;
        }
    }

    void Update()
    {
        if (lerping)
        {
            
            cameraRoot.transform.position = Vector3.Lerp(cameraRoot.transform.position, targetPos, speed * Time.deltaTime);
            if (cameraRoot.transform.position == targetPos)
            {
                lerping = false;
            }
        }
    }
}

