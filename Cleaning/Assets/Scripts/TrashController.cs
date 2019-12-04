using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    GManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        destroyTrash();
    }

    public void destroyTrash()
    {
        Destroy(this.gameObject);

    }

}
