using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    #region Variables
    [SerializeField] GameObject title;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject aboutButton;
    [SerializeField] GameObject customizeButton;
    [SerializeField] GameObject previousButton;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject backCustomizeButton;
    [SerializeField] GameObject backAboutButton;
    [SerializeField] GameObject lifeText;
    [SerializeField] GameObject pointsText;

    Animator startAnim;
    Animator aboutAnim;
    Animator customizeAnim;
    Animator previousAnim;
    Animator nextAnim;
    [SerializeField] Animator fadeBlockAnim;

    [SerializeField] List<Mesh> shooterMesh;
    [SerializeField] List<Material> shooterMaterial;

    [SerializeField] GameObject player;

    [SerializeField] TextMeshProUGUI aboutText;

    [SerializeField] GameObject mainCamera;
    [SerializeField] PlayerController playerControllerScript;

    private int modelIndex;
    #endregion

    #region Start - MonoBehavior
    private void Start()
    {
        startAnim = startButton.gameObject.GetComponent<Animator>();
        aboutAnim = aboutButton.gameObject.GetComponent<Animator>();
        customizeAnim = customizeButton.gameObject.GetComponent<Animator>();
        modelIndex = 0;

        previousButton.SetActive(false);
        nextButton.SetActive(false);
        backCustomizeButton.SetActive(false);
        backAboutButton.SetActive(false);
        lifeText.SetActive(false);
        pointsText.SetActive(false);
    }
    #endregion

    #region Customize
    public void Customize()
    {
        FadeOutMainMenuButtons();

        fadeBlockAnim.Play("FadeBlockerOut");

        previousButton.SetActive(true);
        nextButton.SetActive(true);
        backCustomizeButton.SetActive(true);
    }

    public void NextModel()
    {
        ChangeShooter(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    public void PreviousModel()
    {
        ChangeShooter(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    public void BackFromCustomize()
    {
        BackToMainScreen(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    private void ChangeShooter(string nameOfMethod)
    {
        if (nameOfMethod.Equals("PreviousModel"))
        {
            if (modelIndex > 0 && modelIndex <= (shooterMesh.Count - 1))
            {
                modelIndex--;
                ChangeMeshMaterial();
            }
        }
        else
        {
            if (modelIndex >= 0 && modelIndex < (shooterMesh.Count - 1))
            {
                modelIndex++;
                ChangeMeshMaterial();
            }
        }
    }

    private void ChangeMeshMaterial()
    {
        player.GetComponent<MeshFilter>().mesh = shooterMesh[modelIndex];
        player.GetComponent<MeshRenderer>().material = shooterMaterial[modelIndex];
    }
    #endregion

    #region About
    public void About()
    {
        FadeOutMainMenuButtons();

        backAboutButton.SetActive(true);
        aboutText.gameObject.GetComponent<Animator>().Play("AboutTextIn");
    }
    public void BackFromAbout()
    {
        BackToMainScreen(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
    #endregion

    #region Start Game
    public void StartGame()
    {
        startButton.SetActive(false);
        aboutButton.SetActive(false);
        customizeButton.SetActive(false);
        title.SetActive(false);
        fadeBlockAnim.Play("FadeBlockerOut");

        player.gameObject.GetComponent<Animator>().Play("PlayerStartAnim");

        StartCoroutine(WaitToMoveAndShowPoints());
    }
    #endregion

    #region Utilities
    private void FadeOutMainMenuButtons()
    {
        startAnim.Play("StartButtonFadeOut");
        aboutAnim.Play("AboutButtonFadeOut");
        customizeAnim.Play("CustomizeButtonFadeOut");
    }
    private void FadeInMainMenuButtons()
    {
        startAnim.Play("StartButtonFadeIn");
        aboutAnim.Play("AboutButtonFadeIn");
        customizeAnim.Play("CustomizeButtonFadeIn");
    }
    private void BackToMainScreen(string nameOfMethod)
    {
        FadeInMainMenuButtons();

        if (nameOfMethod.Equals("BackFromCustomize"))
        {
            fadeBlockAnim.Play("FadeBlockerIn");

            previousButton.SetActive(false);
            nextButton.SetActive(false);
            backCustomizeButton.SetActive(false);
        }
        else if (nameOfMethod.Equals("BackFromAbout"))
        {
            aboutText.gameObject.GetComponent<Animator>().Play("AboutTextOut");
            backAboutButton.SetActive(false);
        }
            
    }

    private IEnumerator WaitToMoveAndShowPoints()
    {
        yield return new WaitForSeconds(1);
        playerControllerScript.canMove = true;
        lifeText.SetActive(true);
        pointsText.SetActive(true);
    }
    #endregion
}
