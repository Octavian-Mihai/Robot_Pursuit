using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class deplacementROBOT : MonoBehaviour
{
    private NavMeshAgent _agent;
    private int _destination;
    [SerializeField] private Transform[] nextWaypoints = new Transform[2];

    [SerializeField] float rangeVue;
    private bool joueurEnVue;
    public GameObject joueur;
    public GameObject robot;


    private bool chasseJoueur = false;
    private Vector3 lastKnownPlayerPosition;

    public TMP_Text texteLoss;
    public Button buttonRejouer;

    private Animator _animator;

    void Start()
    {
        Time.timeScale = 1;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _destination = 0;
        _agent.SetDestination(nextWaypoints[_destination].position);
    }
    void Update()
    {
          if (Utilitaires.ObjetVisible(robot, joueur, 80.0f, 25.0f))
          {
              GameObject[] allRobots = GameObject.FindGameObjectsWithTag("robot");

              foreach (var chaqueRobot in allRobots)
              {
                  NavMeshAgent newAgent = chaqueRobot.GetComponent<NavMeshAgent>();
                  newAgent.SetDestination(joueur.transform.position);
                  _agent.SetDestination(joueur.transform.position);
              }
          }


          if (!_agent.pathPending && (_agent.remainingDistance <= _agent.stoppingDistance))
          {
              _destination++;
              if (_destination == nextWaypoints.Length)
              {
                  _destination = 0;
              }
              _agent.SetDestination(nextWaypoints[_destination].position);
          }

        /*  if (Utilitaires.ObjetVisible(gameObject, joueur.gameObject, 80.0f, 25.0f))
          {
              chasseJoueur = true;
              lastKnownPlayerPosition = joueur.transform.position;
          }
          else
          {
              if (chasseJoueur && Vector3.Distance(transform.position, lastKnownPlayerPosition) <= _agent.stoppingDistance)
              {
                  chasseJoueur=false;
              }
          }

          if (chasseJoueur)
          {
              ChasePlayer();
          }
          else
          {
              Patrol();
          }

          void ChasePlayer()
          {
              _agent.SetDestination(joueur.transform.position);
          }

          void Patrol()
          {
              if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
              {
                  _destination++;
                  if (_destination == nextWaypoints.Length)
                  {
                      _destination = 0;
                  }
                  _agent.SetDestination(nextWaypoints[_destination].position);
              }
          }  */

        // cheat code for teleportation
        if (Input.GetKeyDown(KeyCode.T))
        {
            joueur.transform.position = new Vector3(-3f, 0.1f, 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "joueur")
        {
            texteLoss.gameObject.SetActive(true);
            buttonRejouer.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
