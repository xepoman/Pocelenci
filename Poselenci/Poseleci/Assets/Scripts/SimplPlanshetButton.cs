﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimplPlanshetButton : MonoBehaviour
{
    public Animator simplMenuAnim;
    public Animator contentResPlanshet;
    ResursCards resCard;
    bool isHiddle;
    public Sprite vklBtnSvoystvaPlanshet;
    public Sprite otklBtnSvoystvaPlanshet;
    public Image imageBtnSvoiystvaPlansheta;
    public Image imageBtnDeystviePlansheta;
    int tempObEmploe;
    public bool ProverkaSvoistvPlansheta = false;
    private void Start()
    {
        RectTransform transform = contentResPlanshet.gameObject.transform as RectTransform; //для панели выбора ресурсов действий планшета перемеешение за приделы видемости при запуске 
        Vector2 position = transform.anchoredPosition;                                      //
        position.x -= transform.rect.width;                                                 //
        transform.anchoredPosition = position;                                              //
    }
    void Awake()
    {
        resCard = FindObjectOfType<ResursCards>();
        isHiddle = false;
    }
    public void SimplPlanshetaBtn()
    {
        if (!isHiddle && GetComponent<GameManagerScr>().boolRaund)// включение и отключение всплываюшей панели при нажатии на планшет
        {
            simplMenuAnim.SetBool("isHiddle", true);
            isHiddle = true;
        }
        else
        {
            simplMenuAnim.SetBool("isHiddle", false);
            isHiddle = false;
        }
    }
    public void DeystviePlanshetBtn() // кнопка вызова выбора ресурсов для обмена
    {
        contentResPlanshet.enabled = true;
        bool isHidle = contentResPlanshet.GetBool("isHiddle");
        contentResPlanshet.SetBool("isHiddle", !isHidle);

        if (imageBtnDeystviePlansheta.sprite == vklBtnSvoystvaPlanshet)
        {
            imageBtnDeystviePlansheta.sprite = otklBtnSvoystvaPlanshet;
            return;
        }

        if (imageBtnDeystviePlansheta.sprite == otklBtnSvoystvaPlanshet)
        {
            imageBtnDeystviePlansheta.sprite = vklBtnSvoystvaPlanshet;
            return;
        }
        
    }
    public void ObmenResDerevoBtn()
    {
        if (resCard.ObEmploe >= 2)
        {
            resCard.ObEmploe -= 2;
            resCard.ObDerevo += 1;
        }
        else
        {
            return;
        }
    }
    public void ObmenResKamenBtn()
    {
        if (resCard.ObEmploe >= 2)
        {
            resCard.ObEmploe -= 2;
            resCard.ObKamen += 1;
        }
        else
        {
            return;
        }
    }
    public void ObmenResGoldBtn()
    {
        if (resCard.ObEmploe >= 2)
        {
            resCard.ObEmploe -= 2;
            resCard.ObGold += 1;
        }
        else
        {
            return;
        }
    }
    public void ObmenResEdaBtn()
    {
        if (resCard.ObEmploe >= 2)
        {
            resCard.ObEmploe -= 2;
            resCard.ObEda += 1;
        }
        else
        {
            return;
        }
    }
    public void SvoistavPlanshetBtn() //кнопка свойств планшета  для сохранения ресурса работника
    {
        if (imageBtnSvoiystvaPlansheta.sprite == vklBtnSvoystvaPlanshet)
        {
            imageBtnSvoiystvaPlansheta.sprite = otklBtnSvoystvaPlanshet;
            resCard.ObEmploe += tempObEmploe;
            ProverkaSvoistvPlansheta = false;
            return;
        }

        if(imageBtnSvoiystvaPlansheta.sprite == otklBtnSvoystvaPlanshet)
        {
            imageBtnSvoiystvaPlansheta.sprite = vklBtnSvoystvaPlanshet;
            tempObEmploe = resCard.ObEmploe;
            resCard.ObEmploe = 0;
            ProverkaSvoistvPlansheta = true;
            return;
        }
    }
}