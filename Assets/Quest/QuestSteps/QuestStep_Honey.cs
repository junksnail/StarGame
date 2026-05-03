using UnityEngine;

public class QuestStep_Honey : CompleteQuest
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Complete();
            gameObject.SetActive(false);
        }
    }
}
