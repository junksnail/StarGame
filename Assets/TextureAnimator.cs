using UnityEngine;
using System.Collections;

public class TextureAnimator : MonoBehaviour
{
    public float fps;
    public Material[] textures;
    public Material mat;
    public Renderer rend;
    public bool active;
    
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        mat = rend.material;
    }

    IEnumerator Animate()
    {
        active = true;
        foreach (var tex in textures)
        {
            rend.material = tex;
            yield return new WaitForSeconds(fps);
        }
        active = false;
    }

    void Update()
    {
        if (!active)
        {
            StartCoroutine(Animate());
        }
    }

}