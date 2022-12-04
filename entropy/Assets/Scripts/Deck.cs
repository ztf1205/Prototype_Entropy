using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public GameObject cardStack;

    private const int handCardMax = 5;
    private const int deckCardMax = 20;

    private GameObject deckCardStack;
    private GameObject tombCardStack;
    private GameObject[] handCardStacks = new GameObject[handCardMax];

    private void Awake()
    {
        int i;

        //deck
        deckCardStack = Instantiate(cardStack,
            new Vector3(-2, transform.position.y, 4), transform.rotation);
        deckCardStack.GetComponent<DeckCardStack>().DeckBuild(deckCardMax);

        //hand
        for(i = 0; i < handCardMax; i++)
        {
            handCardStacks[i]= Instantiate(cardStack,
            new Vector3(i, transform.position.y, 5), transform.rotation);
        }

        //tomb
        tombCardStack = Instantiate(cardStack,
            new Vector3(6, transform.position.y, 4), transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //card
        int i;
        int handCount = 0;

        for(i = 0; i < handCardMax; i++)
        {
            handCount += handCardStacks[i].GetComponent<DeckCardStack>().Count();
        }

        if(handCount == 0)
        {
            if(DrawCard() == false)
            {
                DeckReBuild();
                DrawCard();
            }
        }
    }

    bool DrawCard()
    {
        int i;
        GameObject card;

        if(deckCardStack.GetComponent<DeckCardStack>().Count() == 0)
        {
            return false;
        }
        else
        {
            for(i = 0; i < handCardMax; i++)
            {
                card = deckCardStack.GetComponent<DeckCardStack>().Pop();
                handCardStacks[i].GetComponent<DeckCardStack>().Push(card);
                card.GetComponent<DeckCard>().setIdx(i);
            }
            return true;
        }
    }

    void DeckReBuild()
    {
        //¹«´ýÆÐ¸¦ µ¦À¸·Î ¿Å±â±â
        int i;

        for(i = 0; i < deckCardMax; i++)
        {
            deckCardStack.GetComponent<DeckCardStack>().Push(
                 tombCardStack.GetComponent<DeckCardStack>().Pop());
        }
    }

    public void UseCard(int idx)
    {
        GameObject card;
        card = handCardStacks[idx].GetComponent<DeckCardStack>().Pop();
        tombCardStack.GetComponent<DeckCardStack>().Push(card);
    }
}
