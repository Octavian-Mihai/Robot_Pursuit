using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.AI;

public class controller : MonoBehaviour
{
    public GameObject joueur;

    private float tempsDebut = 120f;
    private float tempsMtn;
    private float _tempsMinute;
    private float _tempsSeconde;
    public TMP_Text texteTemps;


//    public GameObject panelFinPartie;

    public TMP_Text texteWin;
    public TMP_Text texteLoss;
    public Button buttonRejouer;

   //    public GameObject Ferdinand;

    void Start()
    {
        joueur = GameObject.Find("joueur");
        tempsMtn = tempsDebut;
        _tempsMinute = tempsMtn / 60;
        _tempsSeconde = tempsMtn % 60;

        Time.timeScale = 1;

        texteTemps.text = string.Format("{0:00}:{1:00}", _tempsMinute, _tempsSeconde);
        texteLoss.gameObject.SetActive(false);
        texteWin.gameObject.SetActive(false);  
        buttonRejouer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tempsMtn -= Time.deltaTime;
        _tempsMinute = tempsMtn / 60;
        _tempsSeconde = tempsMtn % 60;

        texteTemps.text = string.Format("{0:00}:{1:00}", _tempsMinute, _tempsSeconde);

        if (tempsMtn <= 0.1f)
        {
            Time.timeScale = 0;
            texteLoss.gameObject.SetActive(true);
            buttonRejouer.gameObject.SetActive(true);
        }

        if (joueur.transform.position.z >= 3.5f)
        {
            Time.timeScale = 0;
            texteWin.gameObject.SetActive(true);
            buttonRejouer.gameObject.SetActive(true);
        }

        // cheat code pour le temps
        if (Input.GetKeyDown(KeyCode.Y))
        {
            tempsMtn = 3f;
        }  

    }

    public void Rejouer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
