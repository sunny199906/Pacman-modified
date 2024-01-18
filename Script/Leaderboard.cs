using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Transform row;
    public Transform table;

    private void Awake()
    {
        table = transform.Find("Table");
        row = table.Find("RowData");

        row.gameObject.SetActive(false);

        float rowHeight = 20f;
        List<GameRecord> leaderBoard = GameDataController.singGameData.currentGameData.leaderBoard;
        Debug.Log("Print size: "+ leaderBoard.Count);
        for (int i = 0;i < 5; i++) {
            if (i<=leaderBoard.Count-1)
            {
                Transform transform = Instantiate(row, table);
                RectTransform rectTranform = transform.GetComponent<RectTransform>();
                rectTranform.anchoredPosition = new Vector2(290, -rowHeight * i - 17);
                transform.gameObject.SetActive(true);

                GameRecord gameRecord = leaderBoard[i];

                transform.Find("Rank").GetComponent<TMPro.TextMeshProUGUI>().text = (i + 1).ToString();
                transform.Find("Name").GetComponent<TMPro.TextMeshProUGUI>().text = gameRecord.playerName;
                transform.Find("Score").GetComponent<TMPro.TextMeshProUGUI>().text = gameRecord.score.ToString();
            }
            

        }
    }
}
