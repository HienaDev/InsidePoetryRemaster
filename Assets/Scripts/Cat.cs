using UnityEngine;
using UnityEngine.Audio;

public class Cat : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; // Speed of the object
    [SerializeField] private Transform positionA;
    [SerializeField] private Transform positionB;
    [SerializeField] private AudioMixerGroup audioMixer;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private bool flipped = false;
    private Vector2 velocity;

    [SerializeField] private AudioClip catSound;
    private AudioSource catSource;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        catSource = gameObject.AddComponent<AudioSource>();
        catSource.volume = 0.1f;
        catSource.clip = catSound;
        catSource.outputAudioMixerGroup = audioMixer;

        velocity = new Vector2(moveSpeed, 0);

        rb.velocity = velocity;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        

        if (transform.position.x <= positionA.position.x && !flipped)
        {
            velocity *= -1;
            spriteRenderer.flipX = false;
            flipped = true;
        }
        else if(transform.position.x >= positionB.position.x && !flipped)
        {
            velocity *= -1;
            spriteRenderer.flipX = true;
            flipped = true; 
        }

        if (transform.position.x > positionA.position.x && transform.position.x < positionB.position.x && flipped)
        {
            flipped = false;
        }

        rb.velocity = velocity;
    }


    private void CatSound()
    {
        catSource.pitch = Random.Range(0.1f,2f);
        catSource.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        CatSound();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(positionA.position, 3f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(positionB.position, 3f);
    }

}
