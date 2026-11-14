using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class kittyinbag : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 5f;
    public InputActionReference moving;
    public InputActionReference jumping;
    private Rigidbody2D rb;
    private ContactFilter2D contactFilter;
    private SpriteRenderer SpriteRenderer;
    public int fishCounter = 0;
    public int electricFishCounter = 0;
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI electricCounterText;
    public AudioSource electricFishCollect;
    public AudioSource commonFishCollect;
    public SpriteRenderer fishBag;
    public Sprite halfCapacityBag;
    public Sprite fullCapacityBag;
    public int totalFish = 0;
    public AudioSource loseSFX;
    public AudioSource BGMusic;
    public GameObject winScreen;
    public AudioSource winSFX;
    public GameObject loseScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        contactFilter.useNormalAngle = true;
        contactFilter.SetNormalAngle(70f, 120f);
        SpriteRenderer = GetComponent<SpriteRenderer>();
        counterText.text = "= " + fishCounter;
        electricCounterText.text = "= " + electricFishCounter;
        winScreen.SetActive(false);
        loseScreen.SetActive(false);

    }
    private void OnEnable()
    {
        moving.action.Enable();
        jumping.action.Enable();
    }
    private void OnDisable()
    {
        moving.action.Disable();
        jumping.action.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        totalFish = fishCounter + electricFishCounter;
        float jump = jumping.action.ReadValue<float>();

        bool isGrounded = rb.IsTouching(contactFilter);
        if (jumping.action.WasPressedThisFrame() && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        if (totalFish >= 5)
        {
            fishBag.sprite = halfCapacityBag;
        }
        if (totalFish >= 8)
        {
            fishBag.sprite = fullCapacityBag;
            winScreen.SetActive(true);
            BGMusic.Stop();
            if (!winSFX.isPlaying)
            {
                winSFX.Play();
            }
            moving.action.Disable();
            jumping.action.Disable();
            rb.linearVelocity = Vector2.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("commonfish")) 
        {
            Destroy(collision.gameObject);
            fishCounter += 1;
            counterText.text = "= " + fishCounter;
            commonFishCollect.Play();
        }
        if (collision.CompareTag("electricfish"))
        {
            Destroy(collision.gameObject);
            electricFishCounter += 1;
            electricCounterText.text = "= " + electricFishCounter;
            electricFishCollect.Play();
        }
        if (fishCounter == 5)
        {
            counterText.text = "MAX FISH!";
        }
        if (electricFishCounter == 3)
        {
            electricCounterText.text = "MAX FISH!";
        }
        if (collision.CompareTag("spike"))
        {
            loseSFX.Play();
            Destroy(gameObject);
            BGMusic.Stop();
            loseScreen.SetActive(true);
            moving.action.Disable();
            jumping.action.Disable();
            rb.linearVelocity = Vector2.zero;
        }
     




    }
    private void FixedUpdate()
    {
       
        
        float move = moving.action.ReadValue<Vector2>().x;

        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);
        
        if (move > 0)
        {
            SpriteRenderer.flipX = false;
        }

        if (move < 0)
        {
            SpriteRenderer.flipX = true;
        }


    }
 
}
