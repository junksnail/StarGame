using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Scriptable Objects/Quest")]
public class Quest : ScriptableObject
{
    public string qname;
    public string description;
    public int numberOfSteps;
    public int stepsCompleted = 0;

    public void Complete()
    {
         
    }
}
