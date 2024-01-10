using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnter : BaseCheck
{
    protected override void isChecking()
    {
        hasSuceeded = false;
    }

    void Start()
    {
        hasSuceeded = true;
    }

   
}
