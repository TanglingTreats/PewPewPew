//
//Program: Player.cs
//Author: Edwin
//Date created: 2 March 2017
//Date modified: 3 March 2017
//Description: Handles characters in the game
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    protected Transform spawnPoint;

    protected Vector3 originalRotation;

    protected AudioSource audioSrc;

    protected bool canFire;

    protected float rotationY;

    [SerializeField]
    protected GameObject bullet;

    [SerializeField]
    protected int health;

    [SerializeField]
    protected float minRotation, maxRotation;

    [SerializeField]
    protected float horizontalSpeed, rotationSpeed;

    [SerializeField]
    protected float minPitch, maxPitch;

    [SerializeField]
    protected float rateOfFire;

    [SerializeField]
    protected AudioClip shootAudio, hitAudio, dieSound;

    [SerializeField]
    protected Slider slider;

    [SerializeField]
    protected GameObject explosionGO;

    // Use this for initialization
    protected void Start ()
    {
        spawnPoint = this.transform.GetChild (0).transform;

        audioSrc = this.GetComponent<AudioSource> ();

        canFire = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    protected virtual void Move () { /* To be overwritten in derived classes*/ }


    protected IEnumerator Shoot (AudioSource audioSrc)
    {
        canFire = false;

        audioSrc.clip = shootAudio;
        audioSrc.Play ();
        audioSrc.pitch = Random.Range (minPitch, maxPitch);

        //Instantiate bullet here.
        Instantiate (bullet, spawnPoint.position, this.GetComponent<Transform> ().rotation);

        yield return new WaitForSeconds (rateOfFire);


        canFire = true;
    }


    public virtual void Hurt (int dmg) { /*Do something here*/ }

    protected IEnumerator KillPlayer (int opt)
    {
        StopCoroutine ("Shoot");

        this.GetComponent<Collider2D> ().enabled = false;
        this.GetComponent<SpriteRenderer> ().enabled = false;
        Instantiate (explosionGO, this.transform.position, Quaternion.identity);

        ProjectileBase[] bullets = GameObject.FindObjectsOfType<ProjectileBase>();
        for(int i = 0; i < bullets.Length; i++)
        {
            bullets[i].SetDamage (0);
        }

        audioSrc.clip = dieSound;
        audioSrc.priority = 129;
        audioSrc.Play ();

        switch (opt)
        {
            //Science victory
            case 0:
                
                GameObject.FindGameObjectWithTag ("Scientist").GetComponent<Player> ().StopCoroutine ("Shoot");

                break;

            //Magic victory
            case 1:

                GameObject.FindGameObjectWithTag ("Magician").GetComponent<Player> ().StopCoroutine ("Shoot");

                break;
        }


        yield return new WaitForSeconds (4f);

        Destroy (gameObject);

        switch (opt)
        {
            //Science victory
            case 0:
                SceneManager.LoadScene (2);

                break;

            //Magic victory
            case 1:
                SceneManager.LoadScene (3);

                break;
        }
    }

    protected void WinGame (int opt)
    {
        switch (opt)
        {
            //Science victory
            case 0:
                SceneManager.LoadScene (2);

                break;
            
            //Magic victory
            case 1:
                SceneManager.LoadScene (3);

                break;
        }
    }

    public int GetHealth ()
    {
        return health;
    }
}
