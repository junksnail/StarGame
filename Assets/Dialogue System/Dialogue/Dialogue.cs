using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Scriptable Objects/Dialogue")]
public class Dialogue : ScriptableObject
{
    [TextArea] public string npcDialogue;
    [TextArea] public string[] dialogue;
    public bool[] endConversation;
    public Dialogue[] nextTree;
    public Event[] events;
    public Item[] items;
}
