using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPractice.Common
{
    /// <summary>
    /// 文件信息
    /// </summary>
    public class FileDto
    {
        public FileDto() { }
        /// <summary>
        /// 文件名称
        /// </summary>
        [Required]
        public string FileName { get; set; }
        /// <summary>
        /// 文档类型
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// 文档唯一标识
        /// </summary>
        [Required]
        public string FileToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileType"></param>
        public FileDto(string fileName, string fileType)
        {
            FileName = fileName;
            FileType = fileType;
            FileToken = Guid.NewGuid().ToString("N");
        }
    }
}
