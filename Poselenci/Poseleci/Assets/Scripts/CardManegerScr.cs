using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
public struct Card
{
    public string Name;
    public Sprite Logo;
    public string cenaPostroiki; // Д+К+З+Е+Р
    public string resursRazrushenia;
    public string colorLogo;
    public int polePlansheta; // Действие, производсво, свойство
    public string svoistvaCard; // Что делает карта 
    public string bonusStroiki; // что происходит при стройке
    public int quantitiPovtor; // сколько раз можно использовать карту за ход
    public int POCard; // очки карты в конце игры

    public Card(string name,
                string logo,
                string cenaPostroiki,
                string resursRazrushenia,
                string colorLogo,
                int polePlansheta,
                string svoistvaCard,
                string bonusStroiki,
                int quantitiPovtor,
                int POCard
                )
    {
        this.Name = name;
        this.Logo = Resources.Load<Sprite>(logo);
        this.cenaPostroiki = cenaPostroiki;
        this.resursRazrushenia = resursRazrushenia;
        this.colorLogo = colorLogo;
        this.polePlansheta = polePlansheta;
        this.svoistvaCard = svoistvaCard;
        this.bonusStroiki = bonusStroiki;
        this.quantitiPovtor = quantitiPovtor;
        this.POCard = POCard;
    }
}
public static class CardManager
{
    // будут хранится все карты
    public static List<Card> AllCards = new List<Card>();
}
public class CardManegerScr : MonoBehaviour
{
    public void Awake()
    {
        // создаем папку с ресурсами и добавляем логотипы карт
        CardManager.AllCards.Add(new Card("ObDerevna", "Sprites/Cards/ObDerevna", "Д", "P+P", "r", 1, "Р", "Р", 0, 1));
        CardManager.AllCards.Add(new Card("ObDerevna", "Sprites/Cards/ObDerevna", "Д", "P+P", "r", 1, "Р", "Р", 0, 1));
        CardManager.AllCards.Add(new Card("ObDerevna", "Sprites/Cards/ObDerevna", "Д", "P+P", "r", 1, "Р", "Р", 0, 1));
        CardManager.AllCards.Add(new Card("ObDrovaSklad", "Sprites/Cards/ObDrovaSklad", "Д+Д+К", "Д+Д", "k", 2, "", "ПО+КР/k", 0, 1));
        CardManager.AllCards.Add(new Card("ObDrovoseki", "Sprites/Cards/ObDrovoseki", "Д+Д", "Д+Д", "k", 3, "-Р=Д+Д", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObGanzeiskiSoyz", "Sprites/Cards/ObGanzeiskiSoyz", "К+Д+К", "ПО+З", "j", 3, "-Р-С=ПО+ПО", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObGildiaKamenshikov", "Sprites/Cards/ObGildiaKamenshikov", "К+Д+Д", "К+З", "s", 3, "-Р-К-К=ПО+ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObGildiaKamenshikov", "Sprites/Cards/ObGildiaKamenshikov", "К+Д+Д", "К+З", "s", 3, "-Р-К-К=ПО+ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObGildiaTorgovcev", "Sprites/Cards/ObGildiaTorgovcev", "К+Д+Д", "К+З", "j", 1, "З/j <=3", "", 0, 1));

        CardManager.AllCards.Add(new Card("ObImperskiPoslanik", "Sprites/Cards/ObImperskiPoslanik", "Е", "Р+З", "red", 3, "-Р=С+Т", "", 0, 1));
    }
    
}
    

