using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using TMPro;

public class CreateContract : MonoBehaviour
{
    [SerializeField] string[] platform = { "Desktop","Mobile","Console" };
    [SerializeField] string[] type = { "Game", "App", "Web" };
    //string companyName= "Fahrettin";

    DbManager dbManager;
    [SerializeField] GameObject ContractObj;
    [SerializeField] GameObject ContractPanel;

    //contract work'den kazan� �irketin gelirine g�re de�i�meli �irket �ok kazan�yorken daha b�t�k i�ler gelmeli, k���kken k���k i�ler gelmeli
    public List<Contract> Contracts = new List<Contract>();
    // Start is called before the first frame update
    void Start()
    {
        dbManager = FindObjectOfType<DbManager>();

        CreateContracts();
    }
    public void DestroyContract(int ContID)
    {
       // Destroy(ContractPanel.transform.Find(ContID.ToString()));
        
    }
    void CreateContracts()
    {
        Contracts.Clear();
        int i = 0;
        while (i < 9)
        {
            //GameObject newProduct = Instantiate(ContractObj);
            //newProduct.transform.SetParent(ContractPanel.transform);
            GameObject newProduct = Instantiate(ContractObj,ContractPanel.transform,false);
            Contract contractObj = newProduct.GetComponent<Contract>();

            Contracts.Add(contractObj);
            
            //contractObj.productId = ;
            //contractObj.companyName = companyName;
            contractObj.platform = platform[Random.Range(0, 2)];
            contractObj.sofType = type[Random.Range(0, 2)];
            contractObj.duration = Random.Range(5, 18);
            contractObj.offer = contractObj.duration * 125;
            contractObj.code = contractObj.duration * Random.Range(8, 13);
            contractObj.art = contractObj.duration * Random.Range(8, 13);
            contractObj.design = contractObj.duration * Random.Range(8, 13);
            contractObj.ContID = i * 2;

            CreateContractUI(contractObj);
            i++;
        }
    }
    public void CreateContractUI(Contract contractObj)
    {
        
        contractObj.transform.Find("TopPart/type").GetComponent<TextMeshProUGUI>().text = "Type:" + contractObj.sofType;
        contractObj.transform.Find("TopPart/platform").GetComponent<TextMeshProUGUI>().text = "Platform:" + contractObj.platform;
        contractObj.transform.Find("TopPart/duration").GetComponent<TextMeshProUGUI>().text = "Duration:" + contractObj.duration.ToString();
        contractObj.transform.Find("TopPart/offer").GetComponent<TextMeshProUGUI>().text = "Offer:" + contractObj.offer.ToString();
        
        contractObj.transform.Find("workforce/code").GetComponent<TextMeshProUGUI>().text = "Code:" + contractObj.code.ToString();
        contractObj.transform.Find("workforce/design").GetComponent<TextMeshProUGUI>().text = "Design:" + contractObj.design.ToString();
        contractObj.transform.Find("workforce/art").GetComponent<TextMeshProUGUI>().text = "Art:" + contractObj.art.ToString();


    }

}
