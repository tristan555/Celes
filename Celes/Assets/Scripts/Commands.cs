using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Commands : MonoBehaviour
{
    public GameObject SettingsPanel;//Ovo je panel za settings(Ne zaboravi ga ubacit u igri posto je public)
    public GameObject PauseMenu;//pause menu u igri kad te pita Are you sure?
	public GameObject AreYouSureMenu;//pause menu u igri kad stisnes na (||)
    public GameObject AreYouSureExtras;
    public GameObject AreYouSureQuit;
    public GameObject AreYouSureNewGame;
	public static bool isGoing = true;//da li je igra u pokretu
	public Rigidbody Player;//ovo je nasa lopta
	public AudioSource Button;//ovo je zvuk klika nekog buttona
    public Slider bgSlider;//ovo je slider za bg muziku
	public Slider seSlider;//ovo je slider za sve sound effecte
	public AudioSource bgMusic;//ovo je bg muzika
	public AudioSource HitSound;//ovo je zvuk udarca lopte
    public SavingGame Save;
    private float xPosition, yPosition, zPosition;
    

   private void Awake() {
        if (PlayerPrefs.HasKey("bgSound")) bgSlider.value = PlayerPrefs.GetFloat("bgSound");
        else bgSlider.value = 0.5f;
        if (PlayerPrefs.HasKey("seSound")) seSlider.value = PlayerPrefs.GetFloat("seSound");
        else seSlider.value = 0.5f;
        if (Save)
        {
            Save.Start();
            LoadGame();
        }
     
    }
    public void NewGame ()
	{
        Button.Play();
        if (AreYouSureNewGame) AreYouSureNewGame.SetActive(true);
		if(PauseMenu)PauseMenu.SetActive (false);
                                      //zasto ifovi? PA DA TE NE SMARA ONAJ USRANI DEBUG LOG BACA 
    }                                             //MI STO NEAKVIH ERORA A SVE NORMALNO RADI(btw ovo je samo NullReference
                                                  //Exception to jest kad inicijaliziras varijablu al joj ne das vrijednost)
    private void OnApplicationQuit()
    {
        SaveGame();
        
    }
    public void AreYouSureNewGameYes()
    {

        Button.Play();
        PlayerPrefs.DeleteAll();
        if (AreYouSureNewGame) AreYouSureNewGame.SetActive(false);
        Application.LoadLevel(1);
       
    }
    public void AreYouSureNewGameNo()
    {

        Button.Play();
        if (AreYouSureNewGame) AreYouSureNewGame.SetActive(false);

    }
    private void OnLevelWasLoaded(int level)
    {
        LoadGame();
    }
    public void ContinueGame()
    {
        Button.Play();
        Application.LoadLevel(1);
        OnLevelWasLoaded(1);
        if (PauseMenu) PauseMenu.SetActive(false);
    }
    //Ucitaj level MainMenu
	public void GoToMainMenu ()
	{
        Button.Play();
        SaveGame();
        isGoing = true;// malo se igramo sa pauzama(kad je isGoing=false onda igra ne radi,ne meres nidje mrdat s loptom)
		Application.LoadLevel (0);

        if (PauseMenu) PauseMenu.SetActive (false);
	}
    //Ucitaj MainMenu Button u igri
	public void GoToMainMenuInGame ()
	{
		Button.Play ();
		isGoing = false;
        if (PauseMenu) PauseMenu.SetActive (false);
        if (AreYouSureMenu) AreYouSureMenu.SetActive (true);

	}
    //Are You Sure prozor opcija YES
	public void GoToMainMenuInGameYes(){
        SaveGame();
        Button.Play();//ovo govno se ponavlja sto puta al ustvari i treba kad stisnes button da se cuje onaj zvuk
        isGoing = true;
        if (AreYouSureMenu) AreYouSureMenu.SetActive (false);
		Application.LoadLevel (0);
      
	}
    //Are You Sure prozor opcija NO
    public void GoToMainMenuInGameNo(){
        Button.Play();
        isGoing = true;

        if (AreYouSureMenu) AreYouSureMenu.SetActive (false);
	}
    //Pauziraj igru sa buttonom
	public void OnClickPause ()
	{
        Button.Play();
        if (PauseMenu)PauseMenu.SetActive (true);
		isGoing = false;//hehehe sad ne mozes nista mrdat
		
	}
    //Jedina opcija resume igru
	public void OnClickResume ()
	{
        Button.Play();
        isGoing = true;
		
		if(PauseMenu)PauseMenu.SetActive (false);
	}
    //Skaci sa loptom(treba zbog android odvojiti od KretanjeLopte)
	public void Jump ()
	{
		GameObject ball = GameObject.Find ("Player");
		BallMovement script = ball.GetComponent<BallMovement> ();
		if (isGoing && script.canJump) {//ako ikako radi igra i ovo canJump moras u onoj skripti BallMovement nac jbga
            Player.AddForce(new Vector3(0, 14, 0), ForceMode.Impulse);
            script.canJump = false;
        }
	}
    //Idi u settings prozor
	public void GoToSettings(){
        Button.Play();
        SettingsPanel.SetActive (true);//setactive samo strihira gore da se objekt poziva u zivot ili eventualno ubija
		if(PauseMenu)PauseMenu.SetActive (false);
	}
    
    //Settings opcija Back
    public void SettingsBack(){
        Button.Play();
        SettingsPanel.SetActive (false);
        SaveBackgroundVolume();
        SaveEffectsVolume();
        if (PauseMenu)PauseMenu.SetActive (true);

	}
    //Slider za bg muziku
    public void SaveBackgroundVolume()
    {
        PlayerPrefs.SetFloat("bgSound", bgMusic.volume);
    }
	public void BackgroundVolume(){
        bgMusic.volume = bgSlider.value;//ovo je za slider vrlo lako i vrlo vazno
	}
    public void SaveEffectsVolume()
    {
        PlayerPrefs.SetFloat("seSound", HitSound.volume);
    }
    //Slider za sve effecte(OVDE UBACUJ SVE EFEKTE KOJE BUDES IMO!!!!!!!!!!!)
	public void EffectsVolume(){
		HitSound.volume = seSlider.value;
	}
    //Idi u Shop
    public void GoToExtras()
    {
        Button.Play();
        Application.LoadLevel(2);
    }
	public void GoToExtrasInGame(){
        Button.Play();
        if(AreYouSureExtras)AreYouSureExtras.SetActive(true);
        isGoing = false;
	}
    public void GoToExtrasYes()
    {
        Button.Play();
        SaveGame();
        Application.LoadLevel(2);
        isGoing = true;
        if (AreYouSureExtras) AreYouSureExtras.SetActive(false);

    }
    public void GoToExtrasNo()
    {
        Button.Play();
        if (AreYouSureExtras) AreYouSureExtras.SetActive(false);
        isGoing = true;

    }
    public void QuitGame()
    {
        Button.Play();
        if (AreYouSureQuit) AreYouSureQuit.SetActive(true);
        if (PauseMenu) PauseMenu.SetActive(false);
        Application.Quit();
    }
    public void QuitGameYes()
    {
        Button.Play();
        SaveGame();
        Application.Quit();

    }
    public void QuitGameNo()
    {
        Button.Play();
        if (AreYouSureQuit) AreYouSureQuit.SetActive(false);
        isGoing = true;

    }
    public void SaveGame()
    {
        if (Player)
        {
            xPosition = Player.position.x;
            yPosition = Player.position.y;
            zPosition = Player.position.z;
        }
        PlayerPrefs.SetFloat("PositionX", xPosition);
        PlayerPrefs.SetFloat("PositionY", yPosition);
        PlayerPrefs.SetFloat("PositionZ", zPosition);
        if(Save)Save.SaveObjectsPosition();
        
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("PositionX")){
            xPosition = PlayerPrefs.GetFloat("PositionX");
            yPosition = PlayerPrefs.GetFloat("PositionY");
            zPosition = PlayerPrefs.GetFloat("PositionZ");
        }
        else
        {
            xPosition = -0.02f;
            yPosition = 1.36f;
            zPosition = 4.878f;
        }
        if (Player) Player.position = new Vector3(xPosition, yPosition, zPosition);
        if (Save) Save.LoadObjects();
        }

    //OVDE SE LEVELI UCITAVAJU

    public void LoadLevel3()
    {
        Application.LoadLevel(4);
        Button.Play();
    }
    

}