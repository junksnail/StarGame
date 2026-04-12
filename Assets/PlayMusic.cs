using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayMusic : MonoBehaviour
{
    public List<int> Notes = new List<int>();
    int currentNote;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            PlayNote(1);
            //play audio
        }

        if (Input.GetKeyDown("2"))
        {
            PlayNote(2);
        }

        if (Input.GetKeyDown("3"))
        {
            PlayNote(3);
        }

        if (Input.GetKeyDown("4"))
        {
            PlayNote(4);
        }
    }

    IEnumerator PlayMusicQueue()
    {
        if (Notes.Count > 0)
        {
            
        }
        yield return null;
    }

    void PlayNote(int note)
    {
        currentNote = note;
    }
}
