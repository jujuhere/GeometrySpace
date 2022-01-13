using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
using UnityEngine.Advertisements; 

public class Player : MonoBehaviour
{

    Rigidbody2D rb; 
    public float moveSpeed; 
    int score; 
    public Text ScoreText; 

    #if UNITY_IOS
    private string gameId = "4142006";
    #elif UNITY_ANDROID
    private string gameId = "4142007";
    #endif
    bool testMode = false;
    


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }



    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Ads service:
        Advertisement.Initialize(gameId, testMode);
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButton(0))
       {
           rb.AddForce(new Vector3(0, 200, 0));
       }

        // (0, 38, 0)
        
    

    }

    private void FixedUpdate()
    {
        rb.velocity = -transform.up * moveSpeed; 
        if(Input.GetMouseButtonUp(0)){
            rb.velocity *= 0.25f; 
        }
    } 


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject); 
            score++; 
            ScoreText.text = score.ToString(); 


          /*  if(score >= 5)
            {
                print("Level Complete"); 
                winText.SetActive(true); 
            }
        */ 

            
        }
        else if(collision.gameObject.tag == "Danger")
        {
           // SceneManager.LoadScene("Game");
           Destroy(this.gameObject); 
           ShowInterstitialAd(); 
          
        }
    }

    public void ShowInterstitialAd() {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady("Interstitial_Android")) {
            Advertisement.Show("Interstitial_Android");
         // Replace mySurfacingId with the ID of the placements you wish to display as shown in your Unity Dashboard.
        } 
        else {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }

    
}
