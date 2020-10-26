//
//Program: Magicball.cs
//Author: Edwin
//Date created: 1 March 2017
//Date modified: 3 March 2017
//Description: Magicball class for magician
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magicball : ProjectileBase
{
    private int bounceCount = 0;

    private float currentRot;
    private float rotation = 0.0f;
    private float finalRot;

    [SerializeField]
    private AudioSource audioSrc;

    [SerializeField]
    private bool isBouncing;

    [SerializeField]
    private Transform ballTrans;

	// Update is called once per frame
	void Update ()
    {
        Move ();
        CheckBounce ();
	}


    protected override void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.CompareTag ("Scientist"))
        {
            col.GetComponent<Player> ().Hurt (damage);
            Destroy (this.gameObject);
        }

        if (col.gameObject.CompareTag ("Wall"))
        {
            if(isBouncing)
            {

                if(col.transform.position.x < 0 && col.transform.position.y == 0)
                {
                    Vector2 outVect = Vector2.Reflect (this.transform.position, Vector2.right);

                    rotation = Vector2.Angle (this.transform.position, outVect);

                    currentRot = this.transform.rotation.z;

                    finalRot = currentRot - rotation;

                    this.transform.rotation = Quaternion.Euler (0, 0, finalRot);
                    
                }
                else if (col.transform.position.x > 0 && col.transform.position.y == 0)
                {
                    Vector2 outVect = Vector2.Reflect (this.transform.position, Vector2.left);

                    rotation = Vector2.Angle (this.transform.position, outVect);
                    
                    currentRot = this.transform.rotation.z;

                    finalRot = currentRot + rotation;

                    this.transform.rotation = Quaternion.Euler (0, 0, finalRot);
                    
                }
                else if (col.transform.position.x == 0 && col.transform.position.y > 0)
                {
                    Vector2 outVect = Vector2.Reflect (this.transform.position, Vector2.down);

                    rotation = Vector2.Angle (this.transform.position, outVect);
                    
                    currentRot = this.transform.rotation.z;

                    finalRot = rotation - currentRot;

                    this.transform.rotation = Quaternion.Euler (0, 0, finalRot);
                    
                }
                else if (col.transform.position.x == 0 && col.transform.position.y < 0)
                {
                    Vector2 outVect = Vector2.Reflect (this.transform.position, Vector2.up);
                    

                    this.transform.rotation = Quaternion.Euler (outVect);

                }

                bounceCount++;
                audioSrc.Play ();
            }
            else
            {
                Destroy (this.gameObject);
            }
            
        }
    }

    void CheckBounce ()
    {
        if (bounceCount == 2)
        {
            Destroy (this.gameObject);
        }
    }

    public void DestroyBall ()
    {
        Destroy (this.gameObject);
    }
}
