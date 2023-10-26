using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class ShootPointScript : MonoBehaviour
{
    [SerializeField] private Transform _laser;
    [SerializeField] private float _laserDistance = 0.2f;
    [SerializeField] private float _timeBetweenFires = 0.3f;
    private float _timeTilNextFire = 0.0f;
    [SerializeField] private List<KeyCode> _shootButton;
    [SerializeField] private AudioClip _shootSound;

    void Update()
    {
        foreach (KeyCode element in _shootButton)
        {
            if (Input.GetKeyDown(element) && _timeTilNextFire < 0)
            {
                _timeTilNextFire = _timeBetweenFires;
                ShootLaser();
                break;
            }
        }
        _timeTilNextFire -= Time.deltaTime;
    }
    public void Cooldown()
    {
        if (_timeTilNextFire < 0)
        {
            _timeTilNextFire = _timeBetweenFires;
            ShootLaser();
        }
        _timeTilNextFire -= Time.deltaTime;
    }
    public void ShootLaser()
    {
        float posX = this.transform.position.x + (Mathf.Cos((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) * -_laserDistance);
        float posY = this.transform.position.y - 0.2f + (Mathf.Sin((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) * -_laserDistance);
        Instantiate(_laser, new Vector3(posX, posY, 0), this.transform.rotation);
        GetComponent<AudioSource>().PlayOneShot(_shootSound);
    }
}
