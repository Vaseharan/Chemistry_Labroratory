using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoleculeDatabase", menuName = "Chemistry/Database")]
public class MoleculeDatabase : ScriptableObject
{
    public List<MoleculeData> molecules;
}