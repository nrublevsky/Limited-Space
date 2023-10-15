using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public AudioMixer myMixer;
    public Slider musicSlider;
    public GameObject gameOverScreen;
   
    
    // Start is called before the first frame update
   public void PlayGameEasy() 
    {
        SceneManager.LoadScene("Slava");
    
    }

  /*  public void PlayGameMedium() 
    {
        SceneManager.LoadScene("Medium");
    
    }*/

/*    public void PlayGameHard() 
    {

        SceneManager.LoadScene("Hard");
    }*/

    public void Quit() 
    { 
    Application.Quit();
    
    }

    public void Settings()
    {
        settings.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void GetMainMenu()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume)*20);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void StartAgain()
    {
        SceneManager.LoadScene("Slava");
        gameOverScreen.SetActive(false);
    }
   
}
