using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Game
{
    public List<Card> ObDeckCard;
    public List<Card> ImpVarDeckCard;
    public List<Card> AttackDeckCard;

    public Game()
    {
        ObDeckCard = ObGiveDeckCard(); //Колода общих кард
        ImpVarDeckCard = ImpVarGiveDeckCard(); // колода имперских кард
        AttackDeckCard = AttackGiveDeckCard(); // колода атаки 
    }
    List<Card> AttackGiveDeckCard()
    {
        //перетусовка карт колоды из всех кард по принцепу  алгоритм Кнута-Фишера-Йейтса
        for (int i = CardManager.AllAttackCards.Count - 1; i > 0; i--)
        {
            int n = Random.Range(0, i + 1);
            var tmp = CardManager.AllAttackCards[n];
            CardManager.AllAttackCards[n] = CardManager.AllAttackCards[i];
            CardManager.AllAttackCards[i] = tmp;
        }
        return CardManager.AllAttackCards;
    }
    List<Card> ObGiveDeckCard()
    {
        //перетусовка карт колоды из всех кард по принцепу  алгоритм Кнута-Фишера-Йейтса
        for (int i = CardManager.AllCards.Count - 1; i > 0; i--)
        {
            int n = Random.Range(0,i+1);
            var tmp = CardManager.AllCards[n];
            CardManager.AllCards[n] = CardManager.AllCards[i];
            CardManager.AllCards[i] = tmp;
        }
        return CardManager.AllCards;
    }
    List<Card> ImpVarGiveDeckCard()
    {
        //перетусовка карт колоды из всех кард по принцепу  алгоритм Кнута-Фишера-Йейтса
        for (int i = CardManager.AllCardsImperiaVarvar.Count - 1; i > 0; i--)
        {
            int n = Random.Range(0, i + 1);
            var tmp = CardManager.AllCardsImperiaVarvar[n];
            CardManager.AllCardsImperiaVarvar[n] = CardManager.AllCardsImperiaVarvar[i];
            CardManager.AllCardsImperiaVarvar[i] = tmp;
        }
        return CardManager.AllCardsImperiaVarvar;
    }
}


public class GameManagerScr : MonoBehaviour
{
    public Game CurrentGame;
    public Transform AttackEnemyPole;// поле атаки
    public Transform EnemyHand, PlayerHand, PerezagruzkaHand, ImpVarFiel ; // руки противника и игрока и поле перезагрузки и  имперская
    public GameObject ObCardPref; // префаб общих карт
    public GameObject ImpVarCardPref; // префаб Имперских карт Варвары карт
    public GameObject AttackCardPref; // префаб карты атаки
    int Turn, TurnTime = 30;
    public TextMeshProUGUI TurnTimeTxt; // текстовый счетчик
    public Button EndTurBtn; // кнопка конца хода;
    public TextMeshProUGUI RaundTxt;


    public List<CardInfoScr> PlayerHandCard = new List<CardInfoScr>(),// карты на руке игрока
                             ImpVarFieldCard = new List<CardInfoScr>(),// карты на поле имперской колоды
                             EnemyHandCard = new List<CardInfoScr>(),// карты на руке врага
                            PerezagruzkaFielCard = new List<CardInfoScr>(),// карты на поле перезагрузки
                            PlayerPoleDeystvieCard = new List<CardInfoScr>(), // карты на поле действия
                            PlayerPoleProizvodstvaCard = new List<CardInfoScr>(), // карты на поле действия
                            PlayerPoleSvoistvaCard = new List<CardInfoScr>(), // карты на поле действия
                            PlayerImpPoleDeystvieCard = new List<CardInfoScr>(), // карты на поле империи действия
                            PlayerImpPoleProizvodstvaCard = new List<CardInfoScr>(), // карты на поле империи производства
                            PlayerImpPolevSvoistvaCard = new List<CardInfoScr>(), // карты на поле империи свойства
                            AttackCardPole = new List<CardInfoScr>(); // карты на поле
     private int numberRaund;
     public bool boolRaund;

