using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    public float speed;
    public float smooth = 2.0F;
    public float tiltAngle = 40.0F;
    public Transform boltspawn;
    public GameObject shot;
    private float timedil = 0.2F;
    private float timepassed = 0.0F;
    void Update()
    {
        if(Input.GetButton("Fire1") && timepassed < Time.time)
        {
            GameObject clone = Instantiate(shot, boltspawn.position, boltspawn.rotation);
            timepassed = Time.time + timedil;
            rb.GetComponent<AudioSource>().Play();
        }
        
    }

    void FixedUpdate()
    {
        float moveHortizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHortizontal, 0.0F, moveVertical);
        rb.velocity = movement * speed;
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
        Quaternion target = Quaternion.Euler(-tiltAroundX, 0, -tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
