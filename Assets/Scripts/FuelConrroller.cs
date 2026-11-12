using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FuelConrroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static FuelConrroller Instance;

    [SerializeField] private Image fuelBar;
    [SerializeField,Range(0.1f,5f) ] private float fuelRate=5f;
    [SerializeField] private Gradient fuelGradient;
    [SerializeField] private float maxFuel=100f;
    [SerializeField] private AudioClip refillSound;
    [SerializeField] private AudioSource refillSoundSource;
    [SerializeField] private Rigidbody2D vehicle;
    [SerializeField] private CarDriver carDriver;
    public float currentFuel;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        currentFuel = maxFuel;
        UpdateFuel();
    }

    private void UpdateFuel()
    {
        fuelBar.fillAmount = currentFuel / maxFuel;
        fuelBar.color = fuelGradient.Evaluate(fuelBar.fillAmount);
    }
    void Update()
    {
        if (currentFuel>0)
        {
            currentFuel -= fuelRate * Time.deltaTime;
            UpdateFuel();
        }

        if(currentFuel<=0)
        {
            carDriver.StopMoveInput();
            currentFuel =0;
            if (vehicle.linearVelocity.x == 0)
            {

            GameManager.Instance.GameOver();
            }
            StartCoroutine(GameOverAfter2Sec());
        }
    }

    private IEnumerator GameOverAfter2Sec()
    {
        yield return new WaitForSeconds(2);
        if(currentFuel <= 0)
        {
            GameManager.Instance.GameOver();
        }
        
    }

   
    public void RefillFuel()
    {
        currentFuel = maxFuel;
        refillSoundSource.PlayOneShot(refillSound);
        UpdateFuel();
    }
}
