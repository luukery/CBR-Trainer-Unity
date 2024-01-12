using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class BaseCheck : MonoBehaviour
{
    protected PlayerMovement player;
    protected bool hasEntered;

   public bool hasSuceeded { get; set; }

    protected void Update()
    {
        if (hasEntered)
            isChecking();
    }
    private void OnTriggerEnter(Collider other)
    {
        hasEntered = true;
        player = other.GetComponent<PlayerMovement>();
    }

    private void OnTriggerExit(Collider other)
    {
        hasEntered = false;
    }

   

    protected abstract void isChecking();
}
