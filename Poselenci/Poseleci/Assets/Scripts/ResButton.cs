using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResButton : MonoBehaviour
{
    ResursCards resCard;
    void Awake()
    {
        resCard = FindObjectOfType<ResursCards>();
    }
    public void DeistviePlanshetaBtn()
    {
        if (resCard.ObEmploe >= 2)
        {
            resCard.ObEmploe -= 2;
        }
        else
        {
            return;
        }
    }
}
