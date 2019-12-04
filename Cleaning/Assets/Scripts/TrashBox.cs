using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBox : MonoBehaviour
{
    public GameObject[] trashInBox;

    AudioSource audioSource;

    public AudioClip TrashBoxSound;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < trashInBox.Length; i++)
        {
            trashInBox[i].SetActive(false);
        }

        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for(int i=0; i<trashInBox.Length; i++)
        {
            trashInBox[i].SetActive(true);
        }

        Destroy(this.gameObject);
    }

    public void breakTrashBox()
    {
        for (int i = 0; i < trashInBox.Length; i++)
        {
            trashInBox[i].SetActive(true);
        }

        AudioSource.PlayClipAtPoint(TrashBoxSound, transform.position);

        Destroy(this.gameObject);
    }


}
