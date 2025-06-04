using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class deplacementJoueur : MonoBehaviour
{
    public GameObject joueur;

    public float vitesse;
    public float vitesseRotation;

    private Animator _animator;
    private CharacterController _controleurMouvement;


    void Start()
    {
        joueur.transform.position = new Vector3(-28f, 0.1f, -44f);
        _animator = GetComponent<Animator>();
        _controleurMouvement = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalArriere;
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Rotate(Vector3.up, vitesseRotation * horizontal);

        if (vertical > 0)
        {
            Vector3 vecteurVitesse = transform.forward * vitesse * vertical;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                vecteurVitesse *= 2;
            }
            _controleurMouvement.SimpleMove(vecteurVitesse);
            _animator.SetBool("Marche", true);
        }
        else if (vertical < 0)
        {
            verticalArriere = -vertical;
            Vector3 vecteurVitesse = -transform.forward * vitesse * verticalArriere;
            _controleurMouvement.SimpleMove(vecteurVitesse);
            _animator.SetBool("Marche", true);
        }
        else
        {
            _animator.SetBool("Marche", false);
        }
    }
}
