using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatOnRoomba : MonoBehaviour
{
    [SerializeField]
    private GameObject Roomba;
    public GameObject HP;
    HPController hpc;
    AudioSource audioSource;
    public AudioClip catVoice;
    public GameObject cat;
    CatController catController;
    Rigidbody2D rb;
    Renderer a;

    // Start is called before the first frame update
    void Start()
    {
        a = gameObject.GetComponent<SpriteRenderer>();
        hpc = HP.gameObject.GetComponent<HPController>();
        catController = cat.gameObject.GetComponent<CatController>();

    }

    void destroyCat()
    {
        
        a.enabled = false;
        cat.gameObject.SetActive(true);
        Roomba.gameObject.SetActive(true);
        rb = Roomba.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(catController.RoombaSpeed * 3f, ForceMode2D.Impulse);
        StartCoroutine(catDisenable());

    }

    void Meow()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(catVoice);
    }

    public void catReduceBattery()
    {
        hpc.reduceHP(20);
    }

    IEnumerator catDisenable()
    {
        cat.gameObject.GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(0.2f);

        cat.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        a.enabled = true;
        this.gameObject.SetActive(false);

    }

}
