using UnityEditor;
using UnityEngine;

public class FindMissingScripts : EditorWindow
{
    [MenuItem("Tools/Buscar Scripts Perdidos")]
    static void FindMissing()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        int count = 0;

        foreach (GameObject go in allObjects)
        {
            Component[] components = go.GetComponents<Component>();

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] == null)
                {
                    Debug.LogWarning($"GameObject '{go.name}' tiene un script perdido.", go);
                    count++;
                }
            }
        }

        Debug.Log($"Búsqueda terminada. Total de scripts perdidos: {count}");
    }
}