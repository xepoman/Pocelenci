using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovementScr : MonoBehaviour, IBeginDragHandler, IDragHandler , IEndDragHandler
{
    Camera MainCamera;
    Vector2 offset; // значение отступа от центра карты до края карты
    public Transform DefaultParent ,DefaultTempCardParent;
    GameObject TempCardGO;
    public bool IsDraggable; // показывает можно переносить карту в это поле
    public GameManagerScr GameManager;

    void Awake()
    {
        MainCamera = Camera.allCameras[0]; // если на сцене всего одна камера 
        TempCardGO = GameObject.Find("TempCardGO");
        GameManager = FindObjectOfType<GameManagerScr>();
    }
    public void OnBeginDrag(PointerEventData eventData) // выполняется единожды при перетягивании обьекта
    {
        //от текущей позиции карты отнимаем конвертированную позицию миши
        offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);
        // приравниваем к радителю нашей карты
        DefaultParent = DefaultTempCardParent = transform.parent;
        
        if (GameManager.PerezagruzkaFielCard.Count % 2 == 0 && GameManager.PerezagruzkaFielCard.Count !=0)
        {
            IsDraggable = DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.ROZIGRISH_POLE && GameManager.IsPlayerTurn;
        }
        else
        {  // присвоем дрэгу евляется ли наш родитель рукойкарт игрока(что бы игрок мог передвигать карту) 
            IsDraggable = (DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_HAND
          //вкл если надо разрешить перетягивание    //   || DefaultParent.GetComponent<DropPlaceScr>().Type == FieldType.Player_POLE_PROIZVODSTVO
                                                    //    || DefaultParent.GetComponent<DropPlaceScr>().Type == FieldType.Player_POLE_OSOBENOST
                                                    //    || DefaultParent.GetComponent<DropPlaceScr>().Type == FieldType.Player_POLE_DEISTVIE
                                                        || DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_IMPERIA_PROIZVODSTVO
                                                        || DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_IMPERIA_OSOBENOST
                                                        || DefaultParent.GetComponent<DropPlaceScr>().Typee == FieldType.Player_IMPERIA_DEISTVIE
                                                      //  || DefaultParent.GetComponent<DropPlaceScr>().Type == FieldType.ROZIGRISH_POLE
                                                        )
                                                        && GameManager.IsPlayerTurn // проверка че ход
                                                        ;
        }
        
        if (!IsDraggable)
            return;

        //появление временной карты на месте поднетой карты
        TempCardGO.transform.SetParent(DefaultParent);
        // отслеживание индекса текушей карты (в ирархии обьектов на сцене)
        TempCardGO.transform.SetSiblingIndex(transform.GetSiblingIndex());
        // перемешаем по иэрархии присваевая ее родителя к ее родителю
        transform.SetParent(DefaultParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)// выполняется каждый кадр пока тянем обьект
    {
        if (!IsDraggable)
            return;

        // текушая позиция взтяие координат в плоскости экрана  а нам нужны в world координаты (движение карты)
        Vector2 newPos = MainCamera.ScreenToWorldPoint(eventData.position); 
        transform.position = newPos + offset; // перемешение карты с отступом

        if(TempCardGO.transform.parent != DefaultTempCardParent)
        {
            TempCardGO.transform.SetParent(DefaultTempCardParent);
        }
        //для того что бы нельзя было менть карты местали можно дописать усовие
        ChekPosition();
        
    }

    public void OnEndDrag(PointerEventData eventData) // единожды когда отпустим обьект
    {
        //  Debug.Log(DefaultParent);
     //   Debug.Log(eventData.pointerEnter);
        if (!IsDraggable) //|| GameManager.PerezagruzkaFielCard.Count % 2 != 0) проверку сделать если карт не четное чило то больше брать нельзя
            return;
        // присвоили родителя хроняшей в DefoltParent
        transform.SetParent(DefaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        //устанавлеваем поднятой карте позицию временной
        transform.SetSiblingIndex(TempCardGO.transform.GetSiblingIndex());
        // вернули времену карту за пределы канваса после того как на ее место пооложили поднятую карту
        TempCardGO.transform.SetParent(GameObject.Find("Canvas").transform);
        TempCardGO.transform.localPosition = new Vector3(1170, 0);
    }
    void ChekPosition()
    {
        //Проходим по индексу текушей сетки иэрархии с лева на права
        // и сравниваем позицию по Х если позиция поднятой карты меньше значит она должна находится слева
        // тогда присваеваем значение i  тут же делаем проверку если индек меньше временой карты то i уменьшаем 
        int newIndex = DefaultTempCardParent.childCount;

        for(int i =0; i<DefaultTempCardParent.childCount; i++ )
        {
            if(transform.position.x < DefaultTempCardParent.GetChild(i).position.x)
            {
                newIndex = i;

                if (TempCardGO.transform.GetSiblingIndex() < newIndex)
                    newIndex--;

                break;
            }
        }
        // устанавлеваем временный индек этой карте
        TempCardGO.transform.SetSiblingIndex(newIndex);
    }
}
