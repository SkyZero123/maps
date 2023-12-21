using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public float force;
    public GameObject projectiles;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectilesIns = Instantiate(projectiles, transform.position, transform.rotation);


        projectilesIns.GetComponent<Rigidbody2D>().velocity = transform.right * force;
    }
}
