using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Gate;

    private void OnTriggerEnter(Collider other)
    {
        Gate.SetActive(false);
        gameObject.SetActive(false);
    }
}
