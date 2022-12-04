using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCardStack : MonoBehaviour
{
    public GameObject card_up;
    public GameObject card_down;
    public GameObject card_left;
    public GameObject card_right;

    private Stack<GameObject> cardStack = new Stack<GameObject>();

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Push(int type)
    {
        if (type == 0)
        {
            cardStack.Push(Instantiate(card_up,
                new Vector3(transform.position.x, transform.position.y + (cardStack.Count - 1) * 0.1f, transform.position.z),
                card_up.transform.rotation));
        }
        else if (type == 1)
        {
            cardStack.Push(Instantiate(card_down,
                new Vector3(transform.position.x, transform.position.y + (cardStack.Count - 1) * 0.1f, transform.position.z),
                card_down.transform.rotation));
        }
        else if (type == 2)
        {
            cardStack.Push(Instantiate(card_left,
                new Vector3(transform.position.x, transform.position.y + (cardStack.Count - 1) * 0.1f, transform.position.z),
                card_left.transform.rotation));
        }
        else if (type == 3)
        {
            cardStack.Push(Instantiate(card_right,
                new Vector3(transform.position.x, transform.position.y + (cardStack.Count - 1) * 0.1f, transform.position.z),
                card_right.transform.rotation));
        }
    }
    public void Push(GameObject card)
    {
        cardStack.Push(card);
        card.GetComponent<Transform>().position =
            new Vector3(transform.position.x, transform.position.y + (cardStack.Count - 1) * 0.1f, transform.position.z);
    }

    public void DeckBuild(int n)
    {
        int i;
        for (i = 0; i < n; i++)
        {
            Push(Random.Range(0, 4));
        }
    }

    public GameObject Pop()
    {
        return cardStack.Pop();
    }
    public GameObject Peek()
    {
        return cardStack.Peek();
    }

    public int Count()
    {
        return cardStack.Count;
    }
}
