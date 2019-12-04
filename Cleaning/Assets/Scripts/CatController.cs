using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    public GameObject catOnRoomba;
    public Vector2 RoombaSpeed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        RoombaSpeed = rb.velocity.normalized;
        rb.velocity = new Vector3(0, 0, 0);
        Debug.Log(RoombaSpeed);
        collision.gameObject.SetActive(false);
        //Instantiate(catOnRoomba, transform.position, Quaternion.identity);
        catOnRoomba.SetActive(true);
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);

    }

}
