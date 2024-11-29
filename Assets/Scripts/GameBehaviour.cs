using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    // hud \/\/\/\/
    public int maxItems = 4;
    public TMP_Text healthTxt;
    public TMP_Text itemTxt;
    public TMP_Text progressTxt;
    // hud /\/\/\/\
    public Button winBtn; // <- boton victoria
    
    private int _itemsCollected = 0;
    private int _playerHP = 10;

    // Start is called before the first frame update
    void Start()
    {
        itemTxt.text += _itemsCollected; // <- hud
        healthTxt.text += _playerHP; // <- hud

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    // getters & setters \/\/\/\/
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);

            // hud \/\/\/\/
            itemTxt.text = "Items: " + Items;

            if (_itemsCollected >= maxItems)
            {
                progressTxt.text = "All items have been collected";
                winBtn.gameObject.SetActive(true); // <- boton victoria
                Time.timeScale = 0f; // <- pausa y reinicio juego

            } else
            {
                progressTxt.text = "Item found. " + (maxItems - _itemsCollected) + 
                                   " Items remaining.";

            }
            // hud /\/\/\/\

        }
        
    }

    // getters & setters \/\/\/\/
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Health: {0}", _playerHP);
            
            healthTxt.text = "HP: " + HP; // <- hud
            
        }
        
    }
    // getters & setters /\/\/\/\

    // pausa y reinicio juego \/\/\/\/
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }
    // pausa y reinicio juego /\/\/\/\
    
}
