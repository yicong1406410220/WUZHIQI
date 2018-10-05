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



    //public PlaceState[,] placeStates = new PlaceState[17,17];

    // Use this for initialization
    void Start () {
        Instance = this;
        //for (int i = 0; i < 17 ; i++)
        //{
        //    for (int j = 0; j < 17; j++)
        //    {
        //        placeStates[i, j] = PlaceState.NULL;
        //    }
        //}
        //NewChess(2, 4, Pieces[0]);

    }
	
	// Update is called once per frame
	void Update ()
    {
        ClickMouse();

    }

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
                            NewChess(i, j, Pieces[0]);
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
    private void NewChess

    private void NewChess(int x, int y, GameObject Piece)
    {
        Vector2 pos;
        pos.x = -(SpaceX * 14 / 2) + (x - 1) * SpaceX;
        pos.y = (SpaceY * 14 / 2) - (y - 1) * SpaceY;
        GameObject go = Instantiate(Pieces[0], AnchorpointTF);
        go.transform.localPosition = pos;
    }
}

