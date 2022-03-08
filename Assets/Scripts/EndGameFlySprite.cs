using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameFlySprite : MonoBehaviour
{
    public Sprite[] pl_spr;
    
        private void Start()
    {
        int clrIndex = PlayerPrefs.GetInt("playerColor");
        switch (clrIndex)
        {
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = pl_spr[0];
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = pl_spr[1];
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = pl_spr[2];
                break;
            case 4:
                gameObject.GetComponent<SpriteRenderer>().sprite = pl_spr[3];
                break;
            case 5:
                gameObject.GetComponent<SpriteRenderer>().sprite = pl_spr[4];
                break;
            case 6:
                gameObject.GetComponent<SpriteRenderer>().sprite = pl_spr[5];
                break;
            default:
                gameObject.GetComponent<SpriteRenderer>().sprite = pl_spr[0];
                break;
        }
    }
}
