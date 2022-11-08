using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundsmanager : MonoBehaviour
{
    public static AudioClip keysound;
    public static AudioClip baguettesound;
    public static AudioClip doorsound;

    static AudioSource audioScr;
    // Start is called before the first frame update
    void Start()
    {
        keysound = Resources.Load<AudioClip>("keysound");
        baguettesound = Resources.Load<AudioClip>("baguettesound");
        doorsound = Resources.Load<AudioClip>("doorsound");

        audioScr = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "keysound":
                audioScr.PlayOneShot(keysound);
                    break;
            case "baguettesound":
                audioScr.PlayOneShot(baguettesound);
                break;
            case "doorsound":
                audioScr.PlayOneShot(doorsound);
                break;
        }
    }
    
}
