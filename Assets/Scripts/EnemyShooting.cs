using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public SpriteRenderer sr;
    public Gun[] guns ;

    public float fireDelay = 1.25f;

    private float cooldownTimer = 0f;
    private float enemyHalfHeight;

    // Start is called before the first frame update
    void Start()
    {
        enemyHalfHeight = sr.bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        Vector2 enemyPosition = transform.position;

        if( cooldownTimer <= 0 && enemyPosition.y + enemyHalfHeight < Camera.main.orthographicSize ) {
            Shoot();
        }
    }

    private void Shoot() {
        cooldownTimer = fireDelay;

        foreach (Gun gun in guns)
        {   
            Vector2 startPosition = gun.gun.transform.position;
            
            startPosition.y += gun.bullet.GetComponent<SpriteRenderer>().bounds.extents.y * Mathf.Cos(gun.gun.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
            startPosition.x += gun.bullet.GetComponent<SpriteRenderer>().bounds.extents.y * -Mathf.Sin(gun.gun.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
            
            Instantiate( gun.bullet, startPosition, gun.gun.transform.rotation );
        }
    }
}
