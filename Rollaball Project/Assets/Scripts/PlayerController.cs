using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI starText;
    public GameObject winTextObject;
    public GameObject star;
    public float clubForce = 5000.0f;

    private Rigidbody rb;
    private int count;
    private int bits;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        bits = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    void SetStarText()
    {
        starText.text = "Star Bits X " + bits.ToString();
        if (bits >= 12 && star != null)
        {
            star.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        } else if (other.gameObject.CompareTag("StarBit"))
        {
            other.gameObject.SetActive(false);
            bits = bits + 1;

            SetStarText();
        } else if (other.gameObject.CompareTag("Star"))
        {
            gameObject.GetComponent<AudioSource>().clip = star.GetComponent<AudioSource>().clip;
            gameObject.GetComponent<AudioSource>().Play();
            star.SetActive(false);
        } else if (other.gameObject.CompareTag("Club"))
        {
            // By subtracting the transform of the club off of the transform of the ball we find the vector from the club to the ball. Then apply a force in that direction to push the ball that way!
            rb.AddForce((transform.position - other.gameObject.transform.position) * clubForce);
        }
    }
}            
