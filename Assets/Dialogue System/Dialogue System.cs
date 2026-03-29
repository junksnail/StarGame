using UnityEngine;
using System.Collections;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] string npcName;

    int currentLine;
    [SerializeField] Dialogue NPCDialogue;
    [SerializeField] GameObject canvas;

    Dialogue startingDialogue;

    [SerializeField] TMPAnimatedTextAdvanced npcTextField;
    [SerializeField] TMP_Text npcNameField;
    [SerializeField] TMPAnimatedTextAdvanced playerTextField;

    [SerializeField] TMPAnimatedTextAdvanced option1;
    [SerializeField] TMPAnimatedTextAdvanced option2;
    [SerializeField] TMPAnimatedTextAdvanced option3;
    [SerializeField] TMPAnimatedTextAdvanced option4;

    [SerializeField] Inventory inventory;
    [SerializeField] EventHandler eventSystem;


    ChatField cf;

    bool inputAllowed = true;

    [SerializeField] Animator animator;

    void Start()
    {
        cf = GetComponent<ChatField>();
        startingDialogue = NPCDialogue;
        npcNameField.text = npcName;
    }

    void OnEnable()
    {
        canvas.SetActive(true);
        playerTextField.SourceText = "";
        StartCoroutine(UpdateUI());
        Refresh();

    }

    void Update()
    {
        if (Input.GetKeyDown("1") && inputAllowed)
        {
            StopCoroutine(UpdateUI());
            inputAllowed = false;
            Refresh();
            int choice = 0;
            SayNextLine(choice);
        }
        if (Input.GetKeyDown("2") && inputAllowed)
        {
            StopCoroutine(UpdateUI());
            inputAllowed = false;
            Refresh();
            int choice = 1;
            SayNextLine(choice);
        }
        if (Input.GetKeyDown("3") && inputAllowed)
        {
            StopCoroutine(UpdateUI());
            inputAllowed = false;
            Refresh();
            int choice = 2;
            SayNextLine(choice);
        }
        if (Input.GetKeyDown("4") && inputAllowed)
        {
            StopCoroutine(UpdateUI());
            inputAllowed = false;
            Refresh();
            int choice = 3;
            SayNextLine(choice);
        }
    }

    void Refresh()
    {
        option1.SourceText = "";
        option1.RebuildFromSource();
        option2.SourceText = "";
        option2.RebuildFromSource();
        option3.SourceText = "";
        option3.RebuildFromSource();
        option4.SourceText = "";
        option4.RebuildFromSource();
    }

    IEnumerator UpdateUI()
    {
        inputAllowed = false;

        npcTextField.SourceText = ("<typewriter speed = 24><b>" + NPCDialogue.npcDialogue + "</b></typewriter>");
        npcTextField.RebuildFromSource();
        float npcTime = (NPCDialogue.npcDialogue.Length / 24);
        yield return new WaitForSeconds(npcTime / 2f);
        animator.SetBool("isTalking", false);
        yield return new WaitForSeconds(npcTime / 2f);
        Refresh();

        if (NPCDialogue.dialogue.Length > 0)
        {
            
            if (NPCDialogue.dialogue[0] != null || NPCDialogue.dialogue[0] != "") 
            {
                
                float time1 = (NPCDialogue.dialogue[0].Length / 20) + 0.5f;
                option1.SourceText = ("<typewriter speed = 24><b>" + NPCDialogue.dialogue[0] + "</b></typewriter>"); 
                option1.RebuildFromSource();
                yield return new WaitForSeconds(time1);
                
            } 
            else 
            { 
                option1.SourceText = ""; 
            }
            if (NPCDialogue.dialogue[1] != null || NPCDialogue.dialogue[1] != "")
            {
                float time2 = (NPCDialogue.dialogue[1].Length / 20) + 0.5f;
                option2.SourceText = ("<typewriter speed = 24><b>" + NPCDialogue.dialogue[1] + "</b></typewriter>");
                option2.RebuildFromSource();
                yield return new WaitForSeconds(time2);
            }
            else
            {
                option2.SourceText = "";
            }
            if (NPCDialogue.dialogue[2] != null || NPCDialogue.dialogue[2] != "")
            {
                float time3 = (NPCDialogue.dialogue[2].Length / 20) + 0.5f;
                option3.SourceText = ("<typewriter speed = 24><b>" + NPCDialogue.dialogue[2] + "</b></typewriter>");
                option3.RebuildFromSource();
                yield return new WaitForSeconds(time3);
            }
            else
            {
                option3.SourceText = "";
            }
            if (NPCDialogue.dialogue[3] != null || NPCDialogue.dialogue[3] != "")
            {
                float time4 = (NPCDialogue.dialogue[3].Length / 20) + 0.5f;
                option4.SourceText = ("<typewriter speed = 24><b>" + NPCDialogue.dialogue[3] + "</b></typewriter>");
                option4.RebuildFromSource();
                yield return new WaitForSeconds(time4);
                inputAllowed = true;
            }
            else
            {
                option4.SourceText = "";
            }
            
        }
        if (NPCDialogue.dialogue.Length == 0)
        {
            option1.SourceText = "";
            option2.SourceText = "";
            option3.SourceText = "";
            option4.SourceText = "";
        }
    }

    void CheckForEnd(int lineChoice)
    {
        if (NPCDialogue.endConversation.Length > 0)
        {
            if (NPCDialogue.endConversation[lineChoice] == true)
            {
                NPCDialogue = startingDialogue;
                cf.EndDialogue();
                canvas.SetActive(false);
                animator.SetBool("isTalking", false);

            }
        }
    }

    void CheckForEvent(int lineChoice)
    {
        if (NPCDialogue.events.Length > 0)
        {
            if (NPCDialogue.events[lineChoice] != null) { eventSystem.eventList.Add(NPCDialogue.events[lineChoice]); }
        }
    }

    void CheckForItem(int lineChoice)
    {
        if (NPCDialogue.items.Length > 0)
        {
            if (NPCDialogue.items[lineChoice] != null) { inventory.inventoryList.Add(NPCDialogue.items[lineChoice]); }
        }
    }

    public void SayNextLine(int lineChoice)
    {
        
        if (NPCDialogue.nextTree[lineChoice] == null)
        {
            NPCDialogue = startingDialogue;
            cf.EndDialogue();
            canvas.SetActive(false);
        }

        //playerTextField.SourceText = ( NPCDialogue.dialogue[lineChoice]);
        if (playerTextField.SourceText != "")
        { animator.SetBool("isTalking", true); }
        //playerTextField.RebuildFromSource();
        
        NPCDialogue = NPCDialogue.nextTree[lineChoice];
        currentLine++;
        CheckForEvent(lineChoice);
        CheckForItem(lineChoice);
        CheckForEnd(lineChoice);

        StopCoroutine(UpdateUI());
        Refresh();
        StartCoroutine(UpdateUI());
        
    }

}
