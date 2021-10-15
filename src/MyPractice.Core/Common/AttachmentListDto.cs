using MyPractice.FileInfos;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPractice.Common
{
    public class AttachmentListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 所属模块， 供前端划分文件列表使用
        /// </summary>
        public string Module { get; set; }

        /// <summary>
        /// 业务类型，不同业务不同的类型
        /// </summary>
        public string BusinessType { get; set; }

        /// <summary>
        /// 业务ID，不同业务不同的类型
        /// </summary>
        public string BusinessId { get; set; }

        /// <summary>
        /// 原名称，附件上传时的文件名称
        /// </summary>
        public string OriginalName { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public string FileSize { get; set; }

        /// <summary>
        /// 下载路径
        /// </summary>
        public string DownLoadPath { get; set; }

        /// 上传时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 上传人
        /// </summary>
        public string CreatorUser { get; set; }
    }
}
