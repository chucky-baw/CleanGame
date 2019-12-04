using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{


    public void OnClick(int number)
    {

        switch (number)
        {
            case 0:
                Debug.Log("Retry");
                FindObjectOfType<GManager>().dispatch(GManager.GameState.Playing);
                
                
                break;

            case 1:
                FindObjectOfType<GManager>().dispatch(GManager.GameState.Title);
                break;

        }


    }
}
