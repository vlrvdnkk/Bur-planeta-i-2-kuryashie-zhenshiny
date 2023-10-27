using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooting : MonoBehaviour
{
    [SerializeField] private Transform _laser;
    [SerializeField] private float _laserDistance = 0.2f;
    [SerializeField] private float _timeBetweenFires = 0.3f;
    private float _timeTilNextFire = 0.0f;
    [SerializeField] private AudioClip _shootSound;

    void Update()
    {
        if (_timeTilNextFire < 0)
        {
            _timeTilNextFire = _timeBetweenFires;
            ShootLaser();
        }
        _timeTilNextFire -= Time.deltaTime;
    }
    void ShootLaser()
    {
        float posX = this.transform.position.x + (Mathf.Cos((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) * -_laserDistance);
        float posY = this.transform.position.y - 0.2f + (Mathf.Sin((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) * -_laserDistance);
        Instantiate(_laser, new Vector3(posX, posY, 0), this.transform.rotation);
        GetComponent<AudioSource>().PlayOneShot(_shootSound);
    }
}