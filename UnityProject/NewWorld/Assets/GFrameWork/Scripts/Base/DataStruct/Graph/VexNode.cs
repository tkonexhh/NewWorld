/************************
	FileName:/GFrameWork/Scripts/Base/DataStruct/Graph/VexNode.cs
	CreateAuthor:neo.xu
	CreateTime:4/26/2020 4:41:27 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{

    /// <summary>
    /// 无向图邻接表类的实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class adjListNode<T>
    {
        private int adjvex;//邻接顶点
        private adjListNode<T> next;//下一个邻接表结点

        //邻接顶点属性
        public int Adjvex
        {
            get { return adjvex; }
            set { adjvex = value; }
        }

        //下一个邻接表结点属性
        public adjListNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        public adjListNode(int vex)
        {
            adjvex = vex;
            next = null;
        }
    }



    /// <summary>
    /// 无向图邻接表的顶点结点类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VexNode<T>
    {
        private GraphNode<T> data; //图的顶点
        private adjListNode<T> firstAdj; //邻接表的第1个结点

        public GraphNode<T> Data
        {
            get { return data; }
            set { data = value; }
        }

        //邻接表的第1个结点属性
        public adjListNode<T> FirstAdj
        {
            get { return firstAdj; }
            set { firstAdj = value; }
        }

        //构造器
        public VexNode()
        {
            data = null;
            firstAdj = null;
        }

        //构造器
        public VexNode(GraphNode<T> nd)
        {
            data = nd;
            firstAdj = null;
        }

        //构造器
        public VexNode(GraphNode<T> nd, adjListNode<T> alNode)
        {
            data = nd;
            firstAdj = alNode;
        }
    }

}