using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationCube : MonoBehaviour
{
    [SerializeField] private Vector3 axeRotation;
    [SerializeField] private float vitesseRotation;
    private AudioSource pickup;

    void Update()
    {
        float angle = vitesseRotation * Time.deltaTime;
        transform.Rotate(axeRotation, angle);
        pickup = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "joueur")
        {
            Destroy(gameObject, 0.5f);
            pickup.Play();
        }
    }
}
