using System.Runtime.InteropServices;
using UnityEngine;

public class LeaderBoardController : MonoBehaviour
{
    [DllImport("__Internal")] private static extern void SetToLeaderboard(int value);

    public int coinsAmount = 0;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("CoinsAmount"))
        {
            coinsAmount = PlayerPrefs.GetInt("CoinsAmount");
        }
        SetToLeader(coinsAmount);
    }

    public void SetToLeader(int value)
    {
#if !UNITY_EDITOR
        SetToLeaderboard(value);
#endif
    }
}
