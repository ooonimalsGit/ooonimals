using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController_NS : BaseGameController {

    public Toggle tradeOffered;
    public Toggle somethingSold;
    public Toggle tradeAccepted;
    public Toggle wishListAvailable;
    public Toggle newMerchandiseAvailable;
    public Toggle popupStore;
    public Toggle newScenesOfferedOnSite;
    public Toggle shippingNotifications;
    public Toggle trades;
    public Toggle orders;

    private List<Toggle> allToggles;

	// Use this for initialization
	void Start () {
        InitToggles();
	}

    private void InitToggles(){
        allToggles = new List<Toggle>();
        allToggles.Add(tradeOffered);
        allToggles.Add(somethingSold);
        allToggles.Add(tradeAccepted);
        allToggles.Add(wishListAvailable);
        allToggles.Add(newMerchandiseAvailable);
        allToggles.Add(popupStore);
        allToggles.Add(newScenesOfferedOnSite);
        allToggles.Add(shippingNotifications);
        allToggles.Add(trades);
        allToggles.Add(orders);

        tradeOffered.isOn               = IntToBool(PlayerPrefs.GetInt( PlayerPrefsManager.TRADE_OFFERED ));
        somethingSold.isOn              = IntToBool(PlayerPrefs.GetInt( PlayerPrefsManager.SOMETHING_SOLD ));
        tradeAccepted.isOn              = IntToBool(PlayerPrefs.GetInt( PlayerPrefsManager.TRADE_ACCEPTED ));
        wishListAvailable.isOn          = IntToBool(PlayerPrefs.GetInt( PlayerPrefsManager.WISH_LIST_AVAILABLE ));
        newMerchandiseAvailable.isOn    = IntToBool(PlayerPrefs.GetInt( PlayerPrefsManager.NEW_MERCH_AVAILABLE ));
        popupStore.isOn                 = IntToBool(PlayerPrefs.GetInt( PlayerPrefsManager.POP_UP_STORE ));
        newScenesOfferedOnSite.isOn     = IntToBool(PlayerPrefs.GetInt( PlayerPrefsManager.NEW_SCENES_OFFERED ));
        shippingNotifications.isOn      = IntToBool(PlayerPrefs.GetInt( PlayerPrefsManager.SHIPPING_NOTIFICATIONS ));
        trades.isOn                     = IntToBool(PlayerPrefs.GetInt( PlayerPrefsManager.TRADES ));
        orders.isOn                     = IntToBool(PlayerPrefs.GetInt( PlayerPrefsManager.ORDERS ));       
    }

    // Called when any toggle has changed states.
    public void ToggleChange(int toggleNum)
    {
        SaveNotificationPrefs(toggleNum);
    }

    // Called when the All or None button is clicked.
    public void ToggleAll(bool value)
    {
        for (int i = 0; i < allToggles.Count; i++)
        {
            allToggles[i].isOn = value;
        }
    }

    private void SaveNotificationPrefs(int toggleNum){
        PlayerPrefs.SetInt(GetToggleKey(toggleNum), BoolToInt(allToggles[toggleNum].isOn));
    }

    private int BoolToInt(bool @bool){
        int newVal = @bool == true? 1:0;
        return newVal;
    }

    private bool IntToBool(int @int){
        bool newVal = @int == 1 ? true : false;
        return newVal;
    }

    private string GetToggleKey(int targetNum)
    {
        string toggleKey;
        switch (targetNum)
        {
            case 0:
                toggleKey = PlayerPrefsManager.TRADE_OFFERED;
                break;
            case 1:
                toggleKey = PlayerPrefsManager.SOMETHING_SOLD;
                break;
            case 2:
                toggleKey = PlayerPrefsManager.TRADE_ACCEPTED;
                break;
            case 3:
                toggleKey = PlayerPrefsManager.WISH_LIST_AVAILABLE;
                break;
            case 4:
                toggleKey = PlayerPrefsManager.NEW_MERCH_AVAILABLE;
                break;
            case 5:
                toggleKey = PlayerPrefsManager.POP_UP_STORE;
                break;
            case 6:
                toggleKey = PlayerPrefsManager.NEW_SCENES_OFFERED ;
                break;
            case 7:
                toggleKey = PlayerPrefsManager.SHIPPING_NOTIFICATIONS;
                break;
            case 8:
                toggleKey = PlayerPrefsManager.TRADES;
                break;
            case 9:
                toggleKey = PlayerPrefsManager.ORDERS;
                break;
            default:
                toggleKey = PlayerPrefsManager.TRADE_OFFERED;
                break;
        }
        return toggleKey;
    }
}
