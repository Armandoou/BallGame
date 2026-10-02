using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class GameResetter : MonoBehaviour
{
    [Header("UI")]
    public GameObject victoryPanel;
    public CollectibleCounter counter;   

    [Header("Arrastra aquí Ball y Game")]
    public Transform[] rootsToReset;

    private class SavedState
    {
        public Transform t;
        public Vector3 pos;
        public Quaternion rot;
        public Vector3 scale;
        public bool active;
    }

    private readonly List<SavedState> saved = new List<SavedState>();

    private void Awake()
    {
        foreach (Transform root in rootsToReset)
        {
            foreach (Transform t in root.GetComponentsInChildren<Transform>(true))
            {
                saved.Add(new SavedState
                {
                    t = t,
                    pos = t.position,
                    rot = t.rotation,
                    scale = t.localScale,
                    active = t.gameObject.activeSelf
                });
            }
        }

        victoryPanel.SetActive(false);
    }

    
    public void ShowVictory()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    
    public void ResetAll()
    {
        Time.timeScale = 1f;

        foreach (SavedState s in saved)
        {
            s.t.gameObject.SetActive(s.active);
            s.t.SetPositionAndRotation(s.pos, s.rot);
            s.t.localScale = s.scale;

            if (s.t.TryGetComponent(out Rigidbody rb) && !rb.isKinematic)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }

        if (counter != null) counter.ResetCount();

        victoryPanel.SetActive(false);
    }
}