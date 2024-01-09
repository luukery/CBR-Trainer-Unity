using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSignalCheck : BaseCheck
{
    protected override void isChecking()
    {
        if (player.currentTurnAngle == PlayerMovement.maxTurnAngle && player.turnSignal == CheckSignal(1))
        {
            hasSuceeded = true;
        }
        else if (player.currentTurnAngle == -PlayerMovement.maxTurnAngle && player.turnSignal == CheckSignal(0))
        {
            hasSuceeded = true;
        }
    }

    private TURNSIGNAL CheckSignal(int i)
    {
        switch (i)
        {
            case 0:
                return TURNSIGNAL.LEFT;
            case 1:
                return TURNSIGNAL.RIGHT;
        }
        return TURNSIGNAL.NONE;
    }

    
}
