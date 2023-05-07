using TMPro;
using UnityEngine;

public class DaggerScript : MonoBehaviour
{
    [SerializeField] private GameObject dagger;
    
    public float daggerSpeed;
    private Rigidbody2D spawnedDaggerRb;
    private bool hasFired = false;
    private static int numberOfDaggers;
    
    [SerializeField] private GameObject directionHelper;
    [SerializeField] private TextMeshProUGUI daggerAmntText;
    [SerializeField] private AudioClip daggerSound;
    private AudioSource soundManager;

    private void Awake()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        numberOfDaggers = 0;
        daggerAmntText.text = numberOfDaggers.ToString();
    }

    //Update is used for input from player
    private void Update()
    {
        daggerAmntText.text = numberOfDaggers.ToString();
        RotateDirectionHelper();
        if (Input.GetKeyDown(KeyCode.F) && numberOfDaggers > 0)
        {
            soundManager.PlayOneShot(daggerSound);
            TakeAwayDagger();
            hasFired = true;
        }
    }

    public static void AddDagger()
    {
        if (numberOfDaggers < 5)
        {
            numberOfDaggers++;
            print(numberOfDaggers);
        }
    }

    private void TakeAwayDagger()
    {
        numberOfDaggers--;
        print(numberOfDaggers);
    }

    private void RotateDirectionHelper()
    {
        //If left
        if (Input.GetAxis("Horizontal") < 0)
        {
            directionHelper.transform.localRotation = Quaternion.Euler(0, 0f, -90f);
        }
        else if (Input.GetAxis("Horizontal") > 0) //If right
        {
            directionHelper.transform.localRotation = Quaternion.Euler(0, 0f, 90f);
        }
        else if (Input.GetAxis("Vertical") < 0) //If down
        {
            directionHelper.transform.localRotation = Quaternion.Euler(0, 0f, 0f);
        }
        else if (Input.GetAxis("Vertical") > 0) //if up
        {
            directionHelper.transform.localRotation = Quaternion.Euler(0, 0f, 180f);
        }
    }

    //Fixed Update used for physics of dagger
    void FixedUpdate()
    {
        if (hasFired)
        {
            var spawnedDagger = Instantiate(dagger, transform.position, Quaternion.identity);
            spawnedDaggerRb = spawnedDagger.GetComponent<Rigidbody2D>();
            
            //If left
            if (directionHelper.transform.localRotation == Quaternion.Euler(0f,0f,-90f))
            {
                spawnedDaggerRb.velocity = Vector2.left * (daggerSpeed * Time.fixedDeltaTime);
                spawnedDagger.transform.rotation = Quaternion.Euler(0f, 0f, 90f);        
            }
            //If right
            if (directionHelper.transform.localRotation == Quaternion.Euler(0f,0f,90f)) 
            {
                spawnedDaggerRb.velocity = Vector2.right * (daggerSpeed * Time.fixedDeltaTime);
                spawnedDagger.transform.rotation = Quaternion.Euler(0f, 0f, -90f);        
            }
            
            //If down
            if (directionHelper.transform.localRotation == Quaternion.Euler(0f,0f,0f))
            {
                spawnedDaggerRb.velocity = Vector2.down * (daggerSpeed * Time.fixedDeltaTime);
                spawnedDagger.transform.rotation = Quaternion.Euler(0f, 0f, 180f);        
            }
            
            //If up
            if (directionHelper.transform.localRotation == Quaternion.Euler(0f,0f,180f))
            {
                spawnedDaggerRb.velocity = Vector2.up * (daggerSpeed * Time.fixedDeltaTime);
                spawnedDagger.transform.rotation = Quaternion.Euler(0f, 0f, 0f);        
            }
            
            Destroy(spawnedDagger, 4f);
            hasFired = false;
        }
    }
    
    //REFERENCES//
    /***************************************************************************************
    *    Title: How to make 2D Top Down Movement (Brackeys/Continued)(Unity Tutorial)
    *    Author: JTA Games
    *    Date: September 24, 2020
    *    Code version: Unknown
    *    Availability: https://www.youtube.com/watch?v=fRpoE4FfJf8&t=1s
    *
    ***************************************************************************************/
}
