using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HodCarta : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    public Transform DefaultParent;
    GameManagerScr GameManager;
    CardInfoScr card;
    ResursCards resCard;
    bool boolDerevo = false;
    bool boolEda = false;
    bool boolGold = false;
    bool boolEmploe = false;
    bool boolKamen = false;
    bool boolPO = false;
    bool boolOrujee = false;
    void Awake()
    {
        GameManager = FindObjectOfType<GameManagerScr>();
        resCard = FindObjectOfType<ResursCards>();
        card = FindObjectOfType<CardInfoScr>();
    }
    public void OnBeginDrag(PointerEventData eventData)// когда начинаем перетягивать
    {

        /* DefaultParent = transform.parent;
         

         if (DefaultParent.GetComponent<DropPlaceScr>().Type == FieldType.Player_HAND)
         {
             Debug.Log("111111111");
         }*/
       
    }
    public void OnEndDrag(PointerEventData eventData) // когда отпускаем карту
    {
        if (eventData.pointerDrag == null)
            return;
       
      //  card = eventData.pointerDrag.GetComponent<CardInfoScr>();
      // когда отпускаем карту смотрим в каком поле
        DefaultParent = transform.parent;
        if (card && DefaultParent.GetComponent<DropPlaceScr>().Type == FieldType.Player_POLE_DEISTVIE)
        {
            Debug.Log(card.SelfCard.cenaPostroiki);
            OtnimaemRes();
        }
        if (card && DefaultParent.GetComponent<DropPlaceScr>().Type == FieldType.Player_POLE_OSOBENOST)
        {
            Debug.Log(card.SelfCard.cenaPostroiki);
            OtnimaemRes();
        }
        if (card && DefaultParent.GetComponent<DropPlaceScr>().Type == FieldType.Player_POLE_PROIZVODSTVO)
        {
            Debug.Log(card.SelfCard.cenaPostroiki);
            OtnimaemRes();
        }
       
    }
    void OtnimaemRes()// функция расчетов отнимания ресурсов
    {
        if (boolDerevo) resCard.ObDerevo--; boolDerevo = false;
        if (boolEda) resCard.ObEda--; boolEda = false;
        if (boolGold) resCard.ObGold--; boolGold = false;
        if (boolEmploe) resCard.ObEmploe--; boolEmploe = false;
        if (boolKamen) resCard.ObKamen--; boolKamen = false;
        if (boolPO) resCard.ObPO--; boolPO = false;
        if (boolOrujee) resCard.ObOrujee--; boolOrujee = false;
    }
    public bool RaschetCenCrd()// расчет цены постройки карты
    {
        if (card.SelfCard.cenaPostroiki.Length <= 2 && card.SelfCard.cenaPostroiki.Length == 1) // проверка для одиночной цены "Д"
        {
           return SwitchCard(card.SelfCard.cenaPostroiki);
        }
        else if(card.SelfCard.cenaPostroiki.Length >2) // проверка для "Д+Д+К" и тд
        {
            bool temp = false;
            string[] split = card.SelfCard.cenaPostroiki.Split('+');
            for (int i=0; i<split.Length; i++)
            {
                if (SwitchCard(split[i]))
                {
                    temp = true;
                }
                else return false;
            }
            return temp;
        }
        else return true;
    }
    bool SwitchCard(string s) // функция сравнения значений в строке
    {
        switch (s)
        {
            case "Д":
                if (resCard.ObDerevo >= 1)
                {
                    boolDerevo = true;
                    return true;
                }
                else
                {
                    Debug.Log("Нет дерева");
                    return false;
                }

            case "Е":
                if (resCard.ObEda >= 1)
                {
                    boolEda = true;
                    return true;
                }
                else
                {
                    Debug.Log("Нет еды");
                    return false;
                }

            case "3":
                if (resCard.ObGold >= 1)
                {
                    boolGold = true;
                    return true;
                }
                else
                {
                    Debug.Log("Нет золота");
                    return false;
                }

            case "Р":
                if (resCard.ObEmploe >= 1)
                {
                    boolEmploe = true;
                    return true;
                }
                else
                {
                    Debug.Log("Нет работников");
                    return false;
                }

            case "К":
                if (resCard.ObKamen >= 1)
                {
                    boolKamen = true;
                    return true;
                }
                else
                {
                    Debug.Log("Нет камня");
                    return false;
                }

            case "ПО":
                if (resCard.ObPO >= 1)
                {
                    boolPO = true;
                    return true;
                }
                else
                {
                    Debug.Log("Нет ПО");
                    return false;
                }

            case "О":
                if (resCard.ObOrujee >= 1)
                {
                    boolOrujee = true;
                    return true;
                }
                else
                {
                    Debug.Log("Нет оружия");
                    return false;
                }
            default: return true;
        }
    }

    
}
