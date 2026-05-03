using UnityEngine;
using System.Collections;

public class DeathPit : MonoBehaviour
{

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Health health = other.gameObject.GetComponent<Health>();
            health.LoseHealth();
        }
    }


}
