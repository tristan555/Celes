using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Button3Logic : MonoBehaviour {

    private Animation Ploca;
    private Button4Logic Ploca1;
    public bool Podignuta = false;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Button3Pomjeren")) Podignuta = Convert.ToBoolean(PlayerPrefs.GetFloat("Button3Pomjeren"));
        else Podignuta = false;
        Ploca = GameObject.Find("Ploca3").GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Podignuta)
        {
            if (!GameObject.Find("Ploca3").GetComponent<Animation>().IsPlaying("Ploca3Down"))
            {
                Ploca = GameObject.Find("Ploca3").GetComponent<Animation>();
                Ploca.Play("Ploca3Up");
                Podignuta = true;
                
            }
        }
        else if (Podignuta)
        {
            if (!Ploca.IsPlaying("Ploca3Up"))
            {
                GameObject.Find("Ploca3").GetComponent<Animation>().Play("Ploca3Down");
                Podignuta = false;
            }
        }
        transform.GetComponent<Animation>().Play();
        PlayerPrefs.SetFloat("Button3Pomjeren", Convert.ToInt32(Podignuta));
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerPrefs.SetFloat("Button3Pomjeren", Convert.ToInt32(Podignuta));
    }
}
