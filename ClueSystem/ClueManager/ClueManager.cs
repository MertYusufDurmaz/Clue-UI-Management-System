using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    [Tooltip("Sahnedeki tüm ipucu görsellerini (GameObject) buraya sürükleyin.")]
    public List<GameObject> clueImages;

    // İpucu bulunduğunda çağrılacak (Örn: Kağıda tıkladığında)
    public void UnlockClue(string clueName)
    {
        foreach (var img in clueImages)
        {
            if (img.name == clueName)
            {
                img.SetActive(true);
                break; // Eşleşme bulunduysa döngüyü boşuna yorma
            }
        }
    }

    // Save Manager için: Hangi ipuçları açık?
    public List<string> GetFoundClues()
    {
        List<string> found = new List<string>();
        foreach (var img in clueImages)
        {
            if (img.activeSelf) found.Add(img.name);
        }
        return found;
    }

    // Save Manager için: İpuçlarını geri yükle
    public void LoadFoundClues(List<string> savedClues)
    {
        // Önce hepsini kapat
        foreach (var img in clueImages) img.SetActive(false);

        // Kayıtlı olanları aç
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
