using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    public float maxHP = 100f;
    private float currentHP;
    private float countTime = 0;
    private float maxTime = 25f;
    public float currentTime;
    GManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        gameManager = FindObjectOfType<GManager>();
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;

        reduceTime();

        if(currentHP <= 0)
        {
            gameManager.dispatch(GManager.GameState.GameOver);
        }

        if(currentTime <= 0)
        {
            gameManager.dispatch(GManager.GameState.GameOver);
        }
    }

    public void reduceHP(float battery)
    {
        currentHP = currentHP - battery;
        this.GetComponent<Image>().fillAmount = currentHP / maxHP;

    }

    void reduceTime(){
      currentTime = maxTime - countTime;
      this.GetComponent<Image>().fillAmount = currentTime / maxTime;
    }



}
