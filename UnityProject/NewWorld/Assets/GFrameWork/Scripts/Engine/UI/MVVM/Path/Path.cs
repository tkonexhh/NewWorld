/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Path/Path.cs
	CreateAuthor:neo.xu
	CreateTime:3/2/2021 1:58:24 PM
	Tip:3/2/2021 1:58:24 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame.Binding.Paths
{
    public interface IPathNode
    {
        bool IsStatic { get; }
        // void AppendTo();
    }

    public class Path : IEnumerator<IPathNode>
    {
        private List<IPathNode> nodes = new List<IPathNode>();

        public int Count
        {
            get { return this.nodes.Count; }
        }

        #region IEnumerator<IPathNode> Support
        private int index = -1;
        public IPathNode Current
        {
            get { return this.nodes[index]; }
        }

        object IEnumerator.Current
        {
            get { return this.nodes[index]; }
        }
        public bool MoveNext()
        {
            this.index++;
            return this.index >= 0 && index < this.nodes.Count;
        }

        public void Reset()
        {
            this.index = -1;
        }
        #endregion

        #region IDisposable Support
        private bool disposed = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.nodes.Clear();
                    this.index = -1;
                }
                disposed = true;
            }
        }

        ~Path()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

}