using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StakeManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputValueField;
    [SerializeField] TMP_Text returnRateText;
    [SerializeField] TMP_Text currentValueText;
    [SerializeField] TMP_Text totalStakedText;
    [SerializeField] TMP_Text totalTokensText;

    static bool isRunning = false;

    string totalStaked = "0";

    [SerializeField] Button UnStakingButton;

    private void OnEnable()
    {
        isRunning = true;
        GetData().Forget();
    }

    private void OnDisable()
    {
        isRunning = false;
    }

    async UniTaskVoid GetData()
    {
        HERE:
        returnRateText.text = "Annual Staking Return Rate : " + await CoreChainManager.Instance.getYearlyReturnRate() + " %";
        await UniTask.Delay(100);
        currentValueText.text = "Current Stake Value : " + await CoreChainManager.Instance.getStakingValue();
        await UniTask.Delay(100);
        totalStaked = await CoreChainManager.Instance.getTotalStaked();
        totalStakedText.text = "Total Staked Tokens : " + totalStaked;

        if (totalStaked == "0") UnStakingButton.interactable = false; else UnStakingButton.interactable = true;

        totalTokensText.text = "Total Tokens Available : " + CoreChainManager.userTokenBalance;
        await UniTask.Delay(5000);
        if (isRunning) goto HERE;
    }


    public void Stake()
    {
        try
        {

            if (float.Parse(inputValueField.text) <= float.Parse(CoreChainManager.userTokenBalance))
            {
                CoreChainManager.Instance.StakeToken(float.Parse(inputValueField.text)).Forget();
            }
            else {
                if (MessageBox.Instance) MessageBox.Instance.showMsg("Please Check Token Amount", true);
            }
        }
        catch (System.Exception)
        {
            if (MessageBox.Instance) MessageBox.Instance.showMsg("Please Check Token Amount", true);
        }

    }

    public void Unstake()
    {
        try
        {

            if (float.Parse(inputValueField.text) <= float.Parse(totalStaked))
            {
                 CoreChainManager.Instance.UnstakeToken(float.Parse(inputValueField.text)).Forget();               
            }
            else {
                if (MessageBox.Instance) MessageBox.Instance.showMsg("Please Check Token Amount", true);
            }
        }
        catch (System.Exception)
        {
            if (MessageBox.Instance) MessageBox.Instance.showMsg("Please Check Token Amount", true);
        }

    }
       

}
