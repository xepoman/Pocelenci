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
    bool boolDeystieImp = false;
    bool boolProizvodstvoImp = false;
    bool boolSvoystvoImp = false;

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
        else if (card && DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_IMPERIA_DEISTVIE)
        {
            boolDeystieImp = true;
            Debug.Log("DeystieImp");
        }
        else if (card && DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_IMPERIA_OSOBENOST)
        {
            boolSvoystvoImp = true;
            Debug.Log("SvoystvoImp");
        }
        else if (card && DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_IMPERIA_PROIZVODSTVO)
        {
            boolProizvodstvoImp = true;
            Debug.Log("ProizvodstvoImp");
        }
        else return;
        
    }
    public void OnEndDrag(PointerEventData eventData) // когда отпускаем карту
    {
        if (eventData.pointerDrag == null)
            return;
        //карта которая была отпушена данным обьектом и присвоина с самой себя
        CardMovementScr cardMovement = eventData.pointerDrag.GetComponent<CardMovementScr>();
        //  card = eventData.pointerDrag.GetComponent<CardInfoScr>();
        // когда отпускаем карту смотрим в каком поле
        DefaultParent = transform.parent;
        if (card && DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_POLE_DEISTVIE && !boolDeystie)
        {
            Debug.Log(card.SelfCard.cenaPostroiki);
            //отнимаем и добавляем из одного списка в другой (с руки в поле)
            cardMovement.GameManager.PlayerPoleDeystvieCard.Add(cardMovement.GetComponent<CardInfoScr>());
            cardMovement.GameManager.PlayerHandCard.Remove(cardMovement.GetComponent<CardInfoScr>());
            OtnimaemRes();
        }
        else if (card && DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_POLE_OSOBENOST && !boolSvoystvo)
        {
            Debug.Log(card.SelfCard.cenaPostroiki);
            //отнимаем и добавляем из одного списка в другой (с руки в поле)
            cardMovement.GameManager.PlayerPoleSvoistvaCard.Add(cardMovement.GetComponent<CardInfoScr>());
            cardMovement.GameManager.PlayerHandCard.Remove(cardMovement.GetComponent<CardInfoScr>());
            OtnimaemRes();
        }
        else if (card && DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_POLE_PROIZVODSTVO && !boolProizvodstvo)
        {
            Debug.Log(card.SelfCard.cenaPostroiki);
            //отнимаем и добавляем из одного списка в другой (с руки в поле)
            cardMovement.GameManager.PlayerPoleProizvodstvaCard.Add(cardMovement.GetComponent<CardInfoScr>());
            cardMovement.GameManager.PlayerHandCard.Remove(cardMovement.GetComponent<CardInfoScr>());
            OtnimaemRes();
        }
        else if (card && DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_IMPERIA_DEISTVIE && !boolDeystieImp)
        {
            Debug.Log(card.SelfCard.cenaPostroiki);
            //отнимаем и добавляем из одного списка в другой (с руки в поле)
            cardMovement.GameManager.PlayerImpPoleDeystvieCard.Add(cardMovement.GetComponent<CardInfoScr>());
            cardMovement.GameManager.PlayerHandCard.Remove(cardMovement.GetComponent<CardInfoScr>());
            OtnimaemRes();
        }
        else if (card && DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_IMPERIA_OSOBENOST && !boolSvoystvoImp)
        {
            Debug.Log(card.SelfCard.cenaPostroiki);
            //отнимаем и добавляем из одного списка в другой (с руки в поле)
            cardMovement.GameManager.PlayerImpPolevSvoistvaCard.Add(cardMovement.GetComponent<CardInfoScr>());
            cardMovement.GameManager.PlayerHandCard.Remove(cardMovement.GetComponent<CardInfoScr>());
            OtnimaemRes();
        }
        else if (card && DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_IMPERIA_PROIZVODSTVO && !boolProizvodstvoImp)
        {
            Debug.Log(card.SelfCard.cenaPostroiki);
            //отнимаем и добавляем из одного списка в другой (с руки в поле)
            cardMovement.GameManager.PlayerImpPoleProizvodstvaCard.Add(cardMovement.GetComponent<CardInfoScr>());
            cardMovement.GameManager.PlayerHandCard.Remove(cardMovement.GetComponent<CardInfoScr>());
            OtnimaemRes();
        }

    }
    void PribovlenieRes(GameObject game) // функция расчета прибавления ресов при разрушении
    {
        
        string[] split = game.GetComponent<CardInfoScr>().SelfCard.resursRazrushenia.Split('+'); // разложили обьект на буквы и проверили
       // Debug.Log("split " + split[0]);
        for (int i = 0; i < split.Length; i++)
        {
            switch (split[i])
            {
                case "Д":
                    resCard.ObDerevo += 1;
                    break;
                case "К":
                    resCard.ObKamen += 1;
                    break;
                case "Е":
                    resCard.ObEda += 1;
                    break;
                case "Р":
                    resCard.ObEmploe += 1;
                    break;
                case "З":
                    resCard.ObGold += 1;
                    break;
                case "ПО":
                    resCard.ObPO += 1;
                    break;
            }
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
                    case "П":
                        if (GameManager.PlayerPoleDeystvieCard.Count != 0 || GameManager.PlayerPoleProizvodstvaCard.Count != 0
                                                                  || GameManager.PlayerPoleSvoistvaCard.Count != 0)
                        {
                            DestroyCard();
                           // Debug.Log("Добавить фуекцию выбора удаления карты обьект полн");
                            break;
                        }
                        else
                        {
                            //Debug.Log("Добавить фуекцию выбора удаления карты обьект пуст");
                            break;
                        }
                        
                }
            }
        }
    }
    void DestroyCard() // добавить действия выбора что удалять
    {
        // card.GetComponent<CardManegerScr>().OnEndDrag(null); // если ошибка при удалении карты
        //проверка если карта находится в списке то удаляем ее от туда 
        if (GameManager.PlayerPoleDeystvieCard.Count != 0)
        {
            PribovlenieRes(GameManager.PlayerPoleDeystvieCard[0].gameObject);
            GameManager.PlayerPoleDeystvieCard.Remove(card);
            Destroy(GameManager.PlayerPoleDeystvieCard[0].gameObject);
        }
        else if (GameManager.PlayerPoleProizvodstvaCard.Count != 0)
        {
            PribovlenieRes(GameManager.PlayerPoleProizvodstvaCard[0].gameObject);
            GameManager.PlayerPoleProizvodstvaCard.Remove(card);
            Destroy(GameManager.PlayerPoleProizvodstvaCard[0].gameObject);
        }
        else if (GameManager.PlayerPoleSvoistvaCard.Count != 0)
        {
            PribovlenieRes(GameManager.PlayerPoleSvoistvaCard[0].gameObject);
            GameManager.PlayerPoleSvoistvaCard.Remove(card);
            Destroy(GameManager.PlayerPoleSvoistvaCard[0].gameObject);
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
            case "П":
                {
                    if (GameManager.PlayerPoleDeystvieCard.Count != 0 || GameManager.PlayerPoleProizvodstvaCard.Count != 0
                                                                  || GameManager.PlayerPoleSvoistvaCard.Count != 0)
                    {
                        return true;
                    }
                    else
                    {
                        //  Debug.Log("Добавить функцию выбора удаления производства и проверку если нет карт на поле");
                        return false;
                    }
                }
            default: return true;
        }
    }

    
}
