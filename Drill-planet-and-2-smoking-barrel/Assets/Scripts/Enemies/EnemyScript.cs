using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    public int Health = 2;
    public int Energy = 10;
    [SerializeField] private Transform explosion;
    [SerializeField] private AudioClip hitSound;

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.name.Contains("laser"))
        {
            LaserScript laser = theCollision.gameObject.GetComponent("LaserScript") as LaserScript;
            Health -= laser.Damage;
            Shoot();
        }
        if (theCollision.gameObject.name.Contains("Drill"))
        {
            if (explosion)
            {
                GameObject exploder = Instantiate(explosion, this.transform.position, this.transform.rotation).gameObject;
                Destroy(exploder, 2.0f);
            }

            StartCoroutine(DamagePlayerPeriodically());
        }
        if (Health <= 0)
        {
            if (explosion)
            {
                GameObject exploder = ((Transform)Instantiate(explosion, this.transform.position, this.transform.rotation)).gameObject;
                Destroy(exploder, 2.0f);
            }
            Destroy(this.gameObject);
            GameController controller = GameObject.Find("GameController").GetComponent("GameController") as GameController;
            controller.KilledEnemy();
            controller.IncreaseScore(Energy);
        }
        void Shoot()
        {
            Destroy(theCollision.gameObject);
            GetComponent<AudioSource>().PlayOneShot(hitSound);
        }
    }

    private IEnumerator DamagePlayerPeriodically()
    {
        HpBar controllerhp = GameObject.Find("HPbarBase").GetComponent("HpBar") as HpBar;
        while (true)
        {
            controllerhp.DamagePlayer(1);
            yield return new WaitForSeconds(3);
        }
    }
}