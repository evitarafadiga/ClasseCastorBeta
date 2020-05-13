using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelButtonPrefab;
    public GameObject levelButtonContainer;
    public GameObject shopButtonPrefab;
    public GameObject shopButtonContainer;

    public Material playerMaterial;

    private void Start() 
    {
        ChangePlayerSkin (0);

        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
        foreach (Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate (levelButtonPrefab) as GameObject;
            container.GetComponent<Image> ().sprite = thumbnail;
            container.transform.SetParent (levelButtonContainer.transform,false);
        
            string sceneName = thumbnail.name;
            container.GetComponent<Button>().onClick.AddListener(() => LoadLevel(sceneName));

        }

        Sprite[] textures = Resources.LoadAll<Sprite> ("Player");
        foreach  (Sprite texture in textures)
        {
           GameObject container = Instantiate (shopButtonPrefab) as GameObject;
            container.GetComponent<Image> ().sprite = texture;
            container.transform.SetParent (shopButtonContainer.transform,false);
         
        }
    }

    private void LoadLevel(string sceneName)
    {
        Debug.Log (sceneName);

        SceneManager.LoadScene (sceneName);
    }

    public void LookAtMenu (Transform menuTransform)
    {
        Camera.main.transform.LookAt (menuTransform.position);
    }

    private void ChangePlayerSkin (int index)
    {
        float x = (index) * 0.0322f;
        float y = 1f;


        playerMaterial.SetTextureOffset ("_MainTex", new Vector2 (x,y));
    }
}
