//
//Program: ProjectileBase.cs
//Author: Edwin
//Date created: 1 March 2017
//Date modified: 3 March 2017
//Description: Projectile base class
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [SerializeField]
    protected int damage;

    [SerializeField]
    protected float travelSpeed;

    // Use this for initialization
    protected void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    protected virtual void Move ()
    {
        this.transform.Translate (Vector2.up * travelSpeed * Time.deltaTime, Space.Self);
    }

    protected virtual void OnTriggerEnter2D (Collider2D col) { /*Do something here*/ }

    public void SetDamage (int dmg)
    {
        damage = dmg;
    }

}
