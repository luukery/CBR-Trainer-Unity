using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCheck : BaseCheck
{
    [SerializeField] private int speedLimit;
    private bool passingSpeedLimitTest;

    private void Start()
    {
        hasSuceeded = true;
    }
    protected override void isChecking()
    {
        
        if (player.speedKMH > speedLimit + 3 && !passingSpeedLimitTest)
        {
            passingSpeedLimitTest = true;
            StartCoroutine(CheckSpeed());
        }

    }

    IEnumerator CheckSpeed()
    {
        yield return new WaitForSeconds(5);

        if (player)
        {
            if (player.speedKMH > speedLimit + 5)
            {
                hasSuceeded = false;
            }
        }

        passingSpeedLimitTest = false;

    }


}
