﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{
    static public bool stand = false;
     void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Horizontal")
        {
            stand = true;
            fixedroll.turn = true;
            Debug.Log(fixedroll.turn);
        }
        if (coll.gameObject.tag == "Vertical")
        {
            stand = true;
            fixedroll.turn = false;
            Debug.Log(fixedroll.turn);
        }
        if (coll.gameObject.tag == "Respawn")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +0);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        stand = false;
    }
}
