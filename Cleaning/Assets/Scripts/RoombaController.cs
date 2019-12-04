using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaController : MonoBehaviour
{
    Rigidbody2D rb;
    Rigidbody2D rbArrow;
    private float speed;
    Vector2 StartPos;
    Vector2 nowPos;
    Vector2 arrowDirection;
    Vector2 prevPos;
    Vector3 arrowScale;
    public GameObject arrow;
    public GameObject gauge;

    AudioSource audioSource;

    public AudioClip collSound;
    public AudioClip pickTrash;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rbArrow = arrow.gameObject.GetComponent<Rigidbody2D>();
        audioSource = this.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = this.transform.position.x - prevPos.x;
        float y = this.transform.position.y - prevPos.y;

        Vector2 vec = new Vector2(x, y).normalized;

        if (System.Math.Abs(rb.velocity.magnitude) < 1.0f)
        {

            if (Input.GetMouseButtonDown(0))
            {
                this.StartPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                arrow.SetActive(false);
                Vector2 EndPos = Input.mousePosition;
                Vector2 startDirction = -1 * (EndPos - StartPos).normalized;
                this.rb.AddForce(startDirction * speed);



            }
            else if (Input.GetMouseButton(0))
            {
                arrow.SetActive(true);
                arrowScale = rbArrow.transform.localScale;
                nowPos = Input.mousePosition;
                arrowDirection = -1 * (nowPos - StartPos).normalized;
                rbArrow.transform.up = -1 * arrowDirection;
                arrowScale.y = (nowPos - StartPos).magnitude * 0.1f;

                if (arrowScale.y >= 25f)
                {
                    arrowScale.y = 25f;
                    StartCoroutine(vib());
                }

                this.speed = (nowPos - StartPos).magnitude * 2f;
                if (this.speed > 1000)
                {
                    this.speed = 1000;
                }

                rbArrow.transform.localScale = arrowScale;
            }
        }


            //摩擦力
            rb.velocity *= 0.96f;

            prevPos = this.transform.position;

        Debug.Log(System.Math.Abs(rb.velocity.magnitude));

        
    }


    IEnumerator vib()
    {
        Vector3 rotate = rbArrow.transform.localEulerAngles;

        while (Input.GetMouseButton(0) && arrowScale.y >= 25f)
        {
            rotate = rbArrow.transform.localEulerAngles;

            rotate.z += 2;
            rbArrow.transform.localEulerAngles = rotate;

            yield return new WaitForSeconds(0.01f);

            rotate.z -= 2;
            rbArrow.transform.localEulerAngles = rotate;

            yield return new WaitForSeconds(0.01f);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            audioSource.PlayOneShot(collSound);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Trash")
        {
            audioSource.PlayOneShot(pickTrash);
        }
    }


}
