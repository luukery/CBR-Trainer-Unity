using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCheck : MonoBehaviour
{
    protected bool hasSuceeded;
    protected PlayerMovement player;
    protected bool hasEntered;

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
        player = null;

        print(hasSuceeded);
    }

    protected abstract void isChecking();
}
