/************************
	FileName:/GFrameWork/Scripts/Base/DataStruct/Graph/IGraph.cs
	CreateAuthor:neo.xu
	CreateTime:4/26/2020 4:34:19 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public interface IGraph<T>
    {
        //获取顶点数
        int GetNumOfVertex();
        //获取边或弧的数目
        int GetNumOfEdge();
        //在两个顶点之间添加权为v的边或弧
        void SetEdge(GraphNode<T> v1, GraphNode<T> v2, int v);
        //删除两个顶点之间的边或弧
        void DelEdge(GraphNode<T> v1, GraphNode<T> v2);
        //判断两个顶点之间是否有边或弧
        bool IsEdge(GraphNode<T> v1, GraphNode<T> v2);
    }

}