    public bool IsPlayerTurn
    {
        get
        {
            return Turn % 2 == 0; // проверка игрок или враг
        }
    }

    private void Start()
    {
        Turn = 0;
        numberRaund = 0;
        CurrentGame = new Game();
        boolRaund = false;
        GiveAttackTo(CurrentGame.AttackDeckCard, AttackEnemyPole);// начальная карта атаки
        GiveImperHandCards(CurrentGame.ImpVarDeckCard, ImpVarFiel, false); // выдача имерских карт игроку при начале игры
        GiveImperHandCards(CurrentGame.ImpVarDeckCard, PlayerHand, true); // выдача имерских карт игроку при начале игры
        GiveImperHandCards(CurrentGame.ImpVarDeckCard, PlayerHand, true); // выдача имерских карт игроку при начале игры
        GiveHandCards(CurrentGame.ObDeckCard, PlayerHand, 2);// выдача карт игроку
        GiveHandCards(CurrentGame.ObDeckCard, PerezagruzkaHand, 4);// выдоча карт на поле выбора карт

        StartCoroutine(TurnFunc());
    }
    private void Update()
    {
        RaundTxt.text = "Raund " + numberRaund.ToString();
    }
    public void GiveImperHandCards(List<Card> deck, Transform hand, bool inicil) // принемает список карт руки в трансформе руки
    {
        //Если в колоде нет карт выходим из функции
        if (deck.Count == 0)
            return;
        //берем карту из колоды
        Card card = deck[0];
        //создаем копию карты префаба
        GameObject cardGO = Instantiate(ImpVarCardPref, hand, false);
        if (inicil)
        {
            // вызов функции показа карты
            cardGO.GetComponent<CardInfoScr>().ShowCardInfo(card);
            PlayerHandCard.Add(cardGO.GetComponent<CardInfoScr>());
        }
        else
        {
            // вызов функции закрытой карты
            cardGO.GetComponent<CardInfoScr>().HideCardInfo(card);
            ImpVarFieldCard.Add(cardGO.GetComponent<CardInfoScr>());
        }
        //удалили карту  из колекции
        deck.RemoveAt(0);

    }

