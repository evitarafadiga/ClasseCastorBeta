using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInfoManager : MonoBehaviour
{
    public GameObject UserInfoMenu;

    private void Start()
    {
        UserInfoMenu.SetActive (false);
    }
    
    public void TogglehideUserInfoMenu()
    {
        UserInfoMenu.SetActive (!UserInfoMenu.activeSelf);
    }
   
}