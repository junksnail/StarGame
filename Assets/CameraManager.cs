using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public int staticCameraID;
    public bool didChange;

    void Awake()
    {
        instance = this;
    }
}
