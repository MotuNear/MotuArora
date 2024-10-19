using Cysharp.Threading.Tasks;
using System;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class CoreChainManager : MonoBehaviour
{
    #region Singleton
    public static CoreChainManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            CoreChainManager.Instance.EnablePlayPanels();
            Destroy(this.gameObject);
        }
    }
    #endregion

    public const string abi = "[{\"inputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"previousOwner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"OwnershipTransferred\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"TokensMinted\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"user\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"TokensStaked\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"user\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"reward\",\"type\":\"uint256\"}],\"name\":\"TokensUnstaked\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[],\"name\":\"GetCurrentTime\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"_result\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"_account\",\"type\":\"address\"}],\"name\":\"GetuserTokenBalance\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"MintSingleToken\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_itemId\",\"type\":\"uint256\"}],\"name\":\"PurchaseCoins\",\"outputs\":[],\"stateMutability\":\"payable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"_amount\",\"type\":\"uint256\"}],\"name\":\"TokenToCoinExchange\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"}],\"name\":\"allowance\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"account\",\"type\":\"address\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"decimals\",\"outputs\":[{\"internalType\":\"uint8\",\"name\":\"\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"subtractedValue\",\"type\":\"uint256\"}],\"name\":\"decreaseAllowance\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"_account\",\"type\":\"address\"}],\"name\":\"getPotentialReward\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"_account\",\"type\":\"address\"}],\"name\":\"getStakingDuration\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"_account\",\"type\":\"address\"}],\"name\":\"getTotalStaked\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"addedValue\",\"type\":\"uint256\"}],\"name\":\"increaseAllowance\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"mint\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"owner\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"renounceOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"stakeToken\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"name\":\"stakers\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"stakingTime\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"totalSupply\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"recipient\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"transfer\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"sender\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"recipient\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"newOwner\",\"type\":\"address\"}],\"name\":\"transferOwnership\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"unstakeToken\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"newRate\",\"type\":\"uint256\"}],\"name\":\"updateYearlyReturnRate\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"withdraw\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"yearlyReturnRateGet\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";
    // address of contract
    public static string contract = "0x6B9eD3928649085aD0D2060bEB7106Ae182350E9";


    static string chainId = "1313161555";
    static string network = "Testnet";
    static string networkRPC = "https://testnet.aurora.dev";

    [SerializeField] GameObject playBTN;
    [SerializeField] GameObject loginBTN;

     public static float[] coinCost = { 0.00001f, 0.00002f, 0.00003f, 0.00004f };

    public static string userBalance = "0";

    [DllImport("__Internal")]
    private static extern void Web3Connect();

    [DllImport("__Internal")]
    private static extern string ConnectAccount();

    [DllImport("__Internal")]
    private static extern void SetConnectAccount(string value);

    private int expirationTime;
    private string account;

    [SerializeField] TMP_Text _status;



    public static string userethAdd;





    ProjectConfigScriptableObject projectConfigSO = null;
    private void Start()
    {

        projectConfigSO = (ProjectConfigScriptableObject)Resources.Load("ProjectConfigData", typeof(ScriptableObject));


        projectConfigSO.ChainId = "1313161555";
        projectConfigSO.Rpc = "https://testnet.aurora.dev";

        PlayerPrefs.SetString("ProjectID", projectConfigSO.ProjectId);
        PlayerPrefs.SetString("ChainID", projectConfigSO.ChainId);
        PlayerPrefs.SetString("Chain", projectConfigSO.Chain);
        PlayerPrefs.SetString("Network", projectConfigSO.Network);
        PlayerPrefs.SetString("RPC", projectConfigSO.Rpc);

    }


    public async void LoginWallet()
    {
        _status.text = "Connecting...";

#if !UNITY_EDITOR
        Web3Connect();
        await UniTask.Delay(1000);
        OnConnected();
#else
        // get current timestamp
        int timestamp = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
        // set expiration time
        int expirationTime = timestamp + 60;
        // set message
        string message = "Motu Pop\n" + expirationTime.ToString() + "\nAuthentication";
        // sign message
        string signature = await Web3Wallet.Sign(message);
        await UniTask.Delay(1000);
        // verify account
        string account = await EVM.Verify(message, signature);
        account = account.ToLower();
        int now = (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;

        userethAdd = account;
        // validate
        if (account.Length == 42 && expirationTime >= now)
        {
            // save account
            PlayerPrefs.SetString("Account", account); ;

            print("Account: " + account);
            _status.text = "connected : " + account;
            CheckUserBalance().Forget();
            getTokenBalance().Forget();


            if (DatabaseManager.Instance)
            {
                DatabaseManager.Instance.GetData(true);
            }
            // load next scene
        }


        userethAdd = account;

        // EnablePlayPanels();

        // Debug.Log("LIST OF PUZZLE: " + await CheckPuzzleList());



#endif

    }

    public void EnablePlayPanels()
    {
        //TODO Enable Play BTN
        //FindObjectOfType<MainMenuPanel>()?.EnablePlayPanels();
        if (playBTN != null)
        {
            playBTN.gameObject.SetActive(true);
        }
        if (loginBTN != null)
        {
            loginBTN.SetActive(false);
        }

    }

    async private void OnConnected()
    {
        account = ConnectAccount();
        await UniTask.Delay(1000);
        while (account == "")
        {
            await new WaitForSecondsRealtime(2f);
            account = ConnectAccount();
        };
        account = account.ToLower();
        userethAdd = account;
        // save account for next scene
        PlayerPrefs.SetString("Account", account);
        _status.text = "connected : " + account;
        // reset login message
        SetConnectAccount("");
        CheckUserBalance();
        getTokenBalance();
        if (DatabaseManager.Instance)
        {
            DatabaseManager.Instance.GetData(true);
        }


        // load next scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);




        //CoinBuyOnSendContract(0);
    
        //  EnablePlayPanels();


    }


    #region BuyCoins
    async public void CoinBuyOnSendContract(int _pack)
    {
        if (MessageBox.Instance) MessageBox.Instance.showMsg("Coin purchase process started\nThis can up to minute", false);

        object[] inputParams = { _pack };

        float _amount = coinCost[_pack];
        float decimals = 1000000000000000000; // 18 decimals
        float wei = _amount * decimals;
        print(Convert.ToDecimal(wei).ToString() + " " + inputParams.ToString() + " + " + Newtonsoft.Json.JsonConvert.SerializeObject(inputParams));
        // smart contract method to call
        string method = "PurchaseCoins";

        // array of arguments for contract
        string args = Newtonsoft.Json.JsonConvert.SerializeObject(inputParams);
        // value in wei
        string value = Convert.ToDecimal(wei).ToString();

        // connects to user's browser wallet (metamask) to update contract state
        try
        {


#if !UNITY_EDITOR
            string response = await Web3GL.SendContract(method, abi, contract, args, value);
            Debug.Log(response);
#else
            // string response = await EVM.c(method, abi, contract, args, value, gasLimit, gasPrice);
            // Debug.Log(response);
            string data = await EVM.CreateContractData(abi, method, args);
            string response = await Web3Wallet.SendTransaction(chainId, contract, value, data);


            Debug.Log(response);
#endif

            if (!string.IsNullOrEmpty(response))
            {
                if (DatabaseManager.Instance)
                {
                    DatabaseManager.Instance.AddTransaction(response, "pending", _pack);
                }

                CheckTransactionStatus(response);
                if (MessageBox.Instance) MessageBox.Instance.showMsg("Your Transaction has been recieved\nCoins will reflect to your account once it is completed!", true);
            }




        }
        catch (Exception e)
        {
            if (MessageBox.Instance) MessageBox.Instance.showMsg("Transaction Has Been Failed", true);
            Debug.Log(e, this);
        }
    }
    #endregion



    #region CheckUserBalance
    public async UniTaskVoid CheckUserBalance()
    {
        COMEHERE:
        try
        {

            string response = await EVM.BalanceOf(chainId, network, PlayerPrefs.GetString("Account"), networkRPC);
            Debug.Log("CheckUserBalance " + response);
            if (!string.IsNullOrEmpty(response))
            {
                float wei = float.Parse(response);
                float decimals = 1000000000000000000; // 18 decimals
                float eth = wei / decimals;
                // print(Convert.ToDecimal(eth).ToString());
                Debug.Log(Convert.ToDecimal(eth).ToString());
                userBalance = Convert.ToDecimal(eth).ToString();

            }
        }
        catch (Exception e)
        {
            Debug.Log(e, this);
        }

        await UniTask.Delay(UnityEngine.Random.Range(5200, 12500));
        goto COMEHERE;
    }
    #endregion

    #region CheckTRansactionStatus
    //private string transID;
    public static string userTokenBalance = "0";

    public async UniTaskVoid CheckTransactionStatus(string _tranID)
    {
        bool NoCheckAgain = false;
        COMEHERE:
        Debug.Log("CheckTransactionStatus " + _tranID);
        await UniTask.Delay(UnityEngine.Random.Range(4000, 10000));
        try
        {
            string txConfirmed = await EVM.TxStatus(chainId, network, _tranID, networkRPC);
            print(txConfirmed); // success, fail, pending
            if (txConfirmed.Equals("success") || txConfirmed.Equals("fail"))
            {
                NoCheckAgain = true;
                if (DatabaseManager.Instance)
                {
                    DatabaseManager.Instance.ChangeTransactionStatus(_tranID, txConfirmed);
                }

            }

        }
        catch (Exception e)
        {
            Debug.Log(e, this);
        }

        if (!NoCheckAgain) goto COMEHERE;
    }


    #endregion

    #region Token

    async public void ExchangeToken(int _pack)
    {

        if (MessageBox.Instance) MessageBox.Instance.showMsg("Exchange token process started", false);

        float decimals = 1000000000000000000; // 18 decimals
        float wei = (_pack) * decimals;

        object[] inputParams = { contract, Convert.ToDecimal(wei).ToString() };


        // smart contract method to call
        string method = "transfer";

        // array of arguments for contract
        string args = Newtonsoft.Json.JsonConvert.SerializeObject(inputParams);
        // value in wei
        string value = "0";
        // connects to user's browser wallet (metamask) to update contract state
        try
        {


#if !UNITY_EDITOR
            string response = await Web3GL.SendContract(method, abi, contract, args, value);
            Debug.Log(response);
#else
            string data = await EVM.CreateContractData(abi, method, args);
            string response = await Web3Wallet.SendTransaction(chainId, contract, value, data);


            Debug.Log(response);
#endif



            //if (MessageBox.Instance) MessageBox.Instance.showMsg("Coin exchanged successfully", true);

            if (!string.IsNullOrEmpty(response))
            {
                if (DatabaseManager.Instance)
                {
                    DatabaseManager.Instance.AddTransaction(response, "pending", _pack - 1);
                }

                CheckTransactionStatus(response);
                if (MessageBox.Instance) MessageBox.Instance.showMsg("Your Transaction has been recieved\nCoins will reflect to your account once it is completed!", true);
            }



        }
        catch (Exception e)
        {
            if (MessageBox.Instance) MessageBox.Instance.showMsg("Transaction Has Been Failed", true);
            Debug.Log(e, this);
        }
    }
    public async static UniTaskVoid getTokenBalance()
    {
        COMEHERE:
        // smart contract method to call
        string method = "balanceOf";
        // array of arguments for contract
        object[] inputParams = { PlayerPrefs.GetString("Account") };
        string args = Newtonsoft.Json.JsonConvert.SerializeObject(inputParams);
        try
        {
            string response = await EVM.Call(chainId, network, contract, abi, method, args, networkRPC);
            Debug.Log(response);
            try
            {
                float wei = float.Parse(response);
                float decimals = 1000000000000000000; // 18 decimals
                float eth = wei / decimals;
                // print(Convert.ToDecimal(eth).ToString());
                var tokenBalance = Convert.ToDecimal(eth).ToString();
                userTokenBalance = tokenBalance;
                Debug.Log("Token Bal : " + Convert.ToDecimal(eth).ToString() + " | " + response);
            }
            catch (Exception)
            {
            }


        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        await UniTask.Delay(UnityEngine.Random.Range(5000, 12000));
        goto COMEHERE;

    }

    async public void getDailyToken()
    {

        if (MessageBox.Instance) MessageBox.Instance.showMsg("Claiming Token! This may take some time please wait!", false);

        object[] inputParams = { };
        string method = "MintSingleToken"; 

        // array of arguments for contract
        string args = Newtonsoft.Json.JsonConvert.SerializeObject(inputParams);
        // value in wei
        string value = "";// Convert.ToDecimal(wei).ToString();

        string response = "";
        // connects to user's browser wallet (metamask) to update contract state
        try
        {

#if !UNITY_EDITOR
                response = await Web3GL.SendContract(method, abi, contract, args, value);
                Debug.Log(response);
#else
            string data = await EVM.CreateContractData(abi, method, args);
            response = await Web3Wallet.SendTransaction(chainId, contract, "0", data);
            Debug.Log(response);
#endif

        }
        catch (Exception e)
        {
            Debug.Log("error" + e);
            if (MessageBox.Instance) MessageBox.Instance.showMsg("Server Error", true);
            return;
        }

        if (!string.IsNullOrEmpty(response))
        {
            MessageBox.Instance.showMsg("Token will be credited soon", true);


        }
        else
        {
            if (MessageBox.Instance) MessageBox.Instance.showMsg("Server Error", true);
            Debug.Log("In check blank");
        }

    }


    #endregion

    #region Token Stacking
    //New methods starts from here

    public async UniTask<string> getStakingValue()
    {
        // smart contract method to call
        string method = "getPotentialReward";
        // array of arguments for contract
        object[] inputParams = { PlayerPrefs.GetString("Account") };
        string args = Newtonsoft.Json.JsonConvert.SerializeObject(inputParams);
        try
        {
            string response = await EVM.Call(chainId, network, contract, abi, method, args, networkRPC);
            Debug.Log(response);
            try
            {
                float wei = float.Parse(response);
                float decimals = 1000000000000000000; // 18 decimals
                float eth = wei / decimals;
                // print(Convert.ToDecimal(eth).ToString());
                var tokenBalance = Convert.ToDecimal(eth).ToString();

                Debug.Log("getPotentialReward : " + Convert.ToDecimal(eth).ToString() + " | " + response);
                return Convert.ToDecimal(eth).ToString();

            }
            catch (Exception)
            {
                return "No Token Staked";
            }


        }
        catch (Exception e)
        {
            Debug.Log(e);
            return "No Token Staked";
        }

    }

    public async UniTask<string> getTotalStaked()
    {
        // smart contract method to call
        string method = "getTotalStaked";
        // array of arguments for contract
        object[] inputParams = { PlayerPrefs.GetString("Account") };
        string args = Newtonsoft.Json.JsonConvert.SerializeObject(inputParams);
        try
        {
            string response = await EVM.Call(chainId, network, contract, abi, method, args, networkRPC);
            Debug.Log(response);
            try
            {
                float wei = float.Parse(response);
                float decimals = 1000000000000000000; // 18 decimals
                float eth = wei / decimals;
                // print(Convert.ToDecimal(eth).ToString());
                var tokenBalance = Convert.ToDecimal(eth).ToString();

                Debug.Log("getTotalStaked : " + Convert.ToDecimal(eth).ToString() + " | " + response);
                return Convert.ToDecimal(eth).ToString();

            }
            catch (Exception)
            {
                return "No Token Staked";
            }


        }
        catch (Exception e)
        {
            Debug.Log(e);
            return "No Token Staked";
        }

    }

    public async UniTask<string> getYearlyReturnRate()
    {
        // smart contract method to call
        string method = "yearlyReturnRateGet";
        // array of arguments for contract
        object[] inputParams = { };
        string args = Newtonsoft.Json.JsonConvert.SerializeObject(inputParams);
        try
        {
            string response = await EVM.Call(chainId, network, contract, abi, method, args, networkRPC);
            Debug.Log(response);
            try
            {

                Debug.Log("yearlyReturnRate : " + response);
                return response;

            }
            catch (Exception)
            {
                return "Try After Sometime";
            }


        }
        catch (Exception e)
        {
            Debug.Log(e);
            return "Try After Sometime";
        }

    }

    async public UniTaskVoid StakeToken(float _value)
    {
        if (MessageBox.Instance) MessageBox.Instance.showMsg("Staking " + _value + " Tokens! This may take some time please wait!", true);

        float decimals = 1000000000000000000; // 18 decimals
        float wei = _value * decimals; //enter value here

        object[] inputParams = { Convert.ToDecimal(wei).ToString() };


        // smart contract method to call
        string method = "stakeToken";

        // array of arguments for contract
        string args = Newtonsoft.Json.JsonConvert.SerializeObject(inputParams);
        // value in wei
        string value = "0";

        // connects to user's browser wallet (metamask) to update contract state
        try
        {


#if !UNITY_EDITOR && !UNITY_ANDROID
            string response = await Web3GL.SendContract(method, abi, contract, args, value);
            Debug.Log(response);
#else
            // Debug.Log(response);
            string data = await EVM.CreateContractData(abi, method, args);
            string response = await Web3Wallet.SendTransaction(chainId, contract, value, data);


            Debug.Log(response);
#endif

            if (!string.IsNullOrEmpty(response))
            {
                if (MessageBox.Instance) MessageBox.Instance.showMsg("Token Staked Successfully", true);
            }

        }
        catch (Exception e)
        {
            if (MessageBox.Instance) MessageBox.Instance.showMsg("Transaction Has Been Failed", true);
            Debug.Log(e, this);
        }
    }

    async public UniTaskVoid UnstakeToken(float _value)
    {
        if (MessageBox.Instance) MessageBox.Instance.showMsg("Untaking Tokens! This may take some time please wait!", true);
        float decimals = 1000000000000000000; // 18 decimals
        float wei = _value * decimals; //enter value here

        object[] inputParams = { Convert.ToDecimal(wei).ToString() };

        // smart contract method to call
        string method = "unstakeToken";

        // array of arguments for contract
        string args = Newtonsoft.Json.JsonConvert.SerializeObject(inputParams);
        // value in wei
        string value = "0";

        // connects to user's browser wallet (metamask) to update contract state
        try
        {


#if !UNITY_EDITOR && !UNITY_ANDROID
            string response = await Web3GL.SendContract(method, abi, contract, args, value);
            Debug.Log(response);
#else
            // Debug.Log(response);
            string data = await EVM.CreateContractData(abi, method, args);
            string response = await Web3Wallet.SendTransaction(chainId, contract, value, data);


            Debug.Log(response);
#endif

            if (!string.IsNullOrEmpty(response))
            {
                if (MessageBox.Instance) MessageBox.Instance.showMsg("Token UnStaked Successfully", true);
            }

        }
        catch (Exception e)
        {
            if (MessageBox.Instance) MessageBox.Instance.showMsg("Transaction Has Been Failed", true);
            Debug.Log(e, this);
        }
    }

    #endregion


}
