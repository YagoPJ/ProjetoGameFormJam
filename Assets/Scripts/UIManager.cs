using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject aboutButton;
    [SerializeField] GameObject customizeButton;
    [SerializeField] GameObject previousButton;
    [SerializeField] GameObject nextButton;

    Animator startAnim;
    Animator aboutAnim;
    Animator customizeAnim;
    Animator previousAnim;
    Animator nextAnim;
    [SerializeField] Animator fadeBlockAnim;

    [SerializeField] List<Mesh> shooterMesh;
    [SerializeField] List<Texture> shooterMaterial;

    [SerializeField] GameObject player;

    private int modelIndex;

    private void Start()
    {
        startAnim = startButton.gameObject.GetComponent<Animator>();
        aboutAnim = aboutButton.gameObject.GetComponent<Animator>();
        customizeAnim = customizeButton.gameObject.GetComponent<Animator>();
        modelIndex = 0;
    }
    public void Customize()
    {
        startAnim.Play("StartButtonFadeOut");
        aboutAnim.Play("AboutButtonFadeOut");
        customizeAnim.Play("CustomizeButtonFadeOut");

        fadeBlockAnim.Play("FadeBlockerOut");

        previousButton.SetActive(true);
        nextButton.SetActive(true);
        modelIndex = 0;
    }

    public void NextModel()
    {
        modelIndex++;
        if (modelIndex >= 0)
            player.GetComponent<MeshFilter>().mesh = shooterMesh[modelIndex];
    }

    public void PreviousModel()
    {
        modelIndex--;
        if (modelIndex >= 0)
            player.GetComponent<Material>().mainTexture = shooterMaterial[modelIndex];
    }
}
