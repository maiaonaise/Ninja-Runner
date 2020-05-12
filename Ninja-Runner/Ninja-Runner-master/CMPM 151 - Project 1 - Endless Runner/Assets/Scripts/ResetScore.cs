using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    //Creates a variable that saves the initial score; 
    private int initScore = 0;

    //On the click of the button enter this function
    public void OnClick()
    {
        //reset the scoreValue within scorescript to 0
        ScoreScript.scoreValue = initScore;
    }
}