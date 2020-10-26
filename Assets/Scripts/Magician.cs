//
//Program: Player.cs
//Author: Edwin
//Date created: 1 March 2017
//Date modified: 3 March 2017
//Description: Handles magician character
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : Player
{
    // Update is called once per frame
    void Update ()
    {
        Move ();

        if(canFire)
        {
            StartCoroutine ("Shoot", audioSrc); 
        }
    }

    protected override void Move ()
    {
        float translate = horizontalSpeed * Input.GetAxis ("Player2") * Time.deltaTime;

        this.transform.Translate (new Vector3 (translate, 0, 0), Space.World);
        

        rotationY = Input.GetAxis ("Player2") * rotationSpeed;

        rotationY = Mathf.Clamp (rotationY, minRotation, maxRotation);

        this.transform.rotation = Quaternion.Euler (0, 0, -180 + rotationY);
    }

    public override void Hurt (int dmg)
    {
        health -= dmg;
        slider.value -= dmg;

        audioSrc.clip = hitAudio;
        audioSrc.Play ();

        if (health <= 0)
        {
            StartCoroutine ("KillPlayer", 0);

            //WinGame (0);
        }
    }
}
