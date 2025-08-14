using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class PlayerMovement : MonoBehaviour

{
    private Rigidbody rb;
    private Animator playerAnim;
    public float jumpForce = 10f;
    public float gravityModifier;
    public bool isGround = true;
    public bool gameOver;

    public float Delay = 3f;

    private AudioSource audioPlayer;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    
   public  float timer = 0f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0);
    }

    void Update()
    {
        // PC support (Space key)
            if (Input.GetKeyDown(KeyCode.Space) && isGround && !gameOver)
            {
                Jump();
            }



        // Exit on Escape (for testing in PC)
        if (gameOver && Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Quitting the game...");
                Application.Quit();
            }
        }


    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGround = false;
        playerAnim.SetTrigger("Jump_trig");
        dirtParticle.Stop();
        audioPlayer.PlayOneShot(jumpSound);
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GameOver");
            gameOver = true;
          
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            audioPlayer.PlayOneShot(crashSound);
            restart();
            }

        }
    public void restart()
    {
        StartCoroutine(RestartAfterDelay());
    }

    IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(Delay); // Wait for 3 seconds
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }



}


