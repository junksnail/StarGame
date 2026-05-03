using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField] Transform spawnPos;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Health health = other.gameObject.GetComponent<Health>();
            health.SetSpawn(spawnPos);
        }
    }
}
