using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AtomSpawner : MonoBehaviour
{
    public GameObject atomPrefab;

    private GameObject currentAtom;

    void Start()
    {
        SpawnAtom();
    }

    void SpawnAtom()
    {
        currentAtom = Instantiate(atomPrefab, transform.position, transform.rotation, transform);

        var grab = currentAtom.GetComponent<XRGrabInteractable>();
        grab.selectEntered.AddListener(OnGrabbed);
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        // 👇 THIS IS THE KEY LINE
        currentAtom.transform.SetParent(null);

        // Spawn new atom
        Invoke(nameof(SpawnAtom), 0.2f);
    }
}