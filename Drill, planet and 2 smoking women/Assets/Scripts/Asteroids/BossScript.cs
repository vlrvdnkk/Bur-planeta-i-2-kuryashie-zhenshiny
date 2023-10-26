using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class BossScript : MonoBehaviour
{
    public int health = 100;
    //[SerializeField] private Animator anim;
    [SerializeField] private Transform _explosion;
    [SerializeField] private AudioClip _hitSound;
    public int _BSenergy = 50;
    private void Start()
    {
        HpBar hp = GameObject.Find("HPbarBase").GetComponent("HpBar") as HpBar;
        hp.BossBarMax(health);
    }

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.name.Contains("laser"))
        {
            LaserScript laser = theCollision.gameObject.GetComponent("LaserScript") as LaserScript;
            health -= laser.damage;
            Shoot();
        }
        if (theCollision.gameObject.name.Contains("laserA"))
        {
            LaserScript laser = theCollision.gameObject.GetComponent("LaserScript") as LaserScript;
            health -= laser.damageA;
            Shoot();
        }
        if (theCollision.gameObject.name.Contains("laserB"))
        {
            LaserScript laser = theCollision.gameObject.GetComponent("LaserScript") as LaserScript;
            health -= laser.damageB;
            Shoot();
        }
        if (theCollision.gameObject.name.Contains("cannon base") | theCollision.gameObject.name.Contains("observatory"))
        {
            if (_explosion)
            {
                GameObject exploder = ((Transform)Instantiate(_explosion, this.transform.position, this.transform.rotation)).gameObject;
                Destroy(exploder, 2.0f);
            }
            //anim.SetBool("death", true);
            Destroy(this.gameObject);
            GameController controller = GameObject.Find("GameController").GetComponent("GameController") as GameController;
            HpBar controllerhp = GameObject.Find("HPbarBase").GetComponent("HpBar") as HpBar;
            controller.currentNumberOfEnemies -= controller.enemiesPerWave;
            controllerhp.DamagePlayer(100);
            HpBar hp = GameObject.Find("HPbarBase").GetComponent("HpBar") as HpBar;
            hp.BossBar(0);
        }
        if (health <= 0)
        {
            if (_explosion)
            {
                GameObject exploder = ((Transform)Instantiate(_explosion, this.transform.position, this.transform.rotation)).gameObject;
                Destroy(exploder, 2.0f);
            }
            //anim.SetBool("death", true);
            Destroy(this.gameObject);
            GameController controller = GameObject.Find("GameController").GetComponent("GameController") as GameController;
            controller.currentNumberOfEnemies -= controller.enemiesPerWave;
            controller.IncreaseScore(_BSenergy);
        }
        void Shoot()
        {
            Destroy(theCollision.gameObject);
            GetComponent<AudioSource>().PlayOneShot(_hitSound);
            HpBar hp = GameObject.Find("HPbarBase").GetComponent("HpBar") as HpBar;
            hp.BossBar(health);
        }
    }
}