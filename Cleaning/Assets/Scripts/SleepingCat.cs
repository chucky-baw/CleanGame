using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingCat : MonoBehaviour
{
    GameObject RunningCat;

    // Start is called before the first frame update
    void Start()
    {
        RunningCat = GameObject.Find("RunningCat");
        RunningCat.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        RunningCat.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RunningCat.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }
}
