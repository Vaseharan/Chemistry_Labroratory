using UnityEngine;

public class SceneReset : MonoBehaviour
{
    public GameObject[] moleculeObjects;

    public void ResetScene()
    {
        AtomController[] atoms = FindObjectsOfType<AtomController>();

        foreach (var atom in atoms)
        {
            // 👇 ONLY destroy grabbed atoms
            if (atom.transform.parent == null)
            {
                Destroy(atom.gameObject);
            }
        }

        // Disable molecules
        foreach (var molecule in moleculeObjects)
        {
            molecule.SetActive(false);
        }

        Debug.Log("Scene Reset Complete");
    }
}