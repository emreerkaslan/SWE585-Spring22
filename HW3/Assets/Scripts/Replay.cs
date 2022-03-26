using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{

	[SerializeField] Button replayButton, changeCameraButton, easyButton, hardButton;
	[SerializeField] PlayerController PlayerController;
	[SerializeField] Text TextWin, TextLost;
	[SerializeField] GameObject Reward;
	[SerializeField] Camera camUp, camDown;
	[SerializeField] Barrier2Script Barrier2Script;
	[SerializeField] BarrierScript BarrierScript;

	// Start is called before the first frame update
	void Start()
	{
		camUp.enabled = true;
		camDown.enabled = false;

		replayButton.gameObject.SetActive(false);
		replayButton.onClick.AddListener(ReplayGame);
		changeCameraButton.onClick.AddListener(ChangeCamera);
		easyButton.onClick.AddListener(EasyClick);
		hardButton.onClick.AddListener(HardClick);

		TextWin.gameObject.SetActive(false);
		TextLost.gameObject.SetActive(false);
	}

	public void ReplayGame()
	{
		Reward.gameObject.SetActive(true);
		TextWin.gameObject.SetActive(false);
		TextLost.gameObject.SetActive(false);

		PlayerController.on = true;
		replayButton.gameObject.SetActive(false);
	}

	public void ChangeCamera()
    {
		camUp.enabled = !camUp.enabled;
		camDown.enabled = !camDown.enabled;
	}

	public void EasyClick()
    {
		easyButton.gameObject.SetActive(false);
		hardButton.gameObject.SetActive(false);
    }

	public void HardClick()
	{
		easyButton.gameObject.SetActive(false);
		hardButton.gameObject.SetActive(false);
		Barrier2Script.difficulty = 3;
		BarrierScript.difficulty = 3;
	}
}
