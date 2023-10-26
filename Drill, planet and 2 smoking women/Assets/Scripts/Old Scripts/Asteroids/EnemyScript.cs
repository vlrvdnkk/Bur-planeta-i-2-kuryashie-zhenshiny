using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class EnemyScript : MonoBehaviour
{
    public int health = 2;
    //[SerializeField] private Animator anim;
    [SerializeField] private Transform _explosion;
    [SerializeField] private AudioClip _hitSound;
    public int _energy = 10;

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
        if (theCollision.gameObject.name.Contains("Drill"))
        {
            if (_explosion)
            {
                GameObject exploder = Instantiate(_explosion, this.transform.position, this.transform.rotation).gameObject;
                Destroy(exploder, 2.0f);
            }
            //anim.SetBool("death", true);
            //Destroy(this.gameObject);
            //GameController controller = GameObject.Find("GameController").GetComponent("GameController") as GameController;
            HpBar controllerhp = GameObject.Find("HPbarBase").GetComponent("HpBar") as HpBar;
            //controller.KilledEnemy();
            damage:
            controllerhp.DamagePlayer(1);
            StartCoroutine(Timer());
            goto damage;
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
            controller.KilledEnemy();
            controller.IncreaseScore(_energy);
        }
        void Shoot()
        {
            Destroy(theCollision.gameObject);
            GetComponent<AudioSource>().PlayOneShot(_hitSound);
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
    }
}