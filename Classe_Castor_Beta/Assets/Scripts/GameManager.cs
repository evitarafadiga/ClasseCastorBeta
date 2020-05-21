using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public static GameManager Instance{get{ return instance;}}

    public int currentSkinIndex = 0;
    public int currency = 0;
    public int skinAvailability = 1;
    public int emeralds = 0;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad (gameObject);

       if (PlayerPrefs.HasKey("CurrentSkin"))
       {
           // sessão prévia
           currentSkinIndex = PlayerPrefs.GetInt("CurrentSkin");
           currency = PlayerPrefs.GetInt ("Currency");
           emeralds = PlayerPrefs.GetInt ("Emeralds");
           skinAvailability = PlayerPrefs.GetInt("SkinAvailability");
       }
       else 
       {
           Save ();
       }
    
    }

    public void Save()
    {

        PlayerPrefs.SetInt ("CurrentSkin", currentSkinIndex);
        PlayerPrefs.SetInt ("Currency", currency);
        PlayerPrefs.SetInt ("Emeralds", emeralds);
        PlayerPrefs.SetInt ("SkinAvailability", skinAvailability);

    }
        
}
