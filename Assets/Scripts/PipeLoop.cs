using System.Collections.Generic;
using UnityEngine;

public class PipeLoop : MonoBehaviour
{
    [SerializeField] Manager manager;
    [SerializeField] GameObject pipe;

    public Queue<GameObject> pipesQueue = new Queue<GameObject>();

    private float loopTimer;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject obj = Instantiate(pipe);
            obj.SetActive(false);
            pipesQueue.Enqueue(obj);
        }

        StartCoroutine(nameof(Loop));
    }
    private void Update()
    {
        loopTimer += Time.deltaTime;
        if (loopTimer >= 2.4f)
        {
            Loop();
            loopTimer = 0;
        }
    }

    public GameObject GetObject()
    {
        GameObject pipe = pipesQueue.Dequeue();
        pipe.SetActive(true);
        pipesQueue.Enqueue(pipe);
        return pipe;
    }

    private void Loop()
    {
        if (manager.state==Manager.State.Playing)
        {
            var pipe = GetObject();
            pipe.transform.position = new Vector3(7, Random.Range(-1.7f, 1.7f), 0);
        }
    }

    public void Restart()
    {
        for (int i = 0; i < pipesQueue.Count; i++)
        {
            GameObject pipe = pipesQueue.Dequeue();
            pipe.SetActive(false);
            pipesQueue.Enqueue(pipe);
        }
    }

}
