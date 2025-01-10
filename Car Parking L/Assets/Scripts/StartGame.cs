using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
   public static bool IsGameStarted = false;
   public GameObject Logo, PlayImage, CountMoves;
   
   public void PlayGame()
   {
    IsGameStarted = true;
    Logo.SetActive(false);
    PlayImage.SetActive(false);
    CountMoves.SetActive(true);
   }

public void LoseGame()
{
    IsGameStarted = false;
    Logo.SetActive(true);
    PlayImage.SetActive(true);
    CountMoves.SetActive(false);




}










}
