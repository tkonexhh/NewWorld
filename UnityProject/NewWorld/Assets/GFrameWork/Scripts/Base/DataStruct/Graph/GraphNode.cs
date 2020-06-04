/************************
	FileName:/GFrameWork/Scripts/Base/DataStruct/Graph/GraphNode.cs
	CreateAuthor:neo.xu
	CreateTime:4/26/2020 4:31:00 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class GraphNode<T>
    {
        private T data;

        public GraphNode(T v)
        {
            data = v;
        }


        public T Data
        {
            get => data;
            set => data = value;
        }
    }

}