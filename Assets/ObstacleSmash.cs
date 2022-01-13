using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ObstacleSmash : MonoBehaviour
{
    
    int score; 
    public Text ScoreText; 


    void OnMouseDown()
    {
        Destroy(gameObject); 
        score++; 
        ScoreText.text = score.ToString(); 
    }
}
