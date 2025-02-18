using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;
public class BallCode : MonoBehaviour
{
    //int score = 0;
    private int speed = 10;
    public TextMeshProUGUI scoreText;
    private Vector3 originalScale;
    public AudioClip hitSound2;
    public AudioClip hitSound;
    public AudioClip loseSound;
    public AudioClip winSound;

    AudioSource audioSource;

    //another class in the other file - two classes talking to each other
    BGColor bg;

    Rigidbody2D rb;

    IEnumerator LoadGameOverAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameOver");
    }
    

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }


    void Start()
    {
        InputSystem.EnableDevice(Accelerometer.current);

        bg = FindAnyObjectByType<BGColor>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(200, -200));
        
        scoreText.text = "Score: 0";
        originalScale = transform.localScale;
    }

    void Update(){
        Vector2 accel = Accelerometer.current.acceleration.ReadValue();
        rb.AddForce(accel * speed);
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(horizontalInput * speed, 0));
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Brick")){
            audioSource.PlayOneShot(hitSound);
            //calling the StartFade() method from the other class to change bg color
            bg.StartFade();
            PublicVars.score += 10;
            scoreText.text = "Score: " + PublicVars.score;
            Destroy(other.gameObject);
            
        }
        if(other.gameObject.CompareTag("Brick 2.0")){
            audioSource.PlayOneShot(hitSound2);
            bg.StartFade();
            PublicVars.score += 20;
            scoreText.text = "Score: " + PublicVars.score;
            Destroy(other.gameObject);
        }
        
        if(other.gameObject.CompareTag("Bottom")){
            bg.GameEnd();
            StartCoroutine(LoadGameOverAfterDelay());
            audioSource.PlayOneShot(loseSound);
        }
        
        if(GameObject.FindGameObjectsWithTag("Brick 2.0").Length < 1 
           && GameObject.FindGameObjectsWithTag("Brick").Length < 1){
                
                SceneManager.LoadScene("Win");
                audioSource.PlayOneShot(winSound);

        }
    }
    
}
