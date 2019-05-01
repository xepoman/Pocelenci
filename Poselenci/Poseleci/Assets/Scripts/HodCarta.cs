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
    bool boolDeystie = false;
    bool boolProizvodstvo = false;
    bool boolSvoystvo = false;
    
    void Awake()
    {
        GameManager = FindObjectOfType<GameManagerScr>();
        resCard = FindObjectOfType<ResursCards>();
        card = FindObjectOfType<CardInfoScr>();
    }
    public void OnBeginDrag(PointerEventData eventData)// когда начинаем перетягивать
    {
        DefaultParent = transform.parent;
        if (DefaultParent.name == "planshet"|| DefaultParent.name == "BG")
            return;
        if (card && DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_POLE_DEISTVIE)
        {
            boolDeystie = true;
            Debug.Log("deystvie");
        }
        else if (card && DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_POLE_OSOBENOST)
        {
            boolSvoystvo = true;
            Debug.Log("osobenost");
        }
        else if (card && DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_POLE_PROIZVODSTVO)
        {
            boolProizvodstvo = true;
            Debug.Log("proizvodstvo");
        }
        else return;
        
    }
    public void OnEndDrag(PointerEventData eventData) // когда отпускаем карту
    {
        if (eventData.pointerDrag == null)
            return;
       
      //  card = eventData.pointerDrag.GetComponent<CardInfoScr>();
      // когда отпускаем карту смотрим в каком поле
        DefaultParent = transform.parent;
        if (card && DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_POLE_DEISTVIE && !boolDeystie)
        {
            Debug.Log(card.SelfCard.cenaPostroiki);
            OtnimaemRes();
        }
        if (card && DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_POLE_OSOBENOST && !boolSvoystvo)
        {
            Debug.Log(card.SelfCard.cenaPostroiki);
            OtnimaemRes();
        }
        if (card && DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_POLE_PROIZVODSTVO && !boolProizvodstvo)
        {
            Debug.Log(card.SelfCard.cenaPostroiki);
            OtnimaemRes();
        }
       
    }
    void OtnimaemRes()// функция расчетов отнимания ресурсов
    {

        if (card.SelfCard.cenaPostroiki.Length >= 1 && RaschetCenCrd()) // проверка  цены 
        {
            string[] split = card.SelfCard.cenaPostroiki.Split('+');
            for (int i = 0; i < split.Length; i++)
            {
                switch (split[i])
                {
                    case "Д":
                        resCard.ObDerevo -= 1;
                        break;
                    case "К":
                        resCard.ObKamen -= 1;
                        break;
                    case "Е":
                        resCard.ObEda -= 1;
                        break;
                }
            }
        }
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
