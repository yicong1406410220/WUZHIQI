using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    static public GameController Instance;
    public float SpaceX = 46;
    public float SpaceY = 46;
    public GameObject GameCanvas;
    public GameObject[] Pieces;
    public Transform AnchorpointTF;

    public ChildBase[,] childBases = new ChildBase[17, 17];

    //回合类型
    public TurnType turnType = TurnType.Black;

    //回合数
    public int NumberRounds = 0;

    // Use this for initialization
    void Start () {
        Instance = this;

        //NewChess(2, 4, Pieces[0]);

    }
	
	// Update is called once per frame
	void Update ()
    {
        ClickMouse();

    }

    /// <summary>
    /// 检测鼠标点击事件
    /// </summary>
    private void ClickMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 _pos = Vector2.one;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(AnchorpointTF as RectTransform, Input.mousePosition, null, out _pos);
            if (Mathf.Abs(_pos.x) < (SpaceX * 15 / 2) && Mathf.Abs(_pos.y) < (SpaceY * 15 / 2))
            {
                Debug.Log("pos:" + _pos);
                for (int i = 1; i < 16; i++)
                {
                    for (int j = 1; j < 16; j++)
                    {
                        float lx = -(SpaceX * 14 / 2) + (i - 1) * SpaceX;
                        float ly = (SpaceY * 14 / 2) - (j - 1) * SpaceY;
                        if ((_pos.x < lx + SpaceX / 2) && (_pos.x > lx - SpaceX / 2) 
                            && (_pos.y < ly + SpaceY / 2) && (_pos.y > ly - SpaceY / 2))
                        {
                            //NewChess(i, j, Pieces[0]);
                            CheckChessExist(i, j);
                        }
                    }
                }

            }
            else
            {
                Debug.Log("pos:无效输入");
            }
        }
    }

    /// <summary>
    /// 检测棋子是否存在
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    private void CheckChessExist(int x, int y)
    {
        if (childBases[x,y] == null)
        {
            NewChess(x, y, Pieces[0]);
        }
        else
        {
            Debug.Log("CheckChessExist:棋子存在");
        }
    }

    /// <summary>
    /// new出一个新棋子
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="Piece"></param>
    private void NewChess(int x, int y, GameObject Piece)
    {
        Vector2 pos;
        pos.x = -(SpaceX * 14 / 2) + (x - 1) * SpaceX;
        pos.y = (SpaceY * 14 / 2) - (y - 1) * SpaceY;
        GameObject go;
        if (NumberRounds % 2 == 0)
        {
            go = Instantiate(Pieces[0], AnchorpointTF);
        }
        else
        {
            go = Instantiate(Pieces[1], AnchorpointTF);
        }    
        go.transform.localPosition = pos;
        childBases[x, y] = go.GetComponent<ChildBase>();
        childBases[x, y].SetLocationXY(x, y);
        childBases[x, y].roundNumber = NumberRounds;
        CheckWin(x, y);
    }

    /// <summary>
    /// 检测输赢
    /// </summary>
    private void CheckWin(int i, int j)
    {
            if (childBases[i, j] != null)
            {
                if (childBases[i, j].childType == ChildType.Black)
                {
                    int Number = 0;
                    for (int f = -4; f < 5; f++)
                    {                       
                        int dx = i + f;
                        if (dx < 1 && dx >15)
                        {
                            Number = 0;
                            continue;
                        }
                        int dy = j + f;
                        if (dy < 1 && dy > 15)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy] == null)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy].childType == ChildType.Black)
                        {
                            Number++;
                        }
                        if (Number > 4)
                        {
                            Debug.Log("黑棋赢");
                        }
                    }
                    Number = 0;
                    for (int f = -4; f < 5; f++)
                    {
                        int dx = i - f;
                        if (dx < 1 && dx > 15)
                        {
                            Number = 0;
                            continue;
                        }
                        int dy = j + f;
                        if (dy < 1 && dy > 15)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy] == null)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy].childType == ChildType.Black)
                        {
                            Number++;
                        }
                        if (Number > 4)
                        {
                            Debug.Log("黑棋赢");
                        }
                    }
                    Number = 0;
                    for (int f = -4; f < 5; f++)
                    {
                        int dx = i + f;
                        if (dx < 1 && dx > 15)
                        {
                            Number = 0;
                            continue;
                        }
                        int dy = j;
                        if (dy < 1 && dy > 15)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy] == null)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy].childType == ChildType.Black)
                        {
                            Number++;
                        }
                        if (Number > 4)
                        {
                            Debug.Log("黑棋赢");
                        }
                    }
                    Number = 0;
                    for (int f = -4; f < 5; f++)
                    {
                        int dx = i;
                        if (dx < 1 && dx > 15)
                        {
                            Number = 0;
                            continue;
                        }
                        int dy = j + f;
                        if (dy < 1 && dy > 15)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy] == null)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy].childType == ChildType.Black)
                        {
                            Number++;
                        }
                        if (Number > 4)
                        {
                            Debug.Log("黑棋赢");
                        }
                    }

                }
                else if (childBases[i, j].childType == ChildType.White)
                {
                    int Number = 0;
                    for (int f = -4; f < 5; f++)
                    {                       
                        int dx = i + f;
                        if (dx < 1 && dx > 15)
                        {
                            Number = 0;
                            continue;
                        }
                        int dy = j + f;
                        if (dy < 1 && dy > 15)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy] == null)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy].childType == ChildType.White)
                        {
                            Number++;
                        }
                        if (Number > 4)
                        {
                            Debug.Log("白棋赢");
                        }
                    }
                    Number = 0;
                    for (int f = -4; f < 5; f++)
                    {
                        int dx = i - f;
                        if (dx < 1 && dx > 15)
                        {
                            Number = 0;
                            continue;
                        }
                        int dy = j + f;
                        if (dy < 1 && dy > 15)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy] == null)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy].childType == ChildType.White)
                        {
                            Number++;
                        }
                        if (Number > 4)
                        {
                            Debug.Log("白棋赢");
                        }
                    }
                    Number = 0;
                    for (int f = -4; f < 5; f++)
                    {
                        int dx = i + f;
                        if (dx < 1 && dx > 15)
                        {
                            Number = 0;
                            continue;
                        }
                        int dy = j;
                        if (dy < 1 && dy > 15)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy] == null)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy].childType == ChildType.White)
                        {
                            Number++;
                        }
                        if (Number > 4)
                        {
                            Debug.Log("白棋赢");
                        }
                    }
                    Number = 0;
                    for (int f = -4; f < 5; f++)
                    {
                        int dx = i;
                        if (dx < 1 && dx > 15)
                        {
                            Number = 0;
                            continue;
                        }
                        int dy = j + f;
                        if (dy < 1 && dy > 15)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy] == null)
                        {
                            Number = 0;
                            continue;
                        }
                        if (childBases[dx, dy].childType == ChildType.White)
                        {
                            Number++;
                        }
                        if (Number > 4)
                        {
                            Debug.Log("白棋赢");
                        }
                    }
                }

            } 
        NumberRounds++;
    }
}

public enum TurnType
{
    NULL,
    Black,
    White,
}
