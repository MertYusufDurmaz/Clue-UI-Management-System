using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    [Tooltip("Sahnedeki tüm ipucu görsellerini (GameObject) buraya sürükleyin.")]
    public List<GameObject> clueImages;

    // Ýpucu bulunduðunda çaðrýlacak (Örn: Kaðýda týkladýðýnda)
    public void UnlockClue(string clueName)
    {
        foreach (var img in clueImages)
        {
            if (img.name == clueName)
            {
                img.SetActive(true);
            }
        }
    }

    // Save Manager için: Hangi ipuçlarý açýk?
    public List<string> GetFoundClues()
    {
        List<string> found = new List<string>();
        foreach (var img in clueImages)
        {
            if (img.activeSelf) found.Add(img.name);
        }
        return found;
    }

    // Save Manager için: Ýpuçlarýný geri yükle
    public void LoadFoundClues(List<string> savedClues)
    {
        // Önce hepsini kapat
        foreach (var img in clueImages) img.SetActive(false);

        // Kayýtlý olanlarý aç
        if (savedClues != null)
        {
            foreach (string name in savedClues)
            {
                foreach (var img in clueImages)
                {
                    if (img.name == name) img.SetActive(true);
                }
            }
        }
    }
}