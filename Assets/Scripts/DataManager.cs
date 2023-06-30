using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int Ammo;
    public int HP;
    private Item[] savedItems;
    private GameObject[] savedObjects;
    private static DataManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            savedItems = new Item[1];
            savedObjects = new GameObject[1];
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SaveItem(int index, Item item)
    {
        if (item != null)
        {
            savedItems[index] = item;
            // Реализуйте сохранение предмета в вашей системе сохранения данных
        }
    }

    public Item GetSavedItem(int index)
    {
        return savedItems[index];
        // Реализуйте получение сохраненного предмета из вашей системы сохранения данных
    }

    public void SaveObject(int index, GameObject obj)
    {
        if (obj != null)
        {
            savedObjects[index] = obj;
            // Реализуйте сохранение игрового объекта в вашей системе сохранения данных
        }
    }

    public GameObject GetSavedObject(int index)
    {
        return savedObjects[index];
        // Реализуйте получение сохраненного игрового объекта из вашей системы сохранения данных
    }
}