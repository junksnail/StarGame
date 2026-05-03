using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class QuestLog : MonoBehaviour
{
    public static QuestLog instance;

    public List<Quest> QuestList = new List<Quest> ();


    void Awake()
    {
        instance = this;
    }

    public bool CompleteQuest(Quest questObject)
    {
        for (int i = 0; i < QuestList.Count; i++)
        {
            if (QuestList[i] == questObject)
            {
                questObject.stepsCompleted++;
                Debug.Log(questObject.name + ": Quest Step " + questObject.numberOfSteps + " completed");
                if (questObject.stepsCompleted >= questObject.numberOfSteps)
                {
                    QuestList[i].Complete();
                    QuestList.RemoveAt(i);
                    return true;
                }
                else { return false; }
            }
        }
        return false;
    }

    public void AcceptQuest(Quest questObject)
    {
        QuestList.Add(questObject);
    }
}
