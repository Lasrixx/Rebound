using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Soundtrack : MonoBehaviour
{
    private static Soundtrack soundtrack;


    public static Soundtrack CheckIfSoundtrackExists                //Checks if any soundtrack already exists, if not, then put in soundtrack in MainMenu scene
    {
        get
        {
            if (soundtrack == null)
            {
                soundtrack = GameObject.FindObjectOfType<Soundtrack>();

                DontDestroyOnLoad(soundtrack.gameObject);
            }

            return soundtrack;
        }
    }

    void Awake()                        //Checks whether a soundtrack exists, if it does, it destroys the second soundtrack waiting in the wings.
    {
        if (soundtrack == null)
        {
            soundtrack = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != soundtrack)
                Destroy(this.gameObject);
        }
    }
}                                               //By Varaquilex
