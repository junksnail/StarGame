using UnityEngine;

public class CameraDirection : MonoBehaviour
{
    public Transform player; // Assign the player's transform in the Inspector
    public float smoothSpeed;

    void Update()
    {
        if (player != null)
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion playerRotation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);

            transform.rotation = Quaternion.Lerp(currentRotation, playerRotation, smoothSpeed * Time.deltaTime);

            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}

