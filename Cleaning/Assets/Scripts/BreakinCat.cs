using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakinCat : MonoBehaviour
{
    TrashBox trashBox;
    AudioSource audioSource;


    public AudioClip angryCatVoice;

    // Start is called before the first frame update
    void Start()
    {
        trashBox = FindObjectOfType<TrashBox>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void breakTrashBox()
    {
        trashBox.breakTrashBox();
        Destroy(this.gameObject);
    }

    public void angryVoice()
    {
        audioSource.PlayOneShot(angryCatVoice);
    }

}
