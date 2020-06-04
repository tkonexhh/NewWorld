/************************
	FileName:/GFrameWork/Scripts/Base/DataStruct/Graph/GraphAdjMatrix.cs
	CreateAuthor:neo.xu
	CreateTime:4/26/2020 4:36:46 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    /// <summary>
    /// 无向图邻接矩阵类 GraphAdjMatrix<T>的实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GraphAdjMatrix<T> : IGraph<T>
    {
        private GraphNode<T>[] nodes;//顶点数组
        private int[,] matrix;//邻接矩阵数组
        private int numEdges;//边的数目

        public GraphAdjMatrix(int n)
        {
            nodes = new GraphNode<T>[n];
            matrix = new int[n, n];
            numEdges = 0;
        }

        //获取索引为index的顶点的信息
        public GraphNode<T> GetNode(int index)
        {
            return nodes[index];
        }

        //设置索引为index的顶点的信息
        public void SetNode(int index, GraphNode<T> v)
        {
            nodes[index] = v;
        }

        //获取matrix[index1, index2]的值
        public int GetMatrix(int index1, int index2)
        {
            return matrix[index1, index2];
        }

        //设置matrix[index1, index2]的值
        public void SetMatrix(int index1, int index2)
        {
            matrix[index1, index2] = 1;
        }

        //边的数目属性
        public int NumEdges
        {
            get { return numEdges; }
            set { numEdges = value; }
        }

        //获取顶点的数目
        public int GetNumOfVertex()
        {
            return nodes.Length;
        }

        //获取边的数目
        public int GetNumOfEdge()
        {
            return numEdges;
        }

        //判断v是否是图的顶点
        public bool IsNode(GraphNode<T> v)
        {
            //遍历顶点数组
            foreach (GraphNode<T> nd in nodes)
            {
                //如果顶点nd与v相等，则v是图的顶点，返回true
                if (v.Equals(nd))
                {
                    return true;
                }
            }

            return false;
        }

        //获取顶点v在顶点数组中的索引
        public int GetIndex(GraphNode<T> v)
        {
            int i = -1;
            //遍历顶点数组
            for (i = 0; i < nodes.Length; ++i)
            {
                //如果顶点v与nodes[i]相等，则v是图的顶点，返回索引值i。
                if (nodes[i].Equals(v))
                {
                    return i;
                }
            }
            return i;
        }

        //在顶点v1和v2之间添加权值为v的边
        public void SetEdge(GraphNode<T> v1, GraphNode<T> v2, int v = 1)
        {
            if (!IsNode(v1) || !IsNode(v2))
            {
                Debug.LogError("Node is not belong to Graph!");
                return;
            }

            //不是无向图
            if (v != 1)
            {
                Debug.LogError("Weight is not right!");
                return;
            }

            //矩阵是对称矩阵
            matrix[GetIndex(v1), GetIndex(v2)] = v;
            matrix[GetIndex(v2), GetIndex(v1)] = v;
            ++numEdges;
        }

        //删除顶点v1和v2之间的边
        public void DelEdge(GraphNode<T> v1, GraphNode<T> v2)
        {
            //v1或v2不是图的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Debug.LogError("Node is not belong to Graph!");
                return;
            }

            //顶点v1与v2之间存在边
            if (matrix[GetIndex(v1), GetIndex(v2)] == 1)
            {
                //矩阵是对称矩阵
                matrix[GetIndex(v1), GetIndex(v2)] = 0;
                matrix[GetIndex(v2), GetIndex(v1)] = 0;
                --numEdges;
            }
        }

        //判断顶点v1与v2之间是否存在边
        public bool IsEdge(GraphNode<T> v1, GraphNode<T> v2)
        {
            //v1或v2不是图的顶点
            if (!IsNode(v1) || !IsNode(v2))
            {
                Debug.LogError("Node is not belong to Graph!");
                return false;
            }

            //顶点v1与v2之间存在边
            if (matrix[GetIndex(v1), GetIndex(v2)] == 1)
            {
                return true;
            }
            else //不存在边
            {
                return false;
            }
        }

        public bool IsEdge(int x, int y)
        {
            if (matrix[x, y] == 1)
            {
                return true;
            }
            else //不存在边
            {
                return false;
            }
        }


        // //从某个顶点出发进行深度优先遍历
        // public void DFSAL(int i)
        // {
        //     visited[i] = 1;
        //     adjListNode<T> p = adjList[i].FirstAdj;
        //     while (p != null)
        //     {
        //         if (visited[p.Adjvex] == 0)
        //         {
        //             DFSAL(p.Adjvex);
        //         }
        //         p = p.Next;
        //     }

        // }

        // //无向图的广度优先遍历算法的实现
        // public void BFS()
        // {
        //     for (int i = 0; i < visited.Length; ++i)
        //     {
        //         if (visited[i] == 0)
        //         {
        //             BFSAL(i);
        //         }
        //     }
        // }

        // //从某个顶点出发进行广度优先遍历
        // public void BFSAL(int i)
        // {
        //     visited[i] = 1;
        //     CSeqQueue<int> cq = new CSeqQueue<int>(visited.Length);
        //     cq.In(i);
        //     while (!cq.IsEmpty())
        //     {
        //         int k = cq.Out();
        //         adjListNode<T> p = adjList[k].FirstAdj;

        //         while (p != null)
        //         {
        //             if (visited[p.Adjvex] == 0)
        //             {
        //                 visited[p.Adjvex] = 1;
        //                 cq.In(p.Adjvex);
        //             }

        //             p = p.Next;
        //         }
        //     }
        // }

    }

}