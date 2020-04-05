using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;


    //Singleton
    public static CameraFollow Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }


        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        transform.position = player.position + offset;
    }

}