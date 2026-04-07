using UnityEngine;

public enum AtomType
{
    Hydrogen,
    Oxygen,
    Carbon,
    Nitrogen
}

public class AtomController : MonoBehaviour
{
    public AtomType atomType;
}