using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame.I18N
{
    public class EditorTab
    {
        protected I18NConfig config;
        public virtual void OnOpen(I18NConfig config)
        {
            this.config = config;
        }
        public virtual void OnDraw() { }
    }
}
