﻿using System.Collections;
using UnityEngine;

public class fixedroll : MonoBehaviour
{
    public bool canroll=true;
    public bool move;
    public int val;
    static public int diceside = 0;
    static public bool turn = false;
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public int requiredside;

    // Use this for initialization
    private void Start()
    {
        diceside = val;
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[diceside];
        if (requiredside == diceside)
        {
            canroll = false;
            Debug.Log(game.count);
        }
    }
    private void FixedUpdate()
    {
        move = turn;
    }
    private void OnMouseDown()
    {
        if ((collision.stand == true)&&(canroll==true))
        {
            StartCoroutine("RollTheDice");
        }
    }
    private IEnumerator RollTheDice()
    {

        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, 6);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }
        Debug.Log(move);
        Debug.Log(turn);
        if (move == false)
        {
            rend.sprite = diceSides[Mathf.Abs(5-diceside)];
            diceside = Mathf.Abs(5 - diceside);
        }else {
            if((diceside==0)|| (diceside == 1) || (diceside == 3) || (diceside == 4))
            {
                rend.sprite = diceSides[diceside+1];
                diceside = diceside + 1;
            }
            else
            {
                rend.sprite = diceSides[diceside - 1];
                diceside = diceside - 1;
            }
        }
        if (requiredside == diceside)
        {
           canroll = false;
            game.count++;
            Debug.Log(game.count);
        }
    }
}
