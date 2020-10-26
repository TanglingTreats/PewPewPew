//
//Program: GameManager.cs
//Author: Edwin
//Date created: 2 March 2017
//Date modified: 3 March 2017
//Description: Game Manager to control manager
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player magician, scientist;

    [SerializeField]
    private Text countdownText;

	// Use this for initialization
	void Start ()
    {
        magician.enabled = false;
        scientist.enabled = false;

        StartCoroutine ("Countdown");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator Countdown()
    {
        countdownText.text = "3";

        yield return new WaitForSeconds (1f);

        countdownText.text = "2";

        yield return new WaitForSeconds (1f);

        countdownText.text = "1";

        yield return new WaitForSeconds (1f);

        countdownText.text = "Start!";
        magician.enabled = true;
        scientist.enabled = true;

        StopCoroutine ("Countdown");
    }
}
