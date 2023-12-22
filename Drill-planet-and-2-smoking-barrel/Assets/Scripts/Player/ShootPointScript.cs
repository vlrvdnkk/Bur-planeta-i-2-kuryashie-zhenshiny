using System.Collections.Generic;
using UnityEngine;

public class ShootPointScript : MonoBehaviour
{
    [SerializeField] private Transform laser;
    [SerializeField] private float laserDistance = 0.2f;
    [SerializeField] private float timeBetweenFires = 0.3f;
    private float timeTilNextFire = 0.0f;
    [SerializeField] private List<KeyCode> shootButton;
    [SerializeField] private AudioClip shootSound;

    void Update()
    {
        foreach (KeyCode element in shootButton)
        {
            if (Input.GetKeyDown(element) && timeTilNextFire < 0)
            {
                timeTilNextFire = timeBetweenFires;
                ShootLaser();
                break;
            }
        }
        timeTilNextFire -= Time.deltaTime;
    }
    public void Cooldown()
    {
        if (timeTilNextFire < 0)
        {
            timeTilNextFire = timeBetweenFires;
            ShootLaser();
        }
        timeTilNextFire -= Time.deltaTime;
    }
    public void ShootLaser()
    {
        float posX = this.transform.position.x + (Mathf.Cos((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) * -laserDistance);
        float posY = this.transform.position.y - 0.2f + (Mathf.Sin((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) * -laserDistance);
        Instantiate(laser, new Vector3(posX, posY, 0), this.transform.rotation);
        GetComponent<AudioSource>().PlayOneShot(shootSound);
    }
}
