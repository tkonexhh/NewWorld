/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Binding/BindingDescription.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 11:32:49 AM
	Tip:3/2/2021 11:32:49 AM
************************/

using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class BindingDescription
    {
        public string TargetName { get; set; }
        public string UpdateTrigger { get; set; }

        public SourceDescription Source { get; set; }

        public BindingDescription()
        {
        }

        public BindingDescription(string targetName)
        {
            this.TargetName = targetName;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("-----");
            return builder.ToString();
        }
    }

}