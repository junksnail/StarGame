using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] EnemyTracking enemyTracking;


    bool canDamage;

    void Start()
    {
        canDamage = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && canDamage == true)
        {
            Health health = other.gameObject.GetComponent<Health>();
            health.LoseHealth();
            enemyTracking.ResetCoroutine();
            canDamage = false;
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.5f);
        canDamage = true;
        yield return null;
    }
}
