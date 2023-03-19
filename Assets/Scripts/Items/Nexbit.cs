using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Player;


public class Nexbit : MonoBehaviour
{
    public int nexbits;
    float airtime = 0;
    [Range(0.1f, 1)]
    [SerializeField] float airtimeMultiplier;
    float speed = 0;
    [Range(0.1f, 1)]
    [SerializeField] float speedMultiplier;

    GameManager gm;
    [SerializeField] TextMeshProUGUI nexbitTxt, speedTxt, airtimeTxt;

    [SerializeField] PlayerJump pj;
    [SerializeField] Rigidbody playerRB;

    bool inAir = false;

    private void Start()
    {
        nexbits = PlayerPrefs.GetInt("Nexbits");
        if(nexbitTxt)
        {
            nexbitTxt.text = nexbits.ToString();
        }
        gm = FindObjectOfType<GameManager>();
        if(gm)
        {
            gm.enemyDeath += CalculateNexbits;
        }
        SceneManager.activeSceneChanged += SaveNexbits;
        if (pj)
        {
            pj.onNotGrounded += InAir;
            pj.onGrounded += NotInAir;
        }
        if(airtimeTxt)
        {
            airtimeTxt.text = 0.ToString();
        }
    }

    private void Update()
    {
        if (inAir)
        {
            airtime += Time.deltaTime;
            airtimeTxt.text = ((int)((airtime + 1) * airtimeMultiplier) * (int)(speed * speedMultiplier)).ToString();
        }
        if(playerRB)
        {
            speed = playerRB.velocity.magnitude;
            speedTxt.text = "Speed: " + ((int)speed).ToString() + " KM/h";
        }
    }

    void InAir()
    {
        inAir = true;
        airtimeTxt.gameObject.SetActive(true);
    }

    void NotInAir()
    {
        inAir = false;
        airtime = 0;
        airtimeTxt.gameObject.SetActive(false);
    }

    void CalculateNexbits()
    {
        nexbits += (int)((airtime + 1) * airtimeMultiplier) * (int)(speed * speedMultiplier);
        if (nexbitTxt)
        {
            nexbitTxt.text = nexbits.ToString();
        }

    }

    public void RemoveNexbits(int amt)
    {
        nexbits -= amt;
        if (nexbitTxt)
        {
            nexbitTxt.text = nexbits.ToString();
        }
    }

    void SaveNexbits(Scene current, Scene next)
    {
        PlayerPrefs.SetInt("Nexbits", nexbits);
        SceneManager.activeSceneChanged -= SaveNexbits;
    }
}
