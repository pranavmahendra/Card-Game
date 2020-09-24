using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<Button> buttons;
    public Image GameOverCanvas;

    private void Start()
    {
        GameOverCanvas.gameObject.SetActive(false);
    }

    public void DrawButtonsOf()
    {
        buttons[2].gameObject.SetActive(false);
        buttons[3].gameObject.SetActive(false);
    }


    public void ShuffleUIOff()
    {
        for (int i = 0; i < 2; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
    }

    public void GameOverEnable()
    {
        GameOverCanvas.gameObject.SetActive(true);
    }    


    //Switch Sides.
    public void SwitchSide()
    {
        switch (GameManager.PlayerTurn)
        {
            case 0:
                //Debug.Log("Draw Card from Player: " + players[PlayerTurn].gameObject.name);

                buttons[3].gameObject.SetActive(false);
                buttons[2].gameObject.SetActive(true);

                break;
            case 1:
                //Debug.Log("Draw Card from Player: " + players[PlayerTurn].gameObject.name);

                buttons[2].gameObject.SetActive(false);
                buttons[3].gameObject.SetActive(true);

                break;
            default:
                break;
        }
    }
}
