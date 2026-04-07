using UnityEngine;

[CreateAssetMenu(fileName = "Molecule", menuName = "Chemistry/Molecule")]
public class MoleculeData : ScriptableObject
{
    public string moleculeName;
    public string formula;

    public int hydrogenCount;
    public int oxygenCount;
    public int carbonCount;
    public int nitrogenCount;

    //public GameObject moleculeObject; // 👈 scene object reference
}