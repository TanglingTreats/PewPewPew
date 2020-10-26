//
//Program: UIManager.cs
//Author: Edwin
//Date created: 2 March 2017
//Date modified: 3 March 2017
//Description: UIManager to handle UI events
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{   

    [SerializeField]
    private bool isVictoryScreen;

    [SerializeField]
    private GameObject mainCanvas, creditCanvas, instrCanvas = null;



	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(!isVictoryScreen)
        {
		    if(Input.GetKeyDown(KeyCode.A))
            {
                if(instrCanvas.activeInHierarchy)
                {
                    instrCanvas.SetActive (false);
                }
                else if(creditCanvas.activeInHierarchy)
                {
                    creditCanvas.SetActive (false);
                }
            }
        }
        
	}

    public void StartGame()
    {
        SceneManager.LoadScene (1);
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene (0);
    }

    public void LoadInstructions ()
    {
        instrCanvas.SetActive (true);
    }

    public void ViewCredits ()
    {
        creditCanvas.SetActive (true);
    }

    public void QuitGame ()
    {
        Application.Quit ();
    }

}
