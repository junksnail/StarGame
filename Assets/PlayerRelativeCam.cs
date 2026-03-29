using UnityEngine;

public class PlayerRelativeCam : MonoBehaviour
{

    public Transform player; // Assign the player's transform in the Inspector

    void Update()
    {
        if (player != null)
        {
            // Make the object look at the player
            transform.LookAt(player);
        }
    }
}
