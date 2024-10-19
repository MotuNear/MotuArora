using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InAppManager : MonoBehaviour
{
    public static InAppManager insta;
 
    


    

    private void Awake()
    {
        insta = this;      
    }

  

    public void purchaseItem(int index)
    {
        CoreChainManager.Instance.CoinBuyOnSendContract(index);
    }
     public void Exchange(int index)
    {
        CoreChainManager.Instance.ExchangeToken(index);
    }

    [SerializeField] GameObject mainMenuPopUp;
    [SerializeField] GameObject coinShopPopup;
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject coinShopPanel;
    public void CloseShop()
    {
        //AudioManager.Instance.PlayButtionSound();

        LeanTween.cancel(mainMenuPopUp);
        LeanTween.cancel(coinShopPopup);

                

        LeanTween.scale(coinShopPopup, Vector3.zero, 0.3f).setIgnoreTimeScale(true).setEaseInOutQuad().setOnComplete(() => {
            mainMenuPanel.SetActive(true);
            coinShopPanel.SetActive(false);
        });
    }
    

}
