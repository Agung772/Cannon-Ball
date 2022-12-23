using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CannonController : MonoBehaviour
{
    [Range(0f, 100f)]
    public float rotationSpeed;
    public float xDegrees, yDegrees;

    public Transform cannonBody;

    [Space]
    public float shootForce;
    public GameObject cannonPrefab;
    public Transform shootPoint;
    void Update()
    {
        Move();
        Shooter();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        yDegrees += horizontalInput * rotationSpeed * Time.deltaTime;
        xDegrees += verticalInput * rotationSpeed * Time.deltaTime;

        cannonBody.localEulerAngles = new Vector3(0, xDegrees, yDegrees);

        yDegrees = Mathf.Clamp(yDegrees, -50, 50);
        xDegrees = Mathf.Clamp(xDegrees, -5, 35);
    }

    //--------------------------------------------------------------------------------------------------------------------

    void Shooter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CurrentAmmo <= 0) return;

            GameObject cannonBall =  Instantiate(cannonPrefab, shootPoint.position, shootPoint.rotation);
            cannonBall.GetComponent<Rigidbody>().AddForce(cannonBall.transform.forward * shootForce, ForceMode.Impulse);
            CurrentAmmo--;
        }
    }

    //--------------------------------------------------------------------------------------------------------------------

    [Space]
    public int totalAmmo;
    public int currentAmmo;
    public TextMeshProUGUI ammonText;


    public int CurrentAmmo
    {
        get
        {
            return currentAmmo;
        }

        set
        {
            currentAmmo = value;
            print("Ammo : " + currentAmmo);

            ammonText.text = "Ammo : " + currentAmmo + " / " + totalAmmo;

            if(currentAmmo <= 0 && GameManager.instance.fallenBrickAmount < GameManager.instance.fallenBrickNeeded)
            {
                GameManager.level = 1;
                print("YOU LOSE");
                GameManager.instance.RestratGame();
            }
        }
    }

    private void Start()
    {
        GameManager.instance.setAmmo += SetAmmo;
    }

    private void OnDisable()
    {
        GameManager.instance.setAmmo -= SetAmmo;
    }
    void SetAmmo()
    {
        totalAmmo = GameManager.instance.fallenBrickNeeded / 3;

        currentAmmo = totalAmmo;

        ammonText.text = "Ammo : " + currentAmmo + " / " + totalAmmo;
    }
}
