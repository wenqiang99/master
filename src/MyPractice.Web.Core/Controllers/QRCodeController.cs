using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Linq;

namespace MyPractice.Controllers
{
    /// <summary>
    /// 二维码
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class QRCodeController : MyPracticeControllerBase
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult MakeQrCode(string str)
        {
            var generator = new QRCodeGenerator();
            var codeData = generator.CreateQrCode(str, QRCodeGenerator.ECCLevel.M, true);
            QRCoder.QRCode qrcode = new QRCoder.QRCode(codeData);
            var qrImage = qrcode.GetGraphic(10, Color.Black, Color.White, true);
            var ms = new MemoryStream();
            qrImage.Save(ms, ImageFormat.Jpeg);//图片格式指定为png
            byte[] bytes = ms.GetBuffer();
            ms.Close();
            return File(bytes, "image/Png");
        }
    }
}
