using System.Collections;
using UnityEngine;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public Gameflow gameflow;
    public int requiredKill;
    public TMP_Text missionText;

    public Transform ExitDoor;
    public Transform Player;

    private int currentKill;
    void Start()
    {
        StartCoroutine(VerifyMissions());
    }

    private IEnumerator VerifyMissions()
    {
        yield return VerifyZombieKill();
        yield return VerifyPlayerExit();
        gameflow.OnMissionCompleted();
    }
  
    private IEnumerator VerifyZombieKill()
    {
        currentKill= 0;
        missionText.text = $"Kill {requiredKill} Zombies";
        yield return new WaitUntil(() => currentKill >= requiredKill);
    }

    private IEnumerator VerifyPlayerExit()
    {
        missionText.text = $"Find Exit Door";
        yield return new WaitUntil(IsPlayerExit);

    }

    public void OnZombieKilleed(GameObject zombie) => currentKill++;

    private bool IsPlayerExit()
    {
        float distance =Vector3.Distance(Player.position,ExitDoor.position);
        return distance < 1f;
    }
}
