using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsLogic : MonoBehaviour
{

    private GameObject[] Buttons;
    private string[] imenaButtona, imenaPloca;
    private Animation[] Animations;
    private bool[] pomjereno;
    private void Awake()
    {
   
        imenaButtona = new string[6];
        for (int i = 0; i < 6; i++)
        {
            imenaButtona[i]="Button"+i+1;
        }
        imenaPloca = new string[6];
        for (int i = 0; i < 6; i++)
        {
            imenaPloca[i] = "Ploca" + i + 1;
        }
        Buttons = new GameObject[6];
        for (int i = 0; i < 6; i++)
        {
            Buttons[i] = GameObject.Find(imenaButtona[i]);
        }
        Animations = new Animation[6];
        for (int i = 0; i < 6; i++)
        {
            Animations[i] = GameObject.Find(imenaPloca[i]).GetComponent<Animation>();
        }
        pomjereno = new bool[6];
        for(int i = 0; i < 6; i++)
        {
            pomjereno[i] = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (transform.name == Buttons[i].name)
            {
                if (!pomjereno[i])
                {
                    if (!Animations[i].IsPlaying("Ploca"+i+1+"Down"))
                    {
                        Animations[i].Play("Ploca"+i+1+"Down");
                        pomjereno[i] = true;
                    }
                }
                else if (pomjereno[i])
                {
                    if (!Animations[i].IsPlaying("Ploca"+i+1))
                    {
                        Animations[i].Play("Ploca"+i+1+"Down");
                        pomjereno[i] = false;
                    }
                }


            }
        }
        transform.GetComponent<Animation>().Play();
    }
}