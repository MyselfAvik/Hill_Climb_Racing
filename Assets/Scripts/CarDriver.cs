using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CarDriver: MonoBehaviour
{
    

    [SerializeField] private Rigidbody2D frontTire;
    [SerializeField] private Rigidbody2D backTire;
    [SerializeField] private Rigidbody2D carBody;
    [SerializeField] private float speed = 150f;
    [SerializeField] private float rotationSpeed = 300f;
    [SerializeField] private AudioSource coinSoundSource;
    [SerializeField] private AudioClip coinAudioSource;
    [SerializeField] private TextMeshProUGUI fuelDistance;
    private float moveInput;
    private List<Transform> fuels = new List<Transform>();
    private Transform nearestFuel;
    private float nearestFuelDistance;


    private void Start()
    {
        fuelDistance.enabled = false;
        fuels = GameObject.FindGameObjectsWithTag("Fuel")
                      .Select(f => f.transform)
                      .ToList();
    }
    public void SetMoveInput(float value)
    {
        moveInput = value;
    }
    public void StopMoveInput()
    {
        moveInput = 0;
    }
    private void FindNearestFuel()
    {
        nearestFuel = null;
        nearestFuelDistance = Mathf.Infinity;

        for (int i = fuels.Count - 1; i >= 0; i--)
        {
            if (fuels[i] == null)
            {
                fuels.RemoveAt(i); // remove destroyed fuel
                continue;
            }

            float distance = Vector2.Distance(transform.position, fuels[i].position);

            if (distance < nearestFuelDistance)
            {
                nearestFuelDistance = distance;
                nearestFuel = fuels[i];
            }
        }
    }

    private void Update()
    {
        FindNearestFuel();

        if (nearestFuel != null)
        {

            if (nearestFuelDistance <= 50)
            {
                fuelDistance.enabled = true;
                fuelDistance.text=Math.Floor(nearestFuelDistance).ToString();
            }
            else
            {
                fuelDistance.enabled = false;

            }
        }
        else
        {
            fuelDistance.enabled = false;
        }


    }

    private void FixedUpdate()
    {
        MoveMent(moveInput);
    }
    public void MoveMent(float moveInput)
    {
        frontTire.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        backTire.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        carBody.AddTorque(moveInput * rotationSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fuel"))
        {
            Destroy(collision.gameObject);
            GameObject.Find("GameManager").gameObject.GetComponent<FuelConrroller>().RefillFuel();
        }

        if(collision.gameObject.CompareTag("Coin"))
        {
            coinSoundSource.PlayOneShot(coinAudioSource);


        }
    }
    
}
