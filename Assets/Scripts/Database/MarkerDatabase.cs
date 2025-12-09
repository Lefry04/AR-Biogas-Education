using UnityEngine;

public class MarkerDatabase : MonoBehaviour
{
    public MarkerData[] dataList;   // Isi melalui Inspector

    public MarkerData GetData(string id)
    {
        foreach (var data in dataList)
        {
            if (data.id == id)
                return data;
        }

        Debug.LogWarning("MarkerDatabase: Tidak ada data untuk ID = " + id);
        return null;
    }
}
