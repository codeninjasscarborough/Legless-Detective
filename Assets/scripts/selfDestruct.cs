using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selfDestruct : MonoBehaviour
{
    public float timeToDestruct;
    private float timer = 0f;
    public TMP_Text timerText;

    [SerializeField] private string nextSceneName;
    [SerializeField] private float delayLoad = 0.1f;
    // Start is called before the first frame update

    void Start()
    {
        Invoke(nameof(playerDestory), timeToDestruct);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timeToDestruct < timer)
        {
            timerText.text = "DEAD";
        }
        else
            timerText.text = "TIME LEFT: " + (timeToDestruct - timer).ToString("F2");
    }


    void playerDestory()
    {
        var children = transform.GetComponentsInChildren<Transform>();
        foreach (var child in children)
        {
            child.transform.parent = null;
            child.gameObject.AddComponent<Rigidbody>();
            child.gameObject.AddComponent<BoxCollider>();
            child.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(10f, 51f), Random.Range(10f, 20f), Random.Range(10f, 50f)));
            child.GetComponent<Rigidbody>().useGravity = true;
        }
        Destroy(GetComponent<CharacterController>());
        Destroy(GetComponent<Rigidbody>());

        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        Debug.Log("Player exploded! Waiting...");
        yield return new WaitForSeconds(delayLoad);
        SceneManager.LoadScene(nextSceneName);
    }
}
