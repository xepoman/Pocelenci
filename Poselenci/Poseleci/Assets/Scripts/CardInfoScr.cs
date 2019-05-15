using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
 * 
Д - дерево
К - Камень
З - золото
Е - еда
Р- работник
ПО - очки
П - постройка
С- сделка
Т - товар
КР - карточка
ПР - производство
БН -бонус
О -оружее

    Цвет
r   - розовый
k   - Коричневый
j   - желтый
s   - Серый
red   - красный
blak   - черный
f   - фиолетовый
blue - синий

    поле планшета
1   - производство
2  - свойство
3  - действие
*/
public class CardInfoScr : MonoBehaviour
{

    // public CardController CC;
    public Card SelfCard;
    public Image Pole;
    public GameManagerScr GameManager;
    public GameObject HideObjIMP;

    void Awake()
    {
        GameManager = FindObjectOfType<GameManagerScr>();
    }
    public void HideCardInfo(Card card)//закртые карты
    {
        SelfCard = card;
        HideObjIMP.SetActive(true);
    }
    public void ShowCardInfo(Card card) // открытые карты
    {
        SelfCard = card;
        HideObjIMP.SetActive(false);
        Pole.sprite = card.Logo;
        Pole.preserveAspect = true;
    }
    private void Start()
    {
       // ShowCardInfo(CardManager.AllCards[transform.GetSiblingIndex()]); // показывает карты противника

    }
  
}