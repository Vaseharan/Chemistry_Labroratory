using System.Collections.Generic;
using UnityEngine;

public class ReactionZone : MonoBehaviour
{
    public List<AtomController> atomsInZone = new List<AtomController>();

    public MoleculeDatabase database;

    public UIManager uiManager;

    // 👇 NEW: mapping system
    public List<MoleculeEntry> moleculeEntries;

    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AtomController atom))
        {
            atomsInZone.Add(atom);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out AtomController atom))
        {
            atomsInZone.Remove(atom);
        }
    }

    public void React()
    {
        int h = 0, o = 0, c = 0, n = 0;

        foreach (var atom in atomsInZone)
        {
            switch (atom.atomType)
            {
                case AtomType.Hydrogen: h++; break;
                case AtomType.Oxygen: o++; break;
                case AtomType.Carbon: c++; break;
                case AtomType.Nitrogen: n++; break;
            }
        }

        foreach (var molecule in database.molecules)
        {
            if (molecule.hydrogenCount == h &&
                molecule.oxygenCount == o &&
                molecule.carbonCount == c &&
                molecule.nitrogenCount == n)
            {
                ActivateMolecule(molecule);
                return;
            }
        }

        Debug.Log("No valid reaction");
    }

    void ActivateMolecule(MoleculeData data)
    {
        Debug.Log("Created: " + data.moleculeName);

        // Destroy atoms
        foreach (var atom in atomsInZone)
        {
            Destroy(atom.gameObject);
        }

        atomsInZone.Clear();

        // 🔥 Find corresponding scene object
        foreach (var entry in moleculeEntries)
        {
            if (entry.data == data)
            {
                entry.sceneObject.transform.position = spawnPoint.position;
                entry.sceneObject.SetActive(true);
                uiManager.AddMolecule(data.moleculeName);

                return;
            }
        }
    }
}