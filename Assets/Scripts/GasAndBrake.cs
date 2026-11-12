using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GasAndBrake : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Texture tapped;
    [SerializeField] private Texture defaultTexture;
    [SerializeField] private CarDriver carDriver;
    [SerializeField] private FuelConrroller fuelConrroller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void OnButtonDown()
    {
        gameObject.GetComponent<RawImage>().texture = tapped;
        if (gameObject.CompareTag("gas") && fuelConrroller.currentFuel>0)
        {
            carDriver.SetMoveInput(1f);
        }

        if (gameObject.CompareTag("brake"))
        {
            carDriver.SetMoveInput(-1f);
        }
    }
    public void OnButtonUp()
    {
        gameObject.GetComponent<RawImage>().texture = defaultTexture;
        carDriver.SetMoveInput(0);

    }
}
