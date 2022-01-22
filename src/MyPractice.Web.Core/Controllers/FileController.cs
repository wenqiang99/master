using Abp.Auditing;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IO;
using Abp.IO.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyPractice.Authorization.Users;
using MyPractice.Common;
using MyPractice.FileInfos;
using MyPractice.Net.MimeTypes;
using MyPractice.TemporaryStorage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyPractice.Controllers
{
    /// <summary>
    /// 附件管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class FileController : MyPracticeControllerBase
    {
        private readonly IRepository<FileInformation, Guid> _fileInformationRepository;
        private readonly UserManager _userManager;
        private readonly IConfigurationRoot _appConfiguration;
        private readonly ITempFileCacheManager _tempFileCacheManager;

        public FileController(
            IRepository<FileInformation, Guid> fileInformationRepository,
            UserManager userManager, ITempFileCacheManager tempFileCacheManager
          )
        {
            _fileInformationRepository = fileInformationRepository;
            _userManager = userManager;
            _tempFileCacheManager = tempFileCacheManager;
        }

        /// <summary>
        /// 适用于小附件上传
        /// </summary>
        /// <param name="files"></param>
        /// <param name="businessId"></param>
        /// <param name="module"></param>
        /// <param name="businessType"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<AttachmentListDto>> UploadFiles(List<IFormFile> files, string businessId, string module, string businessType)
        {
            try
            {
                string fileType = "";
                string sFilePath = "";
                int uploadMaxByte = 0;
                fileType = !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings.Get("UploadType")) ?
                ConfigurationManager.AppSettings.Get("UploadType") : "jpg,png,xlsx,docx,xls,doc,pdf,rar,zip,cad,dwg,dxf,dwt,txt";
                sFilePath = !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings.Get("UploadSavePath")) ?
                ConfigurationManager.AppSettings.Get("UploadSavePath") : "/Resource/FileStore/";
                //sFilePath = sFilePath.Contains("~") ? _env.ContentRootPath + sFilePath.Replace('~', ' ').Trim() : sFilePath;
                int.TryParse(ConfigurationManager.AppSettings.Get("UploadMaxByte"), out int UploadMaxByte);
                uploadMaxByte = UploadMaxByte > 0 ? UploadMaxByte : 5242880;
                //还是为空，那么就抛出异常
                if (fileType.IsNullOrWhiteSpace() || sFilePath.IsNullOrWhiteSpace() || uploadMaxByte == 0)
                {
                    throw new UserFriendlyException("未配置附件上传默认设置！");
                }
                //返回前台的附件List
                List<AttachmentListDto> fileList = new List<AttachmentListDto>();
                //如果路径不存在，创建路径
                DirectoryHelper.CreateIfNotExists(sFilePath);
                foreach (var formFile in files)
                {
                    //获取上传文件名，这里获取含有双引号'"'
                    string fileName = formFile.FileName;
                    //获取上传文件后缀名
                    string fileExt = fileName.Substring(formFile.FileName.LastIndexOf('.'));
                    string newFileName = Guid.NewGuid().ToString() + fileExt;
                    //创建保存上传文件的物理路径
                    var filePath = sFilePath + newFileName;
                    if (formFile.Length > 0 && formFile.Length <= uploadMaxByte)
                    {
                        if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(fileType.Split(','), fileExt.Substring(1).ToLower()) == -1)
                        {
                            throw new UserFriendlyException("上传的文件格式不支持");
                        }
                        else
                        {
                            FileInformation file = new FileInformation();
                            file.FileSize = formFile.Length.ToString();
                            file.FileType = MimeTypeHelper.GetContentTypeByStuffix(fileExt);
                            file.BusinessId = businessId.IsNullOrWhiteSpace() ? "" : businessId;
                            file.Module = module;
                            file.BusinessType = businessType;
                            file.CurrentName = newFileName;
                            file.OriginalName = fileName;
                            file.PhysicalPath = filePath;
                            FileInformation fileInfo = await _fileInformationRepository.InsertAsync(file);
                            fileInfo.DownLoadPath = _appConfiguration["App:ServerRootAddress"] + "api/File/FileDownload?gid=" + fileInfo.Id;
                            var fis = ObjectMapper.Map<AttachmentListDto>(fileInfo);
                            fis.CreatorUser = GetCurrentUserAsync().Result.Name;
                            fileList.Add(fis);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await formFile.CopyToAsync(stream);
                                stream.Close();
                            }
                        }
                    }
                    else
                    {
                        throw new UserFriendlyException("上传文件的大小超出文件配置或者是空文件！");
                    }
                }
                return fileList;
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }

        /// <summary>
        /// 根据业务ID，模块名称，类型查询相关数据
        /// </summary>
        /// <param name="businessId"></param>
        /// <param name="module"></param>
        /// <param name="businessType"></param>
        /// <returns></returns>
        [HttpGet]
        public List<AttachmentListDto> GetBussinessId(string businessId, string module, string businessType)
        {
            try
            {
                var fileList = _fileInformationRepository.GetAll().OrderByDescending(t => t.CreationTime).Where(t =>
                t.BusinessId == businessId && t.Module == module && t.BusinessType == businessType).ToList().Select(MapToEntityDto).ToList();
                return fileList;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        /// <summary>
        /// 附件下载
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        [HttpGet]
        [DisableAuditing]
        public ActionResult FileDownload(Guid gid)
        {
            var fileInfo = _fileInformationRepository.Get(gid);
            var fileBytes = new FileStream(fileInfo.PhysicalPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);//推荐此方法
            if (fileBytes.Length == 0)
            {
                return NotFound(L("RequestedFileDoesNotExists"));
            }
            return File(fileBytes, fileInfo.FileType, fileInfo.OriginalName);
        }


        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpGet]
        [DisableAuditing]
        public ActionResult DownloadTempFile(FileDto file)
        {
            //通过内存临时存储里面获取
            var fileBytes = _tempFileCacheManager.GetFile(file.FileToken);
            if (fileBytes == null)
            {
                return NotFound(L("RequestedFileDoesNotExists"));
            }

            return File(fileBytes, file.FileType, file.FileName);
        }

        /// <summary>
        /// Excel模板下载
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        [HttpGet]
        [DisableAuditing]
        public ActionResult TemplateFileDownload(string FileName)
        {
            string TemplatePath= Environment.CurrentDirectory.ToString() + "\\ExcelTemplate\\" + FileName;
            var fileBytes = new FileStream(TemplatePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);//推荐此方法
            if (fileBytes.Length == 0)
            {
                return NotFound(L("RequestedFileDoesNotExists"));
            }
            return File(fileBytes, MimeTypeNames.ApplicationVndOpenxmlformatsOfficedocumentSpreadsheetmlSheet, FileName);
        }

        /// <summary>
        /// Map
        /// </summary>
        /// <param name="fileInformation"></param>
        /// <returns></returns>
        protected AttachmentListDto MapToEntityDto(FileInformation fileInformation)
        {
            var attachmentListDto = ObjectMapper.Map<AttachmentListDto>(fileInformation);
            if (fileInformation.CreatorUserId != null)
            {
                var queryable = _userManager.GetUserByIdAsync((long)fileInformation.CreatorUserId).Result;
                attachmentListDto.CreatorUser = queryable.NormalizedUserName;
            }

            return attachmentListDto;
        }

        /// <summary>
        /// EXCEL导入专用导入
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public FileDto Post(IFormFile file)
        {
            string fileName = file.FileName;
            string fileExt = fileName.Substring(fileName.LastIndexOf('.'));
            var fileDto = new FileDto(fileName, MimeTypeHelper.GetContentTypeByStuffix(fileExt));
            _tempFileCacheManager.SetFile(fileDto.FileToken, file.OpenReadStream().GetAllBytes());
            return fileDto;
        }
    }
 
}
