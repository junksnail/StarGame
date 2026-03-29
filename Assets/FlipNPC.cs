using UnityEngine;

public class FlipNPC : MonoBehaviour
{
    [SerializeField] bool isFlipped;
    bool flipping;

    void Update()
    {
        if (isFlipped && !flipping) 
        {
            flipping = true;
            gameObject.transform.localScale = new Vector3(-3.66f, 3.66f, 3.66f);
        }
    }
}
