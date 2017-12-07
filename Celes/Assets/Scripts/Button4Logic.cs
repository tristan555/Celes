using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Button4Logic : MonoBehaviour {

    private Animation Ploca;
    private Ploca4Collision Ploca1;
    private Button3Logic Ploca2;
    public bool Podignuta = false;
    public bool Podignuta1 = false;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Button4Pomjeren")) Podignuta = Convert.ToBoolean(PlayerPrefs.GetFloat("Button4Pomjeren"));
        else Podignuta = false;
        if (PlayerPrefs.HasKey("Button4Pomjeren1")) Podignuta1 = Convert.ToBoolean(PlayerPrefs.GetFloat("Button4Pomjeren1"));
        else Podignuta1 = false;
        Ploca = GameObject.Find("Ploca4").GetComponent<Animation>();
        Ploca1 = GameObject.Find("Ploca4").GetComponent<Ploca4Collision>();
        Ploca2 = GameObject.Find("Button3").GetComponent<Button3Logic>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Ploca2.Podignuta)
        {
            if (!Podignuta && Ploca1.Sudar)
            {
                if (!GameObject.Find("Ploca4").GetComponent<Animation>().IsPlaying("Ploca4Down"))
                {
                    Ploca = GameObject.Find("Ploca4").GetComponent<Animation>();
                    Ploca.Play("Ploca4Up");
                    Podignuta = true;
                }
            }
            else if (Podignuta && Ploca1.Sudar)
            {
                if (!Ploca.IsPlaying("Ploca4Up"))
                {
                    GameObject.Find("Ploca4").GetComponent<Animation>().Play("Ploca4Down");
                    Podignuta = false;
                }
            }
            transform.GetComponent<Animation>().Play();
            PlayerPrefs.SetFloat("Button4Pomjeren", Convert.ToInt32(Podignuta));
            PlayerPrefs.SetFloat("Button4Pomjeren1", Convert.ToInt32(Podignuta1));
        }
        else
        {
            if (!Podignuta1)
            {
                if (!GameObject.Find("Ploca4").GetComponent<Animation>().IsPlaying("Ploca4Down1"))
                {
                    Ploca = GameObject.Find("Ploca4").GetComponent<Animation>();
                    Ploca.Play("Ploca4Up1");
                    Podignuta1 = true;
                    
                }
            }
            else if (Podignuta1)
            {
                if (!Ploca.IsPlaying("Ploca4Up1"))
                {
                    GameObject.Find("Ploca4").GetComponent<Animation>().Play("Ploca4Down1");
                    Podignuta1 = false;
                }
            }
            transform.GetComponent<Animation>().Play();
        }
        transform.GetComponent<Animation>().Play();
        PlayerPrefs.SetFloat("Button4Pomjeren1", Convert.ToInt32(Podignuta1));
        PlayerPrefs.SetFloat("Button4Pomjeren", Convert.ToInt32(Podignuta));
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerPrefs.SetFloat("Button4Pomjeren1", Convert.ToInt32(Podignuta1));
        PlayerPrefs.SetFloat("Button4Pomjeren", Convert.ToInt32(Podignuta));
    }
}
