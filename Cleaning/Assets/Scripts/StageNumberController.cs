using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageNumberController : MonoBehaviour
{
    
     Text stageText;
    GManager gameManager;

    public void changeStageText(int stageNum)
    {
        gameManager = FindObjectOfType<GManager>();
        stageText = this.gameObject.GetComponent<Text>();
        stageNum = gameManager.stage + 1;
        stageText.text = stageNum.ToString();
    }

}
