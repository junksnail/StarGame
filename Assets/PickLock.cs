using UnityEngine;

public class PickLock : MonoBehaviour
{

    float innerRotation;
    float middleRotation;
    float outerRotation;

    float goalInnerRotation;
    float goalMiddleRotation;
    float goalOuterRotation;

    bool innerGoalReached;
    bool middleGoalReached;
    bool outerGoalReached;

    public GameObject innerRing;
    public GameObject middleRing;
    public GameObject outerRing;

    bool completed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed)
        {
            if (innerRotation == goalInnerRotation)
            {
                innerGoalReached = true;
            }
            if (middleRotation == goalMiddleRotation)
            {
                middleGoalReached = true;
            }
            if (outerRotation == goalOuterRotation)
            {
                outerGoalReached = true;
            }

            if (innerGoalReached && middleGoalReached && outerGoalReached)
            {
                completed = true;
            }
        }
    }
}
