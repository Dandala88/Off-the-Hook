using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int calorieTarget;

    [SerializeField]
    private int numberOfFood;
    [SerializeField]
    private int numberOfBait;
    [SerializeField]
    private List<FoodItem> foodItemPrefabs;
    [SerializeField]
    private List<BaitItem> baitItemPrefabs;

    [HideInInspector]
    public int calories;
    [HideInInspector]
    public bool isPaused;

    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        SpawnFoodAndBait();
    }

    private void SpawnFoodAndBait()
    {
        TopWater topWater = FindObjectOfType<TopWater>();
        var topwaterMesh = topWater.GetComponent<MeshRenderer>();
        float minZ = -400;
        float maxZ = 500;
        float minY = 1;
        float maxY = topWater.transform.position.y - 3;
        float minX = -15;
        float maxX = 15;

        for (int i = 0; i < numberOfFood; i++)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            float z = Random.Range(minZ, maxZ);
            int prefabIndex = Random.Range(0, foodItemPrefabs.Count);
            var clone = Instantiate(foodItemPrefabs[prefabIndex]);
            clone.transform.position = new Vector3(x, y, z);
        }

        for (int i = 0; i < numberOfBait; i++)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            float z = Random.Range(minZ, maxZ);
            int prefabIndex = Random.Range(0, baitItemPrefabs.Count);
            var clone = Instantiate(baitItemPrefabs[prefabIndex]);
            clone.transform.position = new Vector3(x, y, z);
        }
    }
}
