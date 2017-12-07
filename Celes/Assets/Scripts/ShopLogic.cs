using UnityEngine;
using System.Collections;

public class ShopLogic : MonoBehaviour {
	public GameObject Page1;
	public GameObject Page2;
	public GameObject Page3;
    public GameObject Page4;
	public AudioSource Click;

	public void GoToPage1(){
		Page1.SetActive (true);
		Page2.SetActive (false);
		Click.Play ();

	}
	public void GoToPage2(){
		Click.Play ();
		Page2.SetActive (true);
		Page1.SetActive (false);
		Page3.SetActive (false);

	}
	public void GoToPage3(){
		Click.Play ();
		Page3.SetActive (true);
		Page2.SetActive (false);
		Page4.SetActive (false);

	}
    public void GoToPage4()
    {
        Page4.SetActive(true);
        Page3.SetActive(false);
        Click.Play();
    }
}
