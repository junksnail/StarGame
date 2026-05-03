using UnityEngine;
using System.Collections;

public class EnemyTracking : MonoBehaviour
{
    bool playerInsideField;
    GameObject player; 
    bool movingTowards;
    Vector3 spawnPoint;
    public float speed;
    

    void Start()
    {

        spawnPoint = transform.position;
        player = GameObject.FindWithTag("Player");
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInsideField = true;
        }
    }

    void CheckForDistance()
    {
        if (playerInsideField)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            movingTowards = true;
            if (dist > 9)
            {
                movingTowards = false;
                playerInsideField = false;
            }
        }
    }

    void Update()
    {
        CheckForDistance();
    }

    void FixedUpdate()
    {
        Moving();
    }

    void Moving()
    {
        if (!movingTowards)
        {
            if (transform.position != spawnPoint)
            {
                transform.position = Vector3.MoveTowards(transform.position, spawnPoint, speed * Time.deltaTime);
                if (spawnPoint.x < transform.position.x)
                {
                    gameObject.transform.localScale = new Vector3(-6.8425f, 6.8425f, 6.8425f);
                }
                if (spawnPoint.x > transform.position.x)
                {
                    gameObject.transform.localScale = new Vector3(6.8425f, 6.8425f, 6.8425f);
                }
            }
        }
        if (movingTowards)
        {
            
            if (player.transform.position.x < transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(-6.8425f, 6.8425f, 6.8425f);
            }
            if (player.transform.position.x > transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(6.8425f, 6.8425f, 6.8425f);
            }
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public void ResetCoroutine()
    {
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.3f);
        transform.position = spawnPoint;
        yield return null;
    }
}
