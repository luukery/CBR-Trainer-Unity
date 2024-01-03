using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private WheelCollider[] wheels ;    //0 and 1 are the front wheels
    [SerializeField] private MeshRenderer[] blinkers;
    [SerializeField] private Material[] blinkerMaterials;
    
    private int gearShift = 1;



    private float acceleration = 1000f;
    private float breakingForce = 300f;
    private float maxTurnAngle = 25f;
    private float currentAcceleration;
    private float currentBreakForce;
    private float currentTurnAngle;

    private TURNSIGNAL signal;
    public TURNSIGNAL SSignal { get { return signal; } private set { }}
    private bool isBlinking;


    void Start()
    {
        
    }

    private void Update()       //update is triggering every frame
    {
        //break
        if (Input.GetKey(KeyCode.Space))
            Break();
        else
            currentBreakForce = 0;

        //blinker input
        if (Input.GetMouseButtonDown(0))
            Blinker(TURNSIGNAL.LEFT);

        if (Input.GetMouseButtonDown(1))
            Blinker(TURNSIGNAL.RIGHT);

    }

    private void FixedUpdate()      //FixedUpdate is triggering 60 frames per second. This is changeble in the editor.
    {
        //speed up
        Speed();
        Steering();
       

        //torq on the wheels
        WheelsUpdate();

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
    }


    void Speed()
    {
        //input get getaxis is 0, 1 or -1. Because of this
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
    }

    void Break()
    {
        currentBreakForce = breakingForce;
    }

    void WheelsUpdate()
    {
        for (int i = 0; i < 1; i++)
        {
            wheels[i].motorTorque = currentAcceleration;
        }

        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].brakeTorque = currentBreakForce;

        }

       
    }

    void Steering()
    {
        for (int i = 0; i < 1; i++)
        {
            wheels[i].steerAngle = currentTurnAngle;
        }

       
    }

    void Blinker(TURNSIGNAL ts)
    {
        for (int i = 0; i < blinkers.Length; i++)
        {
            blinkers[i].material = blinkerMaterials[0];
        }

        if (!isBlinking)
        {
            isBlinking = true;
            switch (ts)
            {
                case TURNSIGNAL.RIGHT:
                    StartCoroutine(Blinker(0));
                    break;

                case TURNSIGNAL.LEFT:
                    StartCoroutine(Blinker(1));
                    break;
            }
        }
    }

    IEnumerator Blinker(int b)
    {
        blinkers[b].material = blinkerMaterials[1];
        yield return new WaitForSeconds(0.5f);
        blinkers[b].material = blinkerMaterials[0];
    }

    void Gearshift()
    {

    }
    

}
