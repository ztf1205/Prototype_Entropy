using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public GameObject cardStack;

    const int row = 3;
    const int col = 4;
    private GameObject[] cardStacks = new GameObject[row * col];

    int player_x;
    int player_y;

    private void Awake()
    {
        int x, y;
        for (y = 0; y < row; y++)
        {
            for (x = 0; x < col; x++)
            {
                cardStacks[y * col + x] = Instantiate(cardStack,
                    new Vector3(x, transform.position.y, y), transform.rotation);
            }
        }

        player_x = Random.Range(0, col);
        player_y = Random.Range(0, row);
    }

    // Start is called before the first frame update
    void Start()
    {
        AddPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //key
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            MovePlayer('u');
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            MovePlayer('d');
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            MovePlayer('l');
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            MovePlayer('r');
        }
    }

    void AddPlayer()
    {
        cardStacks[player_y * col + player_x].GetComponent<FieldCardStack>().Player_Init();
    }

    public void MovePlayer(char dir)
    {
        int prev_x = player_x;
        int prev_y = player_y;
        GameObject player;
        switch (dir)
        {
            case 'u':
                if(player_y - 1 < 0)
                {
                    return;
                }
                player_y--;
                break;
            case 'd':
                if (player_y + 1 > row - 1)
                {
                    return;
                }
                player_y++;
                break;
            case 'l':
                if (player_x + 1 > col - 1)
                {
                    return;
                }
                player_x++;
                break;
            case 'r':
                if (player_x - 1 < 0)
                {
                    return;
                }
                player_x--;
                break;
            default:
                return;
        }
        player = cardStacks[prev_y * col + prev_x].GetComponent<FieldCardStack>().Pop();
        if (cardStacks[player_y * col + player_x].GetComponent<FieldCardStack>().Count() != 0)
        {
            Destroy(cardStacks[player_y * col + player_x].GetComponent<FieldCardStack>().Pop());
        }
        cardStacks[player_y * col + player_x].GetComponent<FieldCardStack>().Player_Push(player);
    }
}
