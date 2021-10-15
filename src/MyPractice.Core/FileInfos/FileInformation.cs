using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyPractice.FileInfos
{
    /// <summary>
    /// 文件信息
    /// </summary>
    [Table("FileInformation")]
    public class FileInformation : AuditedEntity<Guid>
    {
        /// <summary>
        /// 所属模块，供前端划分文件列表使用
        /// </summary>
        public string Module { get; set; }

        /// <summary>
        /// 业务类型，不同业务不同的类型
        /// </summary>
        public string BusinessType { get; set; }

        /// <summary>
        /// 业务ID，不同业务不同类型
        /// </summary>
        public string BusinessId { get; set; }

        /// <summary>
        /// 原名称，附件上传是的文件名称
        /// </summary>
        public string OriginalName { get; set; }

        /// <summary>
        /// 文件当前新名称(随机码)
        /// </summary>
        public string CurrentName { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public string FileSize { get; set; }

        /// <summary>
        /// 物理路径
        /// </summary>
        public string PhysicalPath { get; set; }

        /// <summary>
        /// 下载路径
        /// </summary>
        public string DownLoadPath { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public override DateTime CreationTime { get; set; }

        /// <summary>
        /// 上传人
        /// </summary>
        public override long? CreatorUserId { get; set; }

        /// <summary>
        /// 租户ID
        /// </summary>
        public int? TenantId { get; set; }
    }
}
