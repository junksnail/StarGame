using UnityEngine;

public class CompleteQuest : MonoBehaviour
{
    [SerializeField] Quest completedQuest;

    bool completed; 

    public void Complete()
    {
        if (!completed)
        {
            if (QuestLog.instance.CompleteQuest(completedQuest) == true)
            {
                Debug.Log("Quest: " +  completedQuest.name + " completed");
                completed = true;
            }
            else
            {
                Debug.Log("Quest step of : " + completedQuest.name + " progressed");
            }
        }
    }
}
