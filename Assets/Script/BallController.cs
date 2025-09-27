using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    bool isLaunched = false;
    float randomScale = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * -speed;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && isLaunched == false)
        {
            rb.velocity += Vector3.up * -speed * 2;
            isLaunched = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Brick") {
            rb.velocity = Vector3.up * speed;

            Renderer rend = GetComponent<Renderer>();

            if (isLaunched)
            { 
                if(randomScale <= 1f)
                {
                    Destroy(collision.transform.parent.gameObject);
                    GameManager.Instance.AddScore(1);
                }
                else 
                {
                    GameManager.Instance.LoseLife();
                }
            }
            isLaunched = false;
            randomScale = Random.Range(0.5f, 1.5f);
            if (rend != null && randomScale <= 1f)
            {
                rend.material.color = Color.green;
            }
            else
            {
                rend.material.color = Color.red;
            }
            gameObject.GetComponent<Transform>().localScale = new Vector3(randomScale, randomScale, randomScale);

        }


    }
}
