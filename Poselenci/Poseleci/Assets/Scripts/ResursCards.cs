using System.Collections;
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
    
    private GameManagerScr GameManager;
    void Awake()
    {
        GameManager = FindObjectOfType<GameManagerScr>();
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
        EmploeTxt.text = "Emploe " + ObEmploe.ToString();
        DerevoTxt.text = "Derevo " + ObDerevo.ToString();
        KamenTxt.text = "Kamen " + ObKamen.ToString();
        GoldTxt.text = "Gold " + ObGold.ToString();
        EdaTxt.text = "Eda " + ObEda.ToString();
        POTxt.text = "PO " + ObPO.ToString();
        OrujeeTxt.text = "Orujee " + ObOrujee.ToString();
    }
    public void PlanshetVarvar()
    {
        ObEmploe = 5;
        ObOrujee = 1;
    }
}



