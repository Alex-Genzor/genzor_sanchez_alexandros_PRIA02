using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
        public int maxItems = 4;
    public TMP_Text healthTxt;
    public TMP_Text itemTxt;
    public TMP_Text progressTxt;
    
    public Button winBtn;
    public Button lossBtn; // condicion derrota 1
    
    private int _itemsCollected = 0;
    private int _playerHP = 10;

    // Start is called before the first frame update
    void Start()
    {
        itemTxt.text += _itemsCollected; 
        healthTxt.text += _playerHP; 

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    // refactoring & DRY \/\/\/\/
    public void UpdateScene(string updatedTxt)
    {
        progressTxt.text = updatedTxt;
        Time.timeScale = 0f;

    }

    // refactoring & DRY /\/\/\/\

    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);

            itemTxt.text = "Items: " + Items;

            if (_itemsCollected >= maxItems)
            {
                UpdateScene("All items have been collected!"); // refactoring & DRY
                winBtn.gameObject.SetActive(true); 
                Time.timeScale = 0f;


            } else
            {
                progressTxt.text = "Item found. " + (maxItems - _itemsCollected) + 
                                   " Items remaining.";

            }

        }
        
    }

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Health: {0}", _playerHP);
            
            healthTxt.text = "HP: " + HP; // <- hud
            
            // condicion derrota 1 \/\/\/\/
            if (_playerHP <= 0)
            {
                UpdateScene("You want to have your own vendetta?"); // refactoring & DRY
                lossBtn.gameObject.SetActive(true);

                Time.timeScale = 0;

            }
            else
            {
                progressTxt.text = "Owie! :(";

            }
            
            // condicion derrota 1 /\/\/\/\
            
        }
        
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }
    
}
