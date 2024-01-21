using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class BaseCheck : MonoBehaviour
{
    protected PlayerMovement player;
    protected bool hasEntered;

    public bool hasSuceeded { get; set; }
    public bool hasSucceeded2;

    protected void Update()
    {
        if (hasEntered)
            isChecking();

        hasSucceeded2 = hasSuceeded;
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
