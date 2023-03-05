using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent <Collider2D> OnTriggerEnter, OnTriggerStay, OnTriggerExit;
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggerEnter.Invoke(other);
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        OnTriggerStay.Invoke(other);
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        OnTriggerExit.Invoke(other);
    }
    
}
