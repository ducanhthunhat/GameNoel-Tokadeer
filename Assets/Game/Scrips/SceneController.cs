using System.Collections;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator anim;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    
    IEnumerator LoadLevel()
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        anim.SetTrigger("Start");

    }
}
