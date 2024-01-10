using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private WheelCollider[] wheels;    //0 and 1 are the front wheels
    [SerializeField] private MeshRenderer[] blinkers;
    [SerializeField] private Material[] blinkerMaterials;
    [SerializeField] private TextMeshProUGUI speedCounterText;

    public const float maxTurnAngle = 25;
    private const float acceleration = 1000f;
    private const float breakingForce = 500f;

    private float currentAcceleration;
    private float currentBreakForce;
    private Rigidbody rb;

    public float currentTurnAngle { get; private set; }
    public int speedKMH { get; private set; }
    public TURNSIGNAL turnSignal { get; private set; } 
    public bool isBlinking { get; private set; }


    private void Start()
    {
        turnSignal = TURNSIGNAL.NONE;
        rb = GetComponent<Rigidbody>();
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
        {
           SetBlinker(0);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SetBlinker(1);
        }

    }

    private void FixedUpdate()      //FixedUpdate is triggering 60 frames per second. This is changeble in the editor.
    {
        //speed up
        Acceleration();
        Steering();
       

        //torq on the wheels
        WheelsUpdate();

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
    }

   
    private void SetBlinker(int b)
    {
        isBlinking = !isBlinking;       
        turnSignal = (TURNSIGNAL)b;
        for (int i = 0; i < blinkers.Length; i++)
        {
            blinkers[i].material = blinkerMaterials[0];
        }

        if (isBlinking)
        {
            blinkers[(int)turnSignal].material = blinkerMaterials[1];
        }
    }

    private void Acceleration()
    {
        //input get getaxis is 0, 1 or -1. Because of this
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        ShowSpeed();
    }

    private void ShowSpeed()
    {
        float speed = rb.velocity.magnitude * 3.6f;

        //float rpm = wheels[0].rpm;
        //float speed = (rpm * 2 * Mathf.PI * 0.35f * 60) / 1000;

        speedKMH = Mathf.RoundToInt(speed);
        speedCounterText.text = Mathf.Abs(speedKMH).ToString();
    }

    private void Break()
    {
        currentBreakForce = breakingForce;
    }

    private void WheelsUpdate()
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

    private void Steering()
    {
        for (int i = 0; i < 1; i++)
        {
            wheels[i].steerAngle = currentTurnAngle;
        }
    }

  

  

  
    

}
