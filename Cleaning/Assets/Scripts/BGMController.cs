using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    //private GameObject HP;
    HPController hpController;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //hpController = HP.GetComponent<HPController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hpController == null)
        {
            hpController = FindObjectOfType<HPController>();
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            time = hpController.currentTime;
            Debug.Log(time);
            if (time < 5f)
            {
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }
        }

    }
}
