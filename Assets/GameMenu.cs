using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameMenu : MonoBehaviour
{

    public GameObject gameMenuPanel; 
    public GameObject playerPanel; 

    // Update is called once per frame
    void Update()
    {

    }

    public void Restart()
    {
        SceneManager.LoadScene("Game"); 
       // gameMenuPanel.SetActive(false); 
       // playerPanel.SetActive(true); 
        
    }

}
