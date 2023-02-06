using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject weaponLogic;
    public Rigidbody bulletPrefab;

    public float shootSpeed = 30;

    public float speed;

    public float lastAttackTime = 0f;

    public float fireRate;

 
    public Heath Player { get; private set; }
 

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Heath>();





    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time - lastAttackTime >= 1f / fireRate)
        {
            FacePlayer();
            shootBullet();
            lastAttackTime = Time.time;
        }


    }

    public void Enableshoot()
    {
        weaponLogic.SetActive(true);

        if (Time.time - lastAttackTime >= 1f / fireRate)
        {
            FacePlayer();
            shootBullet();
            lastAttackTime = Time.time;
        }



    }
    public void Disableshoot()
    {
        weaponLogic.SetActive(false);
    }
    public void FacePlayer()
    {
        if (Player == null) { return; }

        Vector3 lookPos = Player.transform.position - transform.position;
        lookPos.y = 0f;

        transform.rotation = Quaternion.LookRotation(lookPos);
    }

   

    void shootBullet()
    {
        var projectile = Instantiate(bulletPrefab, transform.position, transform.rotation);
        //Shoot the Bullet in the forward direction of the player
        //projectile.velocity = transform.forward * shootSpeed;
        projectile.GetComponent<Rigidbody>().velocity = transform.forward * shootSpeed;
    }
}
