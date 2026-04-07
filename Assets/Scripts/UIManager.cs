using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI moleculeText;

    private HashSet<string> discoveredMolecules = new HashSet<string>();

    public void AddMolecule(string moleculeName)
    {
        // Avoid duplicates
        if (discoveredMolecules.Contains(moleculeName))
            return;

        discoveredMolecules.Add(moleculeName);

        UpdateUI();
    }

    void UpdateUI()
    {
        moleculeText.text = "Discovered Molecules:\n";

        foreach (var molecule in discoveredMolecules)
        {
            moleculeText.text += "- " + molecule + "\n";
        }
    }
}