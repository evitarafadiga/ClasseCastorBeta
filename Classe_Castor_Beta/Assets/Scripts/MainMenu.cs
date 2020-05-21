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

    public Text currencyText;
    public Text currencyCoinsUserInfoText;
    public Text currencyEmeraldsUserInfoText;

    public Material playerMaterial;

    private void Start() 
    {
        ChangePlayerSkin (GameManager.Instance.currentSkinIndex);
        currencyText.text = "Moedas : " + GameManager.Instance.currency.ToString ();
        currencyCoinsUserInfoText.text = " " + GameManager.Instance.currency.ToString ();
        currencyEmeraldsUserInfoText.text = " " + GameManager.Instance.emeralds.ToString ();

        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
        foreach (Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate (levelButtonPrefab) as GameObject;
            container.GetComponent<Image> ().sprite = thumbnail;
            container.transform.SetParent (levelButtonContainer.transform,false);
        
            string sceneName = thumbnail.name;
            container.GetComponent<Button> ().onClick.AddListener (() => LoadLevel(sceneName));

        }

        int textureIndex = 0;

        Sprite[] textures = Resources.LoadAll<Sprite> ("Player");
        foreach  (Sprite texture in textures)
        {
           GameObject container = Instantiate (shopButtonPrefab) as GameObject;
            container.GetComponent<Image> ().sprite = texture;
            container.transform.SetParent (shopButtonContainer.transform,false);
         
            int index = textureIndex;
            container.GetComponent<Button> ().onClick.AddListener (() => ChangePlayerSkin(index));
            

            if ((GameManager.Instance.skinAvailability & 1 << index) == 1 << index)
            {
                container.transform.GetChild (0).gameObject.SetActive (false); // desliga os overlays
            }

            textureIndex++;
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
        if ((GameManager.Instance.skinAvailability & 1 << index) == 1 << index)
        {
            //Debug.Log (1 << index);

            float x = (index) * 0.0322f;
            float y = 1f;


            playerMaterial.SetTextureOffset ("_MainTex", new Vector2 (x,y));
            GameManager.Instance.currentSkinIndex = index;
            GameManager.Instance.Save();

            
        }
        else
        {
            int cost = 150;

            if (GameManager.Instance.currency >= cost) 
            {
                GameManager.Instance.currency -= cost;
                GameManager.Instance.skinAvailability += 1 << index;
                GameManager.Instance.Save ();

                currencyText.text = "Currency : " + GameManager.Instance.currency.ToString ();
                currencyCoinsUserInfoText.text = " " + GameManager.Instance.currency.ToString ();
                currencyEmeraldsUserInfoText.text = " " + GameManager.Instance.emeralds.ToString ();

                shopButtonContainer.transform.GetChild (index).GetChild (0).gameObject.SetActive (false);
                ChangePlayerSkin (index);

            }
        }

        
    }
}
