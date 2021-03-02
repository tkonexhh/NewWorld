/************************
	FileName:/GFrameWork/Scripts/Framework/Task/TaskStatus.cs
	CreateAuthor:neo.xu
	CreateTime:3/1/2021 4:07:32 PM
	Tip:3/1/2021 4:07:32 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame.Task
{
    /// <summary>
    /// 任务状态。
    /// </summary>
    public enum TaskStatus : byte
    {
        /// <summary>
        /// 空闲。
        /// </summary>
        Free = 0,

        /// <summary>
        /// 等待中。
        /// </summary>
        Waiting,

        /// <summary>
        /// 运行中。
        /// </summary>
        Running,

        /// <summary>
        /// 已完成。
        /// </summary>
        Completed,

        /// <summary>
        /// 已失败。
        /// </summary>
        Failed,

        /// <summary>
        /// 已取消。
        /// </summary>
        Canceled
    }

}