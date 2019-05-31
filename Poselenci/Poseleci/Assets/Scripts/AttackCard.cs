using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : MonoBehaviour
{
    private bool flagDestroy = false;
    public void RashetDestroyCard()// метод расчета удаления карт
    {
        if (GetComponent<GameManagerScr>().AttackCardPole.Count > 1) // если карт в поле атаке больше 1
        {
            string resAtackPosled = GetComponent<GameManagerScr>().AttackCardPole[GetComponent<GameManagerScr>().AttackCardPole.Count-1].SelfCard.resursRazrushenia; // ресурс атакуюшей карты
            if (!flagDestroy)
                CiklRashetaDestroy(GetComponent<GameManagerScr>().PlayerPoleDeystvieCard, resAtackPosled);
            if (!flagDestroy)
                CiklRashetaDestroy(GetComponent<GameManagerScr>().PlayerPoleSvoistvaCard, resAtackPosled);
            if (!flagDestroy)
                CiklRashetaDestroy(GetComponent<GameManagerScr>().PlayerPoleProizvodstvaCard, resAtackPosled);
            
            flagDestroy = false;
        }
    }
    void CiklRashetaDestroy(List<CardInfoScr> PlayerPole , string resAtackPosled) // метод цикл проверки карт и сравнения с атакой
    {
        for (int i = 0; i < PlayerPole.Count; i++)
        {
            if (PlayerPole[i].SelfCard.resursRazrushenia != "")
            {
                string[] split = PlayerPole[i].SelfCard.resursRazrushenia.Split('+');
                for (int t = 0; t < GetComponent<GameManagerScr>().AttackCardPole.Count; t++)
                {
                    string resAtackSled = GetComponent<GameManagerScr>().AttackCardPole[t].SelfCard.resursRazrushenia;

                 //   Debug.Log("Первая " + resAtackSled);
                  //  Debug.Log("последня " + resAtackPosled);
                    if (split[0] == resAtackPosled)
                    {
                        if (split[1] == resAtackSled)
                        {
                            DestroyAtack(i);
                        }
                    }
                    else if (split[1] == resAtackPosled)
                    {
                        if (split[0] == resAtackSled)
                        {
                            DestroyAtack(i);
                        }
                    }
                }
            }
        }
    }
    void DestroyAtack(int i) // метод удаления карты при атаке
    {
        if (GetComponent<GameManagerScr>().PlayerPoleDeystvieCard.Count != 0)
        {
          //  Debug.Log("Dei");
            GetComponent<GameManagerScr>().PlayerPoleDeystvieCard.Remove(GetComponent<GameManagerScr>().PlayerPoleDeystvieCard[i]);
            Destroy(GetComponent<GameManagerScr>().PlayerPoleDeystvieCard[i].gameObject);
            flagDestroy = true;
        }
        else if (GetComponent<GameManagerScr>().PlayerPoleProizvodstvaCard.Count != 0)
        {
          //  Debug.Log("Proi");
            GetComponent<GameManagerScr>().PlayerPoleProizvodstvaCard.Remove(GetComponent<GameManagerScr>().PlayerPoleProizvodstvaCard[i]);
            Destroy(GetComponent<GameManagerScr>().PlayerPoleProizvodstvaCard[i].gameObject);
            flagDestroy = true;
        }
        else if (GetComponent<GameManagerScr>().PlayerPoleSvoistvaCard.Count != 0)
        {
          //  Debug.Log("Svoi");
            GetComponent<GameManagerScr>().PlayerPoleSvoistvaCard.Remove(GetComponent<GameManagerScr>().PlayerPoleSvoistvaCard[i]);
            Destroy(GetComponent<GameManagerScr>().PlayerPoleSvoistvaCard[i].gameObject);
            flagDestroy = true;
        }
    }
}
