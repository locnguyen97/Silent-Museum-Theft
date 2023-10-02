using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] List<GameObject> particleVFXs;
    

    private int startIndex = 0;

    private int currentIndex;
    [SerializeField] private List<Level> levels;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        currentIndex = startIndex;
        levels[currentIndex].gameObject.SetActive(true);
    }
    
    
    public void CheckLevelUp()
    {
        currentIndex += 1;
        GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], transform.position, transform.rotation);
        Destroy(explosion, .75f);
        StartCoroutine(LevelUp());
    }
    IEnumerator LevelUp()
    {
        
        yield return new WaitForSeconds(1);
        levels[currentIndex-1].gameObject.SetActive(false);
        if (currentIndex == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            currentIndex = 0;
        }
        else
        {
            levels[currentIndex].gameObject.SetActive(true);
        }
    }


    public bool CheckAndMove(int id)
    {
        var level = levels[currentIndex];
        var listPostMove = level.listPostMove;
        var player = level.player;

        if(player.isMoving) return false;
        var posWantMove = listPostMove.Find(l=> l.indexPoint == id);
        var posPlayer = listPostMove.Find(l => l.indexPoint == player.curentPos);
        if (posPlayer != null)
        {
            if (posPlayer.listCanMove.Exists(l => l == id))
            {
                player.MoveToPos(posWantMove.transform,id);
                return true;
            }
        }

        return false;
    }
    
}
