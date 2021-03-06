using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumCleaner : MonoBehaviour
{   
    public PlayerShooting ps;
    public PlayerScrap psc;
    public PlayerHealthPoint php;
    public AudioManager am;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Vaccuming enemy bullet
    public void VacuumEnemyBullet(int ammoToAdd) {

        am.Play("SomethingIsVacuumed");

        if ( ps.GetAmmo() < ps.maxAmmo ) {
            // Add one amo in reserve
            ps.addAmmo(ammoToAdd);
        }
    }

    // Vaccuming enemy scrap
    public void VacuumScrap(int scrapToAdd, int HPGiven) {

        am.Play("SomethingIsVacuumed");

        // Add one scrap in reserve
        psc.AddScrap(scrapToAdd);
        php.Healing(HPGiven);
    }
}
