/************************
	FileName:/GFrameWork/Scripts/Engine/DataRecord/PlayerPrefs/Sample/DataRecordSample.cs
	CreateAuthor:neo.xu
	CreateTime:6/30/2020 11:29:34 AM
	Tip:6/30/2020 11:29:34 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame.Sample
{
    public class DataRecordSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.LogError(DataRecord.S.GetBool("Bool1", false));
            DataRecord.S.SetBool("Bool1", true);
            Debug.LogError(DataRecord.S.GetBool("Bool1", true));

            DataRecord.S.SetFloat("Float", 0.1f);
            Debug.LogError(DataRecord.S.GetFloat("Float", 0f));

            DataRecord.S.SetInt("Int", 1);
            Debug.LogError(DataRecord.S.GetInt("Int", 1));
            DataRecord.S.Save();
        }

    }

}