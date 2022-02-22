using System;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Entered a collision");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Triggered a collision");
    }
}