    public void GiveHandCards(List<Card> deck, Transform hand, int inicil) // принемает список карт руки в трансформе руки
    {
        if(inicil == 1)
        {
            GiveCardToHand(deck, hand);
        }
        if (inicil == 2)
        {
            int i = 0;
            while (i++ < 2)
            {
                GiveCardToHand(deck, hand);
            }
        }
        if (inicil == 4)
        {
            int i = 0;
            while (i++ < 4)
            {
                GiveCardToHand(deck, hand);
            }
        }
    }
    void GiveAttackTo(List<Card> deck, Transform AttackEnemyPole) // методы создания карты атаки
    {
        if (deck.Count == 0)
            return;
        //берем карту из колоды
        Card card = deck[0];
        //создаем копию карты префаба
        GameObject cardGO = Instantiate(AttackCardPref, AttackEnemyPole, false);
        cardGO.GetComponent<CardInfoScr>().ShowCardInfo(card);
        AttackCardPole.Add(cardGO.GetComponent<CardInfoScr>());
        deck.RemoveAt(0);
    }
    void GiveCardToHand(List<Card> deck, Transform hand) // функция выдачи стартовых карт
    {
        //Если в колоде нет карт выходим из функции
        if (deck.Count == 0)
            return;
        //берем карту из колоды
        Card card = deck[0];

        //создаем копию карты префаба
        GameObject cardGO = Instantiate(ObCardPref, hand, false);

        // вызов функции показа карты
        cardGO.GetComponent<CardInfoScr>().ShowCardInfo(card);
        if (hand == PlayerHand)
        {
            // Добавили в список карты обшего поля и руки игрока
            PlayerHandCard.Add(cardGO.GetComponent<CardInfoScr>());
        }
        else
        {
            PerezagruzkaFielCard.Add(cardGO.GetComponent<CardInfoScr>());
        }
       
        //удалили карту  из колекции
        deck.RemoveAt(0);
    }
    IEnumerator TurnFunc()
    {
        TurnTime = 300;
        TurnTimeTxt.text = TurnTime.ToString();
        if(IsPlayerTurn)
        {
            boolRaund = true;
            while (TurnTime-- >0)
            {
               
                // усли ход игрока  отнимаем время от шетчика и замараживаем время на 1 сек
                TurnTimeTxt.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
            }
        }
        else
        {
            Raund();
            // усли ход пративника ждем до 27 сек и пропускает ход
            while (TurnTime-- > 299)
            {
                TurnTimeTxt.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
            }
        }
        ChangeTurn();
    }
    void Raund()
    {
        if (PerezagruzkaFielCard.Count == 0 && CurrentGame.ObDeckCard.Count >= 4)
        {
            GiveHandCards(CurrentGame.ObDeckCard, PerezagruzkaHand, 4);// выдоча карт на поле выбора карт
            GiveImperHandCards(CurrentGame.ImpVarDeckCard, PlayerHand, true);
            while (EnemyHandCard.Count > 0) // цикл удаления карт  в конце раунда с руки врага и добавление очков
            {
                Destroy(EnemyHandCard[EnemyHandCard.Count - 1].gameObject);
                EnemyHandCard.Remove(EnemyHandCard[EnemyHandCard.Count - 1]);
            }
            numberRaund++;
            GiveAttackTo(CurrentGame.AttackDeckCard, AttackEnemyPole);// вызов метода для создания карт атаки в конце раунда
            GiveAttackTo(CurrentGame.AttackDeckCard, AttackEnemyPole);
            GetComponent<AttackCard>().RashetDestroyCard();// вызов метода расчета удаления карт при атаке
            GetComponent<ResursCards>().PlanshetVarvar(); // добовление ресурсов с планшета
            GetComponent<ResursCards>().RaschetResovEndRaund(); // добавление ресурсов в конце раунда с карт
            if (GetComponent<SimplPlanshetButton>().ProverkaSvoistvPlansheta)
            {
                GetComponent<SimplPlanshetButton>().SvoistavPlanshetBtn();// сбросили работников по свойству планшета
            }
            return;
        }
        if (PerezagruzkaFielCard.Count == 0 && CurrentGame.ObDeckCard.Count < 4)
            return;
        boolRaund = false;
        int count = PerezagruzkaFielCard.Count == 1 ? 0: Random.Range(1, PerezagruzkaFielCard.Count);
        
            PerezagruzkaFielCard[count].ShowCardInfo(PerezagruzkaFielCard[count].SelfCard); // показали карту
            PerezagruzkaFielCard[count].transform.SetParent(EnemyHand); // переместили карту от радителя

        EnemyHandCard.Add(PerezagruzkaFielCard[count]);
        PerezagruzkaFielCard.Remove(PerezagruzkaFielCard[count]);
        if (PerezagruzkaFielCard.Count % 2 != 0)
        {
            PerezagruzkaFielCard[0].transform.SetParent(PlayerHand);
          //  PlayerHandCard.Add(PerezagruzkaFielCard[0]);
            PerezagruzkaFielCard.Remove(PerezagruzkaFielCard[0]);
        }
    }
    
    public void ChangeTurn()
    {
        StopAllCoroutines();
        Turn++;
        // включаеи и отключаем кнопку
        EndTurBtn.interactable = IsPlayerTurn;

        // если ход игрока то выдаем по карте
      //  if (IsPlayerTurn)
          //  GiveNewCards();

        StartCoroutine(TurnFunc());
    }
    void GiveNewCards() // функция выдачи новой карты
    {
      //  GiveCardToHand(CurrentGame.EnemyDeck, EnemyHand);
        GiveCardToHand(CurrentGame.ObDeckCard, PlayerHand); // заменит потом на фукцию выдачи карт в  поле перезагрузки 

    }
   
}
