using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCard : MonoBehaviour
{
    public char dir;

    private GameObject field;
    private GameObject deck;

    private int idx;

    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        field = GameObject.FindGameObjectWithTag("Field");
        deck = GameObject.FindGameObjectWithTag("Deck");
    }

    private void Update()
    {

    }

    void OnMouseDown()
    {
        if(isActive)
        {
            field.GetComponent<Field>().MovePlayer(dir);
            deck.GetComponent<Deck>().UseCard(idx);
            isActive = false;
        }
    }

    public void setIdx(int idx)
    {
        this.idx = idx;
        isActive = true;
    }
}
