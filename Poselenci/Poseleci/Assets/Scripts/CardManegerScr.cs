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
4   - производство импер
5  - свойство импер
6  - действие импер

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
    // будут хранится все карты обшие
    public static List<Card> AllCards = new List<Card>();
    // будут хранится все карты имперские (варвары)
    public static List<Card> AllCardsImperiaVarvar = new List<Card>();
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
        CardManager.AllCards.Add(new Card("ObGildiaTorgovcev", "Sprites/Cards/ObGildiaTorgovcev", "К+Д+Д", "К+З", "j", 1, "З/jП<=3", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObImperskiPoslanik", "Sprites/Cards/ObImperskiPoslanik", "Е", "Р+З", "red", 3, "-Р=С+Т", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObKamenalomna", "Sprites/Cards/ObKamenalomna", "Д+К", "К+К", "s", 1, "К", "К", 0, 1));
        CardManager.AllCards.Add(new Card("ObKamenalomna", "Sprites/Cards/ObKamenalomna", "Д+К", "К+К", "s", 1, "К", "К", 0, 1));
        CardManager.AllCards.Add(new Card("ObKamenalomna", "Sprites/Cards/ObKamenalomna", "Д+К", "К+К", "s", 1, "К", "К", 0, 1));
        CardManager.AllCards.Add(new Card("ObKamenshik", "Sprites/Cards/ObKamenshik", "Д+К", "Д+К", "s", 3, "-Р-К=ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObKamenshik", "Sprites/Cards/ObKamenshik", "Д+К", "Д+К", "s", 3, "-Р-К=ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObGorodPashni", "Sprites/Cards/ObGorodPashni", "Д+Д+К", "Е+Е", "red", 1, "Е/red <=3", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObKupecMonti", "Sprites/Cards/ObKupecMonti", "Д+К+К", "З+К", "j", 2, "ПО+З/jП", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObLagerLesoruba", "Sprites/Cards/ObLagerLesoruba", "Д+Д", "Д+Д", "k", 1, "Д", "Д", 0, 1));
        CardManager.AllCards.Add(new Card("ObLagerLesoruba", "Sprites/Cards/ObLagerLesoruba", "Д+Д", "Д+Д", "k", 1, "Д", "Д", 0, 1));
        CardManager.AllCards.Add(new Card("ObLagerLesoruba", "Sprites/Cards/ObLagerLesoruba", "Д+Д", "Д+Д", "k", 1, "Д", "Д", 0, 1));
        CardManager.AllCards.Add(new Card("ObLesopilka", "Sprites/Cards/ObLesopilka", "Д", "Р+Д", "k", 3, "-Д=ПО", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObLesopilka", "Sprites/Cards/ObLesopilka", "Д", "Р+Д", "k", 3, "-Д=ПО", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObMasterskayUvelira", "Sprites/Cards/ObMasterskayUvelira", "Д+К", "ПО+З", "j", 3, "-Р-З=ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObMasterskayUvelira", "Sprites/Cards/ObMasterskayUvelira", "Д+К", "ПО+З", "j", 3, "-Р-З=ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObLesoZagotovka", "Sprites/Cards/ObLesoZagotovka", "Д+Д+Д", "Д+Д", "k", 1, "Д/kП<=3", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObMatushkinaBanka", "Sprites/Cards/ObMatushkinaBanka", "Д+Д+К", "Р+Е", "r", 1, "Р/rП<+3", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObMelnica", "Sprites/Cards/ObMelnica", "Д+Д+Д", "Р+Е", "red", 2, "ПО+З/red", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObMestoSobrani", "Sprites/Cards/ObMestoSobrani", "Д+Д+К", "Р+КР", "r", 2, "", "ПО+КР/r", 0, 1));
        CardManager.AllCards.Add(new Card("ObMisioner", "Sprites/Cards/ObMisioner", "Е+Е", "ПО+Р", "r", 3, "-Р-О=ПО+ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObMolodLes", "Sprites/Cards/ObMolodLes", "Д", "Д+Д", "k", 3, "-Р=Д", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObMolodLes", "Sprites/Cards/ObMolodLes", "Д", "Д+Д", "k", 3, "-Р=Д", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObMolodLes", "Sprites/Cards/ObMolodLes", "Д", "Д+Д", "k", 3, "-Р=Д", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObNosilshiki", "Sprites/Cards/ObNosilshiki", "Д+Д", "Р+К", "r", 3, "-Е/П=Т+ПР", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObOgorodnik", "Sprites/Cards/ObOgorodnik", "Д+Д+Д", "Р+З", "r", 1, "ВЫбр ПР=ПР", "КР", 0, 1)); // муть
        CardManager.AllCards.Add(new Card("ObOhotnikDjo", "Sprites/Cards/ObOhotnikDjo", "Д", "Д+Е", "red", 3, "-Р=Е+Е", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObOrujeinik", "Sprites/Cards/ObOrujeinik", "Д+К", "ПО+К", "blak", 1, "О", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObOrujeinik", "Sprites/Cards/ObOrujeinik", "Д+К", "ПО+К", "blak", 1, "О", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObOrujeinik", "Sprites/Cards/ObOrujeinik", "Д+К", "ПО+К", "blak", 1, "О", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObOtkritiRudnik", "Sprites/Cards/ObOtkritiRudnik", "К", "К+К", "s", 3, "-Р=К", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObPamatnik", "Sprites/Cards/ObPamatnik", "К", "ПО+К", "f", 1, "ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObPekar", "Sprites/Cards/ObPekar", "Д+Д+К", "ПО+Е", "red", 2, "", "ПО+КР/redП", 0, 1));
        CardManager.AllCards.Add(new Card("ObPivovar", "Sprites/Cards/ObPivovar", "Д", "Д+Е", "red", 3, "-Е=ПО", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObPlotnik", "Sprites/Cards/ObPlotnik", "Д+Д+К", "ПО+Д", "k", 3, "-Р-Д-Д=ПО+ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObPodradchik", "Sprites/Cards/ObPodradchik", "Д+К+К", "З+К", "s", 2, "ПО+З/sП", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObPoselenci", "Sprites/Cards/ObPoselenci", "Д", "Р+Д", "r", 3, "-Д=ИПрерПСброс", "", 0, 1));// муть
        CardManager.AllCards.Add(new Card("ObPosolok", "Sprites/Cards/ObPosolok", "Д+К", "Р+Р", "r", 1, "ПР=Р+Р", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObPostoalDvor", "Sprites/Cards/ObPostoalDvor", "Д+К+К", "З+К", "j", 2, "", "ПО+КР/jП", 0, 1));
        CardManager.AllCards.Add(new Card("ObPridvorSkulptor", "Sprites/Cards/ObPridvorSkulptor", "К", "Р+К", "s", 3, "-К=ПО", "", 2, 1));



        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpDremuchiyLes", "Sprites/CardsVarvar/VarImpDremuchiyLes", "Д", "", "", 4, "Д+Д", "", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpKapishe", "Sprites/CardsVarvar/VarImpKapishe", "Д+Д+П", "", "", 6, "-Р=ПО", "", 2, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpKapishe", "Sprites/CardsVarvar/VarImpKapishe", "Д+Д+П", "", "", 6, "-Р=ПО", "", 2, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpKapishe", "Sprites/CardsVarvar/VarImpKapishe", "Д+Д+П", "", "", 6, "-Р=ПО", "", 2, 2));
    }
    
}
    

