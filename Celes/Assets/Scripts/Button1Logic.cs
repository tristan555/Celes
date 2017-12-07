using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Button1Logic : MonoBehaviour {
    private Animation Ploca;
    public bool Podignuta=false;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Button1Pomjeren")) Podignuta = Convert.ToBoolean(PlayerPrefs.GetFloat("Button1Pomjeren"));
        else Podignuta = false;
        Ploca = GameObject.Find("Ploca1").GetComponent<Animation>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!Podignuta)
        {
            if (!Ploca.IsPlaying("Ploca1Down"))
            {
                
                Ploca.Play("Ploca1Up");
                Podignuta = true;
            }
        }
        else if (Podignuta)
        {
            if (!Ploca.IsPlaying("Ploca1Up"))
            {
                Ploca.Play("Ploca1Down");
                Podignuta = false;
            }
        }
        transform.GetComponent<Animation>().Play();
        PlayerPrefs.SetFloat("Button1Pomjeren", Convert.ToInt32(Podignuta));
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerPrefs.SetFloat("Button1Pomjeren", Convert.ToInt32(Podignuta));
    }
}
