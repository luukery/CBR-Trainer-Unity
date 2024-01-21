using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

enum LEVELRATING
{
    MISSING,
    BAD,
    AVERAGE,
    GOOD
}

public class LevelComplete : BaseCheck
{
    private bool FinishedLevel;

    private int percentageComplete;
    public bool[] allChecks;
    private LEVELRATING rating;


    private void Start()
    {
        hasSuceeded = true;
    }
    protected override void isChecking()
    {
        if(!FinishedLevel)
        {
            FinishedLevel = true;
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        allChecks = GetAllChecksInScene();
        percentageComplete = CalculatePercentage(allChecks.Length) + 80;


        rating = Rating(percentageComplete);


        print("percentageComplete = " + percentageComplete);
        print("rating = " + rating);
        //sent to database
    }


    private bool[] GetAllChecksInScene()
    {
        BaseCheck[] b = FindObjectsOfType<BaseCheck>();
        List<bool> c = new List<bool>();

        for (int i = 0; i < b.Length; i++)
        {
            GameObject currentGameObject = b[i].gameObject;

            print(currentGameObject);
        }

        for (int i = 0; i < b.Length; i++)
        {
            c.Add(b[i].hasSuceeded);
        }

        bool[] q = c.ToArray();

        return q;
    }

    private int CalculatePercentage(int listLength)
    {
        int amountOfCompletedChecks = 0;

        for (int i = 0; i < allChecks.Length; i++)
        {
            if (allChecks[i] == true)
            {
                amountOfCompletedChecks++;
            }
        }
        return amountOfCompletedChecks / listLength * 100;
    }

    private LEVELRATING Rating(int percentage)
    {
        switch (percentage)
        {
            case int n when (n < 50):
                return LEVELRATING.AVERAGE;

            case int n when (n >= 50 && n < 80):
                return LEVELRATING.AVERAGE;

            case int n when (n >= 80):
                return LEVELRATING.GOOD;
        }
        return LEVELRATING.MISSING;
    }

    
}
