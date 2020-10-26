//
//Program: Laser.cs
//Author: Edwin
//Date created: 1 March 2017
//Date modified: 3 March 2017
//Description: Laser class for scientist
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : ProjectileBase
{
    [SerializeField]
    private bool canDestroy;

	// Update is called once per frame
	void Update ()
    {
        Move ();
    }


    protected override void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.CompareTag("Magician"))
        {

            col.GetComponent<Player> ().Hurt (damage);
            Destroy (this.gameObject);
        }

        if (col.gameObject.CompareTag("Wall"))
        {
            Destroy (this.gameObject);
        }

        if (col.gameObject.CompareTag("Magicball"))
        {
            if(canDestroy)
            {
                col.GetComponent<Magicball> ().DestroyBall ();
            }
            else
            {
                //Do nothing
            }
        }

    }
}
