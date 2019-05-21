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
        CardManager.AllCards.Add(new Card("ObDerevna", "Sprites/Cards/ObDerevna",                            "Д",   "P+P", "r", 1,                   "Р", "Р", 0, 1));
        CardManager.AllCards.Add(new Card("ObDerevna", "Sprites/Cards/ObDerevna",                            "Д",   "P+P", "r", 1,                   "Р", "Р", 0, 1));
        CardManager.AllCards.Add(new Card("ObDerevna", "Sprites/Cards/ObDerevna",                            "Д",   "P+P", "r", 1,                   "Р", "Р", 0, 1));
        CardManager.AllCards.Add(new Card("ObDrovaSklad", "Sprites/Cards/ObDrovaSklad",                  "Д+Д+К",   "Д+Д", "k", 2,                    "", "ПО+КР/k", 0, 1));
        CardManager.AllCards.Add(new Card("ObDrovoseki", "Sprites/Cards/ObDrovoseki",                      "Д+Д",   "Д+Д", "k", 3,              "Р=Д+Д", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObGanzeiskiSoyz", "Sprites/Cards/ObGanzeiskiSoyz",            "К+Д+К",  "ПО+З", "j", 3,          "Р-С=ПО+ПО", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObGildiaKamenshikov", "Sprites/Cards/ObGildiaKamenshikov",    "К+Д+Д",   "К+З", "s", 3,     "Р-К-К=ПО+ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObGildiaKamenshikov", "Sprites/Cards/ObGildiaKamenshikov",    "К+Д+Д",   "К+З", "s", 3,     "Р-К-К=ПО+ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObGildiaTorgovcev", "Sprites/Cards/ObGildiaTorgovcev",        "К+Д+Д",   "К+З", "j", 1,             "З/jП<=3", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObImperskiPoslanik", "Sprites/Cards/ObImperskiPoslanik",          "Е",   "Р+З", "red", 3,            "Р=С+Т", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObKamenalomna", "Sprites/Cards/ObKamenalomna",                  "Д+К",   "К+К", "s", 1,                   "К", "К", 0, 1));
        CardManager.AllCards.Add(new Card("ObKamenalomna", "Sprites/Cards/ObKamenalomna",                  "Д+К",   "К+К", "s", 1,                   "К", "К", 0, 1));
        CardManager.AllCards.Add(new Card("ObKamenalomna", "Sprites/Cards/ObKamenalomna",                  "Д+К",   "К+К", "s", 1,                   "К", "К", 0, 1));
        CardManager.AllCards.Add(new Card("ObKamenshik", "Sprites/Cards/ObKamenshik",                      "Д+К",   "Д+К", "s", 3,          "Р-К=ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObKamenshik", "Sprites/Cards/ObKamenshik",                      "Д+К",   "Д+К", "s", 3,          "Р-К=ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObGorodPashni", "Sprites/Cards/ObGorodPashni",                "Д+Д+К",   "Е+Е", "red", 1,         "Е/red <=3", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObKupecMonti", "Sprites/Cards/ObKupecMonti",                  "Д+К+К",   "З+К", "j", 2,             "ПО+З/jП", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObLagerLesoruba", "Sprites/Cards/ObLagerLesoruba",              "Д+Д",   "Д+Д", "k", 1,                   "Д", "Д", 0, 1));
        CardManager.AllCards.Add(new Card("ObLagerLesoruba", "Sprites/Cards/ObLagerLesoruba",              "Д+Д",   "Д+Д", "k", 1,                   "Д", "Д", 0, 1));
        CardManager.AllCards.Add(new Card("ObLagerLesoruba", "Sprites/Cards/ObLagerLesoruba",              "Д+Д",   "Д+Д", "k", 1,                   "Д", "Д", 0, 1));
        CardManager.AllCards.Add(new Card("ObLesopilka", "Sprites/Cards/ObLesopilka",                        "Д",   "Р+Д", "k", 3,               "Д=ПО", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObLesopilka", "Sprites/Cards/ObLesopilka",                        "Д",   "Р+Д", "k", 3,               "Д=ПО", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObMasterskayUvelira", "Sprites/Cards/ObMasterskayUvelira",      "Д+К",  "ПО+З", "j", 3,          "Р-З=ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObMasterskayUvelira", "Sprites/Cards/ObMasterskayUvelira",      "Д+К",  "ПО+З", "j", 3,          "Р-З=ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObLesoZagotovka", "Sprites/Cards/ObLesoZagotovka",            "Д+Д+Д",   "Д+Д", "k", 1,             "Д/kП<=3", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObMatushkinaBanka", "Sprites/Cards/ObMatushkinaBanka",        "Д+Д+К",   "Р+Е", "r", 1,             "Р/rП<=3", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObMelnica", "Sprites/Cards/ObMelnica",                        "Д+Д+Д",   "Р+Е", "red", 2,          "ПО+З/red", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObMestoSobrani", "Sprites/Cards/ObMestoSobrani",              "Д+Д+К",  "Р+КР", "r", 2,                    "", "ПО+КР/r", 0, 1));
        CardManager.AllCards.Add(new Card("ObMisioner", "Sprites/Cards/ObMisioner",                        "Е+Е",  "ПО+Р", "r", 3,       "Р-О=ПО+ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObMolodLes", "Sprites/Cards/ObMolodLes",                          "Д",   "Д+Д", "k", 3,                "Р=Д", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObMolodLes", "Sprites/Cards/ObMolodLes",                          "Д",   "Д+Д", "k", 3,                "Р=Д", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObMolodLes", "Sprites/Cards/ObMolodLes",                          "Д",   "Д+Д", "k", 3,                "Р=Д", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObNosilshiki", "Sprites/Cards/ObNosilshiki",                    "Д+Д",   "Р+К", "r", 3,           "Е/П=Т+ПР", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObOgorodnik", "Sprites/Cards/ObOgorodnik",                    "Д+Д+Д",   "Р+З", "r", 1,          "ВЫбр ПР=ПР", "КР", 0, 1)); // муть
        CardManager.AllCards.Add(new Card("ObOhotnikDjo", "Sprites/Cards/ObOhotnikDjo",                      "Д",   "Д+Е", "red", 3,            "Р=Е+Е", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObOrujeinik", "Sprites/Cards/ObOrujeinik",                      "Д+К",  "ПО+К", "blak", 1,                "О", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObOrujeinik", "Sprites/Cards/ObOrujeinik",                      "Д+К",  "ПО+К", "blak", 1,                "О", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObOrujeinik", "Sprites/Cards/ObOrujeinik",                      "Д+К",  "ПО+К", "blak", 1,                "О", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObOtkritiRudnik", "Sprites/Cards/ObOtkritiRudnik",                "К",   "К+К", "s", 3,                "Р=К", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObPamatnik", "Sprites/Cards/ObPamatnik",                          "К",  "ПО+К", "f", 1,                  "ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObPekar", "Sprites/Cards/ObPekar",                            "Д+Д+К",  "ПО+Е", "red", 2,                  "", "ПО+КР/red", 0, 1));
        CardManager.AllCards.Add(new Card("ObPivovar", "Sprites/Cards/ObPivovar",                            "Д",   "Д+Е", "red", 3,             "Е=ПО", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObPlotnik", "Sprites/Cards/ObPlotnik",                        "Д+Д+К",  "ПО+Д", "k", 3,     "Р-Д-Д=ПО+ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObPodradchik", "Sprites/Cards/ObPodradchik",                  "Д+К+К",   "З+К", "s", 2,             "ПО+З/sП", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObPoselenci", "Sprites/Cards/ObPoselenci",                        "Д",   "Р+Д", "r", 3,      "Д=ИПрерПСброс", "", 0, 1));// муть
        CardManager.AllCards.Add(new Card("ObPosolok", "Sprites/Cards/ObPosolok",                          "Д+К",   "Р+Р", "r", 1,              "Р+Р", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObPostoalDvor", "Sprites/Cards/ObPostoalDvor",                "Д+К+К",   "З+К", "j", 2,                 "", "ПО+КР/j", 0, 1));
        CardManager.AllCards.Add(new Card("ObPridvorSkulptor", "Sprites/Cards/ObPridvorSkulptor",            "К",   "Р+К", "s", 3,            "К=ПО", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObPshenPole", "Sprites/Cards/ObPshenPole",                      "Д+Е",   "Е+Е", "red", 1,              "Е", "Е", 0, 1));
        CardManager.AllCards.Add(new Card("ObPshenPole", "Sprites/Cards/ObPshenPole",                      "Д+Е",   "Е+Е", "red", 1,              "Е", "Е", 0, 1));
        CardManager.AllCards.Add(new Card("ObRazvalini", "Sprites/Cards/ObRazvalini",                    "Д+Д+К",   "К+К", "s", 1,          "К/sП<=3", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObRinok", "Sprites/Cards/ObRinok",                              "Д+Д",   "З+Д", "j", 3,  "Д-К-Е=ПО+ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObRuini", "Sprites/Cards/ObRuini",                                 "",      "", "ff", 2,                "", "Р", 0, 1));
        CardManager.AllCards.Add(new Card("ObRuini", "Sprites/Cards/ObRuini",                                 "",      "", "ff", 2,                "", "Р", 0, 1));
        CardManager.AllCards.Add(new Card("ObRuini", "Sprites/Cards/ObRuini",                                 "",      "", "ff", 2,                "", "Р", 0, 1));
        CardManager.AllCards.Add(new Card("ObRuini", "Sprites/Cards/ObRuini",                                 "",      "", "ff", 2,                "", "Р", 0, 1));
        CardManager.AllCards.Add(new Card("ObRuini", "Sprites/Cards/ObRuini",                                 "",      "", "ff", 2,                "", "Р", 0, 1));
        CardManager.AllCards.Add(new Card("ObRuini", "Sprites/Cards/ObRuini",                                 "",      "", "ff", 2,                "", "Р", 0, 1));
        CardManager.AllCards.Add(new Card("ObSkomorohi", "Sprites/Cards/ObSkomorohi",                      "Д+Д",   "Р+Д", "r", 3,"Р=ресет П действ", "Р", 0, 1)); // муть
        CardManager.AllCards.Add(new Card("ObStarLes", "Sprites/Cards/ObStarLes",                          "Д+Д",   "Д+Д", "k", 1,              "Д+Д", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObStatua", "Sprites/Cards/ObStatua",                          "Д+К+К",  "ПО+К", "s", 2,                 "", "ПО+КР/s", 0, 1));
        CardManager.AllCards.Add(new Card("ObStolar", "Sprites/Cards/ObStolar",                            "Д+Д",  "ПО+Д", "k", 3,       "Р-Д=ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObStolar", "Sprites/Cards/ObStolar",                            "Д+Д",  "ПО+Д", "k", 3,       "Р-Д=ПО+ПО", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObStolarMasterskai", "Sprites/Cards/ObStolarMasterskai",      "Д+Д+Д",   "З+Д", "k", 2,          "ПО+З/kП", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObStorojBashna", "Sprites/Cards/ObStorojBashna",                "Д+Д", "КР+КР", "blue", 1,            "КР", "КР", 0, 1));
        CardManager.AllCards.Add(new Card("ObStorojBashna", "Sprites/Cards/ObStorojBashna",                "Д+Д", "КР+КР", "blue", 1,            "КР", "КР", 0, 1));
        CardManager.AllCards.Add(new Card("ObStorojBashna", "Sprites/Cards/ObStorojBashna",                "Д+Д", "КР+КР", "blue", 1,            "КР", "КР", 0, 1));
        CardManager.AllCards.Add(new Card("ObStorojBashna", "Sprites/Cards/ObStorojBashna",                "Д+Д", "КР+КР", "blue", 1,            "КР", "КР", 0, 1));
        CardManager.AllCards.Add(new Card("ObTaverna", "Sprites/Cards/ObTaverna",                          "Д+К", "КР+КР", "blue", 3, "КРсрук=ПО+ПО", "КР", 0, 1)); // муть
        CardManager.AllCards.Add(new Card("ObTraktir", "Sprites/Cards/ObTraktir",                        "Д+Д+Д",   "Р+Е", "r", 2,          "3+ПО/rП", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObUgolnayShahta", "Sprites/Cards/ObUgolnayShahta",              "Д+К",   "Р+К", "s", 3,           "Р=К+К", "", 0, 1));
        CardManager.AllCards.Add(new Card("ObVisilica", "Sprites/Cards/ObVisilica",                        "Д+Д",  "ПО+Д", "blak", 2,   "ПО/разруш П", "", 0, 1)); // муть
        CardManager.AllCards.Add(new Card("ObZamok", "Sprites/Cards/ObZamok",                              "Д+К", "КР+КР", "blue", 3,         "Р=КР", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObZamok", "Sprites/Cards/ObZamok",                              "Д+К", "КР+КР", "blue", 3,         "Р=КР", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObZamok", "Sprites/Cards/ObZamok",                              "Д+К", "КР+КР", "blue", 3,         "Р=КР", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObZolotoRudnik", "Sprites/Cards/ObZolotoRudnik",                "Д+К",  "ПО+З", "j", 3,             "Р=З", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObZolotoRudnik", "Sprites/Cards/ObZolotoRudnik",                "Д+К",  "ПО+З", "j", 3,             "Р=З", "", 2, 1));
        CardManager.AllCards.Add(new Card("ObZolotoyPriisk", "Sprites/Cards/ObZolotoyPriisk",              "Д+К",   "Р+З", "j", 1,                "З", "", 0, 1));

        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpDremuchiyLes", "Sprites/CardsVarvar/VarImpDremuchiyLes", "Д", "", "k", 4, "Д+Д", "", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpDremuchiyLes", "Sprites/CardsVarvar/VarImpDremuchiyLes", "Д", "", "k", 4, "Д+Д", "", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpDremuchiyLes", "Sprites/CardsVarvar/VarImpDremuchiyLes", "Д", "", "k", 4, "Д+Д", "", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpKapishe", "Sprites/CardsVarvar/VarImpKapishe", "Д+Д+П", "", "j", 6, "Р=ПО", "", 2, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpKapishe", "Sprites/CardsVarvar/VarImpKapishe", "Д+Д+П", "", "j", 6, "Р=ПО", "", 2, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpKapishe", "Sprites/CardsVarvar/VarImpKapishe", "Д+Д+П", "", "j", 6, "Р=ПО", "", 2, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpGranica", "Sprites/CardsVarvar/VarImpGranica", "Д+К+П", "", "blak", 5, "Р=ПО", "", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpDelegacia", "Sprites/CardsVarvar/VarImpDelegacia", "Д+Д+П", "", "blue", 6, "Р=2КР однусбросить", "", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpIdol", "Sprites/CardsVarvar/VarImpIdol", "К+К+К+П", "", "r", 5, "", "ПО+ПО+ПО+ПО", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpRazboiniki", "Sprites/CardsVarvar/VarImpRazboiniki", "Д+П", "", "red", 6, "Р=ПО+КР", "", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpNabeg", "Sprites/CardsVarvar/VarImpNabeg", "Д+П", "", "blak", 5, "разруш=ПО", "", 0, 2)); // муть
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpNabeg", "Sprites/CardsVarvar/VarImpNabeg", "Д+П", "", "blak", 5, "разруш=ПО", "", 0, 2)); // муть
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpNabeg", "Sprites/CardsVarvar/VarImpNabeg", "Д+П", "", "blak", 5, "разруш=ПО", "", 0, 2)); // муть
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpDiversant", "Sprites/CardsVarvar/VarImpDiversant", "Д+П", "", "blak", 6, "Р=Д||К||Е", "", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpDiversant", "Sprites/CardsVarvar/VarImpDiversant", "Д+П", "", "blak", 6, "Р=Д||К||Е", "", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpDozorBashna", "Sprites/CardsVarvar/VarImpDozorBashna", "Д+Д+П", "", "r", 4, "Р+О", "", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpDozorBashna", "Sprites/CardsVarvar/VarImpDozorBashna", "Д+Д+П", "", "r", 4, "Р+О", "", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpTemnKapishe", "Sprites/CardsVarvar/VarImpTemnKapishe", "Д+К+К+П", "", "blak", 6, "VerhMuty", "", 0, 2)); // муть
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpTemnKapishe", "Sprites/CardsVarvar/VarImpTemnKapishe", "Д+К+К+П", "", "blak", 6, "VerhMuty", "", 0, 2)); // муть
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpBanda", "Sprites/CardsVarvar/VarImpBanda", "Д+П", "", "blak", 6, "Р=П враг + бон разр", "", 2, 2)); // муть
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpBanda", "Sprites/CardsVarvar/VarImpBanda", "Д+П", "", "blak", 6, "Р=П враг + бон разр", "", 2, 2)); // муть
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpOtrebe", "Sprites/CardsVarvar/VarImpOtrebe", "Д+П", "", "blue", 6, "Р-Р= Разр П свою", "", 0, 2)); // муть
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpOtrebe", "Sprites/CardsVarvar/VarImpOtrebe", "Д+П", "", "blue", 6, "Р-Р= Разр П свою", "", 0, 2)); // муть
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpOtrebe", "Sprites/CardsVarvar/VarImpOtrebe", "Д+П", "", "blue", 6, "Р-Р= Разр П свою", "", 0, 2)); // муть
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpSelenie", "Sprites/CardsVarvar/VarImpSelenie", "Д", "", "r", 4, "Р+Р", "", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpSelenie", "Sprites/CardsVarvar/VarImpSelenie", "Д", "", "r", 4, "Р+Р", "", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpKrepost", "Sprites/CardsVarvar/VarImpKrepost", "Д+Д+П", "", "blak", 5, "", "ПО/blak П имп", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpEkspedicia", "Sprites/CardsVarvar/VarImpEkspedicia", "Д+К+П", "", "blak", 6, "О=З+ПО+ПО", "", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpKarer", "Sprites/CardsVarvar/VarImpKarer", "К+П", "", "blak", 4, "О+К", "", 0, 2));
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpBaraholka", "Sprites/CardsVarvar/VarImpBaraholka", "Д+П", "", "j", 6, "Люб 2 рес = ПО+ПО", "", 2, 2)); // муть
        CardManager.AllCardsImperiaVarvar.Add(new Card("VarImpBoycovKlub", "Sprites/CardsVarvar/VarImpBoycovKlub", "Д+К+П", "", "blak", 6, "Р-Р=О+О", "", 0, 2));
    }
    
}
    

