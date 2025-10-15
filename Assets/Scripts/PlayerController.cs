using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    Rigidbody playerRb;
    Animator playerAnim;
    AudioSource playerAudio;
    public GameObject gameOverPanel;
    readonly int JUMP_TRIG = Animator.StringToHash("Jump_trig");
    readonly int DEATH_BOOL = Animator.StringToHash("Death_b");
    readonly int DEATH_TYPE = Animator.StringToHash("DeathType_int");
    void Start()
    {
        gameOverPanel.SetActive(false);
        playerRb = GetComponent<Rigidbody>();
        if (playerRb == null)
        {
            Debug.LogWarning("none RB!");
        }
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity = new Vector3(0, gravityModifier, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) 
            && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce,
                ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger(JUMP_TRIG);
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("OBSTACLE"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool(DEATH_BOOL, true);
            playerAnim.SetInteger(DEATH_TYPE, 1);
            gameOverPanel.SetActive(true);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
