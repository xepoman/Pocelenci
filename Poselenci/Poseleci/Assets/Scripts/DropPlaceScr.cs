using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum FieldType
{
    Enemy_HAND, // поле руки противника  
    Player_POLE_OSOBENOST,// поле особености поля
    Player_POLE_PROIZVODSTVO,// поле производства поля
    Player_POLE_DEISTVIE,// поле действия поля
    Player_HAND,// поле игрока руки
    Player_IMPERIA_PROIZVODSTVO,// поле производства империи
    Player_IMPERIA_DEISTVIE,// поле действия империи
    Player_IMPERIA_OSOBENOST,// поле империи особености игрока
    ROZIGRISH_POLE // поле розыгрыша Обших карт
}

public class DropPlaceScr : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public FieldType Type;
    GameManagerScr GameManager;
    HodCarta HodCartaScr;
    void Awake()
    {
        GameManager = FindObjectOfType<GameManagerScr>();
        
    }
    public void OnDrop(PointerEventData eventData) // срабатывает когда накладываем карту на карту
    {
        // условие физического перетягивания карты
        if (openPoleCard(openPoleDlaCard(eventData)))
        {
            return;
        }

        //карта которая была отпушена данным обьектом и присвоина с самой себя
        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();
        //ограничение карт в руке игрока
        if(card && card.GameManager.PlayerHandCard.Count <18 && card.GameManager.IsPlayerTurn && card.GameManager.PerezagruzkaFielCard.Count%2 == 0)
        {
            // переместили из одного списка в другой Удалили из общего добавили в руку
            card.GameManager.PerezagruzkaFielCard.Remove(card.GetComponent<CardInfoScr>());
            card.GameManager.PlayerHandCard.Add(card.GetComponent<CardInfoScr>());
            card.DefaultParent = transform;
        }
    }

    int openPoleDlaCard(PointerEventData eventData)
    {
        /*
        поле планшета
        1 - производство
        2 - свойство
        3 - действие
        */
        HodCartaScr = eventData.pointerDrag.GetComponent<HodCarta>();
        List<CardInfoScr> cardInfo = new List<CardInfoScr>();
        cardInfo.Add(eventData.pointerDrag.GetComponent<CardInfoScr>());
       // Debug.Log("Coin " + cardInfo.Count); проследить может переполница масив карт и надо будет удалять
        return cardInfo[0].SelfCard.polePlansheta;
    }

    bool openPoleCard (int poleCard)
    {
        
        if (GameManager.PerezagruzkaFielCard.Count != 0)// это проверка розыгрыша поля только от туда брать карты
        {
            if (Type == FieldType.ROZIGRISH_POLE            // это проверка куда нельяз ложить карты
                                        || Type == FieldType.Enemy_HAND
                                        || Type == FieldType.Player_POLE_OSOBENOST
                                        || Type == FieldType.Player_POLE_PROIZVODSTVO
                                        || Type == FieldType.Player_POLE_DEISTVIE
                                        || Type == FieldType.Player_IMPERIA_PROIZVODSTVO
                                        || Type == FieldType.Player_IMPERIA_DEISTVIE
                                        || Type == FieldType.Player_IMPERIA_OSOBENOST)
            {
                return true;
            }
            else return false;
        }
        else
        {
            if (Type == FieldType.Enemy_HAND || Type == FieldType.ROZIGRISH_POLE)
            {
                return true;
            }
            else if(poleCard == 1 && Type != FieldType.Player_POLE_PROIZVODSTVO || !HodCartaScr.RaschetCenCrd())
            {
                return true;
            }
            else if (poleCard == 2 && Type != FieldType.Player_POLE_OSOBENOST || !HodCartaScr.RaschetCenCrd())
            {
                return true;
            }
            else if (poleCard == 3 && Type != FieldType.Player_POLE_DEISTVIE || !HodCartaScr.RaschetCenCrd())
            {
                return true;
            }
            else return false;
        }
    }
    public void OnPointerEnter(PointerEventData eventData) // движение курсора по полям 
    {
        // проверка если обьект не перетягивается то и проверка не выполняется и проверяем если чужое поле(РАМКА)
        // если мы наводим на чтото то выходим из функции
        // условие показывать рамку при перетягивании
        if (eventData.pointerDrag == null || openPoleCard(openPoleDlaCard(eventData)))
        {
            return;
        }

        // получем из обьект который тянем к нему установим текуший трансформ
        // таким образом радителем временой карты станет данное поле
        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();
        if(card)
        {
            card.DefaultTempCardParent = transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData) // наведение курсора
    {
        // если без карты наводим то дальше не проверяем
        if (eventData.pointerDrag == null)
        {
            return;
        }
        // получем из обьект который тянем к нему установим текуший трансформ
        // таким образом радителем временой карты станет данное поле
        // добавим в проверку это для того если тянем карту не туда и отпустим она вернется в руку
        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();
        if (card && card.DefaultTempCardParent == transform)
        {
            card.DefaultTempCardParent = card.DefaultParent;
        }
    }
}
