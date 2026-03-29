using UnityEngine;
using System.Collections;

public class ChatField : MonoBehaviour
{
    [SerializeField] GameObject chatIcon;
    GameObject player;
    PlayerController pc;
    bool talking = false;
    GameObject mainCamera;
    bool playerInside;
    Vector3 savedCamPos;
    Vector3 targetPosition;

    bool lerping;
    DialogueSystem ds;

    void Start()
    {
        mainCamera = Camera.main.gameObject;
        ds = GetComponent<DialogueSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player inside");
            chatIcon.SetActive(true);
            if (player == null) { player = other.gameObject; pc = player.GetComponent<PlayerController>(); }

            playerInside = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            chatIcon.SetActive(false);
            playerInside = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !talking && playerInside)
        {
            BeginDialogue();
            Debug.Log("E pressed");
        }
        if (lerping)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, Time.deltaTime * 2f);
        }
    }

    void BeginDialogue()
    {
        chatIcon.SetActive(false);
        talking = true;
        pc.enabled = false;
        savedCamPos = mainCamera.transform.position;
        Vector3 camPos = CameraMidpoint();
        targetPosition = new Vector3(camPos.x, savedCamPos.y - 2f, savedCamPos.z + 1.5f);
        lerping = true;
        StartCoroutine(LerpTimer(5f));
        ds.enabled = true;
        
    }

    public void EndDialogue()
    {
        chatIcon.SetActive(true);
        talking = false;
        pc.enabled = true;
        lerping = false;
        mainCamera.transform.position = savedCamPos;
        
        StartCoroutine(LerpTimer(5f));
        ds.enabled = false;
    }

    Vector3 CameraMidpoint()
    {
        Vector3 position1 = player.transform.position;
        Vector3 position2 = transform.position;

        Vector3 midpoint = Vector3.Lerp(position1, position2, 0.5f);

        return midpoint;
    }
    IEnumerator LerpTimer(float lerpTime)
    {
        yield return new WaitForSeconds(lerpTime);
        lerping = false;
        yield return null;
    }
}
