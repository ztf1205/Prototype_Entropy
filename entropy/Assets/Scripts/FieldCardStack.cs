using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCardStack : MonoBehaviour
{
    public GameObject card;
    public GameObject playerCard;
    public GameObject goodCard;
    public GameObject badCard;

    private Stack<GameObject> cardStack = new Stack<GameObject>();

    private void Awake()
    {
        int i;
        for (i = 0; i < 5; i++)
        {
            Push(Random.Range(2, 4));
        }
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
        if(type == 2)
        {
            cardStack.Push(Instantiate(goodCard,
                new Vector3(transform.position.x, transform.position.y + (cardStack.Count - 1) * 0.1f, transform.position.z),
                transform.rotation));
        }
        else if(type == 3)
        {
            cardStack.Push(Instantiate(badCard,
                new Vector3(transform.position.x, transform.position.y + (cardStack.Count - 1) * 0.1f, transform.position.z),
                transform.rotation));
        }
        else
        {
            cardStack.Push(Instantiate(card,
                new Vector3(transform.position.x, transform.position.y + (cardStack.Count - 1) * 0.1f, transform.position.z),
                transform.rotation));
        }
    }
    public void Player_Init()
    {
        cardStack.Push(Instantiate(playerCard,
            new Vector3(transform.position.x, transform.position.y + (cardStack.Count - 1) * 0.1f, transform.position.z),
            transform.rotation));
    }
    public void Player_Push(GameObject player)
    {
        cardStack.Push(player);
        player.GetComponent<Transform>().position =
            new Vector3(transform.position.x, transform.position.y + (cardStack.Count - 1) * 0.1f, transform.position.z);
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
