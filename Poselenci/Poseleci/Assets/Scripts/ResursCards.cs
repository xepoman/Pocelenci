﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
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
public class ResursCards : MonoBehaviour
{
    public TextMeshProUGUI EmploeTxt;
    public TextMeshProUGUI DerevoTxt;
    public TextMeshProUGUI KamenTxt;
    public TextMeshProUGUI GoldTxt;
    public TextMeshProUGUI EdaTxt;
    public TextMeshProUGUI POTxt;
    public TextMeshProUGUI OrujeeTxt;
    
    public int ObEmploe = 0;
    public int ObOrujee = 0;
    public int ObDerevo = 0;
    public int ObKamen = 0;
    public int ObGold = 0;
    public int ObEda = 0;
    public int ObPO = 0;
    
    private CardInfoScr card;
    private GameManagerScr GameManager;
  //  private HodCarta hodCart;
    void Awake()
    {
        GameManager = FindObjectOfType<GameManagerScr>();
        card = FindObjectOfType<CardInfoScr>();
   //     hodCart = FindObjectOfType<HodCarta>();
    }
    private void Start()
    {
        PlanshetVarvar();
        ShowResurs();
    }

    private void Update()
    {
        ShowResurs();
    }
    public void ShowResurs()
    {
        EmploeTxt.text = ObEmploe.ToString();
        DerevoTxt.text = ObDerevo.ToString();
        KamenTxt.text = ObKamen.ToString();
        GoldTxt.text = ObGold.ToString();
        EdaTxt.text = ObEda.ToString();
        POTxt.text = ObPO.ToString();
        OrujeeTxt.text = ObOrujee.ToString();
    }
    public void PlanshetVarvar()
    {
        ObEmploe = 5;
        ObOrujee = 1;
        ObDerevo = 0;
        ObKamen = 0;
        ObGold = 0;
        ObEda =0;
       
    }
    
    public void RaschetResovEndRaund() // функция расчета  ресурсов кард в конце раунда
    {
        if (GameManager.PlayerImpPoleDeystvieCard.Count == 0 && GameManager.PlayerImpPoleProizvodstvaCard.Count == 0
                                                            && GameManager.PlayerImpPolevSvoistvaCard.Count == 0
                                                            && GameManager.PlayerPoleDeystvieCard.Count == 0
                                                            && GameManager.PlayerPoleProizvodstvaCard.Count == 0
                                                            &&GameManager.PlayerPoleSvoistvaCard.Count == 0)
        {
            return;
        }
        if (GameManager.PlayerPoleProizvodstvaCard.Count !=0)
        {
            CiklPole(GameManager.PlayerPoleProizvodstvaCard);
        }
     /*   if (GameManager.PlayerPoleDeystvieCard.Count != 0)
        {
            CiklPole(GameManager.PlayerPoleDeystvieCard);
        }
        if (GameManager.PlayerPoleSvoistvaCard.Count != 0)
        {
            CiklPole(GameManager.PlayerPoleSvoistvaCard);
        }*/
        if (GameManager.PlayerImpPoleProizvodstvaCard.Count != 0)
        {
            CiklPole(GameManager.PlayerImpPoleProizvodstvaCard);
        }
     /*   if (GameManager.PlayerImpPoleDeystvieCard.Count != 0)
        {
            CiklPole(GameManager.PlayerImpPoleDeystvieCard);
        }
        if (GameManager.PlayerImpPolevSvoistvaCard.Count != 0)
        {
            CiklPole(GameManager.PlayerImpPolevSvoistvaCard);
        }*/
    }
    void CiklPole(List<CardInfoScr> pole)
    {
        for (int i = 0; i < pole.Count; i++)
        {
          Schet(pole[i].SelfCard.svoistvaCard);
        }
    }
    void Schet(string str)
    {
        Debug.Log(str);
        switch (str)
        {
            case "":
                break;
            case "Д":
                ObDerevo += 1;
                break;
            case "К":
                ObKamen += 1;
                break;
            case "Е":
                ObEda += 1;
                break;
            case "Р":
                ObEmploe += 1;
                break;
            case "З":
                ObGold += 1;
                break;
            case "ПО":
                ObPO += 1;
                break;
            case "КР":
                Game CurrentGame = GetComponent<GameManagerScr>().CurrentGame = new Game();
                GetComponent<GameManagerScr>().GiveHandCards(CurrentGame.ObDeckCard, GetComponent<GameManagerScr>().PlayerHand, 1);
             //   Debug.Log("Производит карточку");
                break;
            case "З/jП<=3":
               ObGold += RaschetResZaPostr("j");
                break;
            case "Е/red <=3":
               ObEda += RaschetResZaPostr("red");
                break;
            case "Д/kП<=3":
                ObDerevo += RaschetResZaPostr("k");
                break;
            case "Р/rП<=3":
                ObEmploe += RaschetResZaPostr("r");
                break;
            case "ВЫбр ПР=ПР":
                Debug.Log("муть");
                break;
            case "Р+Р":
                ObEmploe += 2;
                break;
            case "К/sП<=3":
               ObKamen += RaschetResZaPostr("s");
                break;
            case "Д+Д":
                ObDerevo += 2;
                break;
           
        }
    }
    int RaschetResZaPostr(string color) // функция ограничения ресурсов по проверки по цвету
    {
        Debug.Log(GameManager.PlayerImpPoleDeystvieCard.Count);
        Debug.Log(GameManager.PlayerImpPoleProizvodstvaCard.Count);
        Debug.Log(GameManager.PlayerImpPolevSvoistvaCard.Count);
        int kolIspolzovaniaCard = 0;
        for (int i = 0; i < GameManager.PlayerImpPoleDeystvieCard.Count; i++)
        {
           if(GameManager.PlayerImpPoleDeystvieCard[i].SelfCard.colorLogo == color)
            {
                return kolIspolzovaniaCard++;
            }
           
        }
        for (int i = 0; i < GameManager.PlayerImpPoleProizvodstvaCard.Count; i++)
        {
            if (GameManager.PlayerImpPoleProizvodstvaCard[i].SelfCard.colorLogo == color)
            {
                return kolIspolzovaniaCard++;
            }

        }
        for (int i = 0; i < GameManager.PlayerImpPolevSvoistvaCard.Count; i++)
        {
            if (GameManager.PlayerImpPolevSvoistvaCard[i].SelfCard.colorLogo == color)
            {
                return kolIspolzovaniaCard++;
            }

        }
        if (kolIspolzovaniaCard > 3)
        {
            return 3;
        }
        return kolIspolzovaniaCard;
    }
   
}



