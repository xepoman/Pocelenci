using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ZoomCard : MonoBehaviour
{
    public Image image;
    public GameObject btnDeystvieGO;  
    private GameObject tempCardGO;// временый обьект для передачи
    ResursCards resursCards;
    public bool flagVibrCard = false;
    private void Start()
    {
        btnDeystvieGO.SetActive(false); // отклюячение кнопки если это не карта действия
        image.enabled = false; // отключение если не выбрана карта
        resursCards = FindObjectOfType<ResursCards>();
    }
    public void ImageZoomCard(Image pole) // функция получает при клике изображение карты и показывает ее увеличенно
    {
        image.enabled = true;
        image.sprite = pole.sprite;
    }
    public void DeystvieCardSchetRes(GameObject cardGO, FieldType Typee)// функция принимает обьект для получения  действий 
    {
        tempCardGO = cardGO;
        if (Typee == FieldType.Player_IMPERIA_DEISTVIE || Typee == FieldType.Player_POLE_DEISTVIE) // проверка поля действия
        {
            if (cardGO.GetComponent<CardInfoScr>().SelfCard.polePlansheta == 3
                            || cardGO.GetComponent<CardInfoScr>().SelfCard.polePlansheta == 6) //проверка что карта действие
            {
                btnDeystvieGO.SetActive(true);
                
            }
            else
            {
                btnDeystvieGO.SetActive(false);
            }
        }
        else
        {
            btnDeystvieGO.SetActive(false);
        }
    }
    public void DeystviaChetaResBtn() // кнопка  дейсвий карты
    {
        switch(tempCardGO.GetComponent<CardInfoScr>().SelfCard.svoistvaCard)
        {
            case "Р=Д+Д":
                if (resursCards.ObEmploe >= 1)
                {
                    resursCards.ObEmploe -= 1;
                    resursCards.ObDerevo += 2;
                }
                    return;
            case "Р=К+К":
                if (resursCards.ObEmploe >= 1)
                {
                    resursCards.ObEmploe -= 1;
                    resursCards.ObKamen += 2;
                }
                return;
            case "Р-С=ПО+ПО":
                if (resursCards.ObEmploe >= 1)
                {
                    resursCards.ObEmploe -= 1;
                    //  - c сделка для мультиплеера
                    resursCards.ObPO += 2;
                }
                   return;
            case "Р-К-К=ПО+ПО+ПО":
                if (resursCards.ObEmploe >= 1 && resursCards.ObKamen>=2)
                {
                    resursCards.ObEmploe -= 1;
                    resursCards.ObKamen -= 2;
                    resursCards.ObPO += 3;
                }
                   return;
            case "Р=С+Т":
                if (resursCards.ObEmploe >= 1)
                {
                    // для мультипреера
                }
                  return;
            case "Р-К=ПО+ПО":
                if (resursCards.ObEmploe >= 1 && resursCards.ObKamen >= 1)
                {
                    resursCards.ObEmploe -= 1;
                    resursCards.ObKamen -= 1;
                    resursCards.ObPO += 2;
                }
                   return;
            case "Д=ПО":
                if (resursCards.ObDerevo >= 1)
                {
                    resursCards.ObDerevo -= 1;
                    resursCards.ObPO += 1;
                }
                   return;
            case "Р-З=ПО+ПО":
                if (resursCards.ObGold >= 1 && resursCards.ObEmploe >=1)
                {
                    resursCards.ObGold -= 1;
                    resursCards.ObEmploe -= 1;
                    resursCards.ObPO += 2;
                }
                return;
            case "Р-О=ПО+ПО+ПО":
                if (resursCards.ObOrujee >= 1 && resursCards.ObEmploe >= 1)
                {
                    resursCards.ObOrujee -= 1;
                    resursCards.ObEmploe -= 1;
                    resursCards.ObPO += 3;
                }
                return;
            case "Р=Д":
                if (resursCards.ObEmploe >= 1)
                {
                    resursCards.ObEmploe -= 1;
                    resursCards.ObDerevo += 1;
                }
                return;
            case "Е/П=Т+ПР":
                if (resursCards.ObEda >= 1)
                {
                    // действие для выбора производства подсветить и дописать функцию выбора
                }
                return;
            case "Р=Е+Е":
                if (resursCards.ObEmploe >= 1)
                {
                    resursCards.ObEmploe -= 1;
                    resursCards.ObEda += 2;
                }
                return;
            case "Р=К":
                if (resursCards.ObEmploe >= 1)
                {
                    resursCards.ObEmploe -= 1;
                    resursCards.ObKamen += 1;
                }
                return;
            case "Е=ПО":
                if (resursCards.ObEda >= 1)
                {
                    resursCards.ObEda -= 1;
                    resursCards.ObPO += 1;
                }
                return;
            case "Р-Д-Д=ПО+ПО+ПО":
                if (resursCards.ObEmploe >= 1 && resursCards.ObDerevo >=2)
                {
                    resursCards.ObEmploe -= 1;
                    resursCards.ObDerevo -= 2;
                    resursCards.ObPO += 3;
                }
                return;
            case "Д=ИПрерПСброс":
                if (resursCards.ObDerevo >= 1)
                {
                    // минус дерево тут же строим имперскую постройку не разрушая карты
                }
                return;
            case "К=ПО":
                if (resursCards.ObKamen >= 1)
                {
                    resursCards.ObKamen -= 1;
                    resursCards.ObPO += 1;
                }
                return;
            case "Д-К-Е=ПО+ПО+ПО":
                if (resursCards.ObEda >= 1&& resursCards.ObDerevo >= 1 && resursCards.ObKamen >= 1)
                {
                    resursCards.ObEda -= 1;
                    resursCards.ObDerevo -= 1;
                    resursCards.ObKamen -= 1;
                    resursCards.ObPO += 3;
                }
                return;
            case "Р=ресет П действ":
                //дает возможность повторно активировать карту действий
                return;
            case "Р-Д=ПО+ПО":
                if (resursCards.ObEmploe >= 1 && resursCards.ObDerevo>=1)
                {
                    resursCards.ObEmploe -= 1;
                    resursCards.ObDerevo -= 1;
                    resursCards.ObPO += 2;
                }
                return;
            case "КРсру=ПО+ПО":
                //сброс карты с рук получиш очки
                return;
            case "Р=КР":
                if (resursCards.ObEmploe >= 1 )
                {
                    GetComponent<SimplPlanshetButton>().btnViborGO.SetActive(true);
                    flagVibrCard = true;
                    // добавить карту 
                }
                return;
            case "Р=З":
                if (resursCards.ObEmploe >= 1)
                {
                    resursCards.ObEmploe -= 1;
                    resursCards.ObGold += 1;
                }
                return;
            case "Р=ПО":
                if (resursCards.ObEmploe >= 1)
                {
                    resursCards.ObEmploe -= 1;
                    resursCards.ObPO += 1;
                }
                return;
            case "Р=2КР однусброситьО":
                if (resursCards.ObEmploe >= 1)
                {
                    // из двух карт выбарть одну
                }
                return;
            case "Р=Д||К||Е":
                // на выбор что заменить
                return;
            case "VerhMuty":
                // на выбор что заменить
                return;
            case "Р=П враг + бон разр":
                // на выбор что заменить
                return;
            case "Р-Р= Разр П свою":
                // на выбор что заменить
                return;
            case "О=З+ПО+ПО":
                if (resursCards.ObOrujee >= 1)
                {
                    resursCards.ObOrujee -= 1;
                    resursCards.ObGold += 1;
                    resursCards.ObPO += 2;
                }
                return;
            case "Люб 2 рес = ПО+ПО":
                // на выбор что заменить
                return;
            case "Р-Р=О+О":
                if (resursCards.ObEmploe >= 2)
                {
                    resursCards.ObEmploe -= 2;
                    resursCards.ObOrujee += 2;
                }
                return;
        }
    }
}
